using EDNeutronRouterPlugin;

using EdTools;

using Newtonsoft.Json.Linq;

namespace RatAssist
{
    public partial class FormMain : Form
    {
        private MessageJumpCalculation mjc;
        internal JournalScanner JournalScanner { get; private set; }
        public static readonly string JournalPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\Saved Games\\Frontier Developments\\Elite Dangerous";
        private readonly System.Windows.Forms.Timer _delayedUpdate;

        public FormMain()
        {
            InitializeComponent();

            mjc = new()
            {
                Background = pictureBox1,
                Foreground = label8,
                Form = this
            };

            _delayedUpdate = new System.Windows.Forms.Timer()
            {
                Enabled = false,
                Interval = 1000,
            };
            _delayedUpdate.Tick += DelayedUpdateTick;

            #region Setup journal scanner
            JournalScanner = new JournalScanner(JournalPath);

            textBoxCurrentSystem.Text = "[UNKNOWN]";
            JournalScanner.DockedHandler += JournalScanner_DockedHandler;
            JournalScanner.ScanHandler += JournalScanner_ScanHandler;
            JournalScanner.FSDJumpHandler += JournalScanner_FSDJumpHandler;
            JournalScanner.SupercruiseExitHandler += JournalScanner_SupercruiseExitHandler;
            JournalScanner.SupercruiseEntryHandler += JournalScanner_SupercruiseEntryHandler;
            JournalScanner.ApproachBodyHandler += JournalScanner_ApproachBodyHandler;
            JournalScanner.TouchdownHandler += JournalScanner_TouchdownHandler;
            JournalScanner.LiftoffHandler += JournalScanner_LiftoffHandler;
            JournalScanner.DisembarkHandler += JournalScanner_DisembarkHandler;
            JournalScanner.EmbarkHandler += JournalScanner_EmbarkHandler;
            JournalScanner.LeaveBodyHandler += JournalScanner_LeaveBodyHandler;
            JournalScanner.LocationHandler += JournalScanner_LocationHandler;
            JournalScanner.StoredShipsHandler += JournalScanner_StoredShipsHandler;
            JournalScanner.OutfittingHandler += JournalScanner_OutfittingHandler;
            JournalScanner.ShipyardHandler += JournalScanner_ShipyardHandler;
            JournalScanner.ScanBaryCentreHandler += JournalScanner_ScanBaryCentreHandler;
            JournalScanner.MarketHandler += JournalScanner_MarketHandler;
            JournalScanner.StoredModulesHandler += JournalScanner_StoredModulesHandler;
            JournalScanner.CarrierJumpHandler += JournalScanner_CarrierJumpHandler;
            JournalScanner.SendTextHandler += JournalScanner_SendTextHandler;
            JournalScanner.LoadoutHandler += JournalScanner_LoadoutHandler;
            #endregion

            mjc.Hide();
        }

        private void ButtonSetCase_Click(object sender, EventArgs e)
        {
            string[] splits = Clipboard.GetText().Split('–');

            for (int i = 0; i < splits.Length; i++)
            {
                string tmpS = splits[i];
                string[] tmpA;
                switch (i)
                {
                    case 0:
                        tmpS = tmpS.Replace("RATSIGNAL Case #", "").Trim();
                        tmpA = tmpS.Split(' ');

                        if (int.TryParse(tmpA[0].Trim(), out int cn))
                            numericUpDownCaseNR.Value = cn;
                        else
                            numericUpDownCaseNR.Value = -1;

                        textBoxPlatform.Text = tmpA[1].Trim();
                        checkBoxCodeRed.Checked = tmpA.Length > 2;
                        break;
                    case 1:
                        textBoxClientName.Text = tmpS.Replace("CMDR", "").Trim();
                        break;
                    case 2:
                        tmpA = tmpS.Split('\"');
                        textBoxSystemName.Text = tmpA[1].Trim();
                        //landMark = tmpA[2].Replace("(","").Replace(")", "").Trim();
                        break;
                }
            }
        }

        private void ButtonClearCase_Click(object sender, EventArgs e)
        {
            textBoxSystemName.Text = "";
            textBoxClientName.Text = "";
            textBoxPlatform.Text = "";
            numericUpDownCaseNR.Value = -1;
            checkBoxCodeRed.Checked = false;
        }

        private void CheckBoxCodeRed_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxCodeRed.BackColor = checkBoxCodeRed.Checked ? Color.Red : checkBoxCodeRed.Parent.BackColor;
        }

        private void JournalScanner_LoadoutHandler(object? sender, EventArgs e)
        {
            JournalScanner.LoadoutEventArgs eArgs = (JournalScanner.LoadoutEventArgs)e;
        }

        private void JournalScanner_SendTextHandler(object? sender, EventArgs e)
        {
            JournalScanner.SendTextEventArgs eArgs = (JournalScanner.SendTextEventArgs)e;
            if (eArgs.FirstRun)
                return;

            string prefix = "/";
            string text = (eArgs.SendText.Value<string>("Message") ?? "").ToUpper();

            if (text.StartsWith(prefix) && text.Length > prefix.Length)
            {
                string sText = text.Substring(prefix.Length);
                string[] split = sText.Split(' ');

                string arg;
                switch (split[0])
                {
                    case "RANGE":
                        if (split.Length < 2)
                            return;

                        arg = split[1];
                        if (decimal.TryParse(arg, out decimal res))
                        {
                            numericUpDownJumpRange.Value = res;
                        }
                        break;
                    case "DEST":
                    case "DESTINATION":
                    case "TARGETSYSTEM":
                    case "TARGET":
                    case "SYSTEM":
                        if (split.Length < 2)
                            return;

                        arg = split[1];

                        textBoxTargetSystem.Text = sText.Substring(sText.IndexOf(' ')).Trim();
                        UpdateTravelPath(true);
                        break;
                    case "UPDATE":
                        UpdateTravelPath(true);
                        break;
                    case "TOP":
                        toolStripMenuItemTopMost.Checked = !toolStripMenuItemTopMost.Checked;
                        break;
                    //case "NEXT":
                    //    SetClipboard(1);
                    //    break;
                    //case "PREVIOUS":
                    //case "PREV":
                    //    SetClipboard(-1);
                    //    break;
                }
            }
        }

        private void ListView1_DoubleClick(object? sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                ListViewItem listViewItem = listView1.SelectedItems[0];
                JObject tag = (JObject)listViewItem.Tag;
                Clipboard.SetText(tag.Value<string>("system"));
            }
        }

        /// <summary>
        /// Fetch updated route from spansh
        /// </summary>
        private string _ranUpdateInSystem = "";
        private void UpdateTravelPath(bool force)
        {
            if (!force)
                if (string.IsNullOrEmpty(textBoxTargetSystem.Text) || string.IsNullOrWhiteSpace(textBoxTargetSystem.Text) || _ranUpdateInSystem.Equals(textBoxCurrentSystem.Text))
                    return;

            ButtonStartRoute_Click(this, new EventArgs());

            _ranUpdateInSystem = textBoxCurrentSystem.Text;
        }

        private void JournalScanner_CarrierJumpHandler(object? sender, EventArgs e)
        {
            if (e is JournalScanner.CarrierJumpEventArgs)
            {
                JObject j = ((JournalScanner.CarrierJumpEventArgs)e).CarrierJump;

                if (j != null)
                {
                    textBoxCurrentSystem.Text = j.Value<string>("StarSystem") ?? "[UNKNOWN]";
                }
            }
        }

        private void JournalScanner_StoredModulesHandler(object? sender, EventArgs e)
        {
            if (e is JournalScanner.StoredModulesEventArgs)
            {
                JObject j = ((JournalScanner.StoredModulesEventArgs)e).StoredModules;

                if (j != null)
                {
                    /*
                     * timestamp
                     * event
                     * MarketID
                     * StationName
                     * StarSystem
                     * Items
                     */
                    textBoxCurrentSystem.Text = j.Value<string>("StarSystem") ?? "[UNKNOWN]";
                }
            }
        }

        private void JournalScanner_MarketHandler(object? sender, EventArgs e)
        {
            if (e is JournalScanner.MarketEventArgs)
            {
                JObject j = ((JournalScanner.MarketEventArgs)e).Market;

                if (j != null)
                {
                    /*
                     * timestamp
                     * event
                     * WarketId
                     * StationName
                     * StationType
                     * StarSystem
                     */
                    textBoxCurrentSystem.Text = j.Value<string>("StarSystem") ?? "[UNKNOWN]";
                }
            }
        }

        private void JournalScanner_ScanBaryCentreHandler(object? sender, EventArgs e)
        {
            if (e is JournalScanner.ScanBaryCentreEventArgs)
            {
                JObject j = ((JournalScanner.ScanBaryCentreEventArgs)e).ScanBaryCentre;

                if (j != null)
                {
                    /*
                     * timestamp
                     * event
                     * StarSystem
                     * SystemAddress
                     * BodyID
                     * SemiMajorAxis
                     * Eccentricity
                     * OrbitalInclination
                     * Periapsis
                     * OrbitalPeriod
                     * AscendingNode
                     * MeanAnomaly
                     */
                    textBoxCurrentSystem.Text = j.Value<string>("StarSystem") ?? "[UNKNOWN]";
                }
            }
        }

        private void JournalScanner_ShipyardHandler(object? sender, EventArgs e)
        {
            if (e is JournalScanner.ShipyardEventArgs)
            {
                JObject j = ((JournalScanner.ShipyardEventArgs)e).Shipyard;

                if (j != null)
                {
                    /*
                     * timestamp
                     * event
                     * MarketID
                     * StationName
                     * StarSystem
                     */
                    textBoxCurrentSystem.Text = j.Value<string>("StarSystem") ?? "[UNKNOWN]";
                }
            }
        }

        private void JournalScanner_OutfittingHandler(object? sender, EventArgs e)
        {
            if (e is JournalScanner.OutfittingEventArgs)
            {
                JObject j = ((JournalScanner.OutfittingEventArgs)e).Outfitting;

                if (j != null)
                {
                    /*
                     * timestamp
                     * event
                     * MarketID
                     * StationName
                     * StarSystem
                     */
                    textBoxCurrentSystem.Text = j.Value<string>("StarSystem") ?? "[UNKNOWN]";
                }
            }
        }

        private void JournalScanner_StoredShipsHandler(object? sender, EventArgs e)
        {
            if (e is JournalScanner.StoredShipsEventArgs)
            {
                JObject j = ((JournalScanner.StoredShipsEventArgs)e).StoredShips;

                if (j != null)
                {
                    /*
                     * timestamp
                     * event
                     * StationName
                     * MarketID
                     * StarSystem
                     * ShipsHere
                     * ShipsRemote
                     */
                    textBoxCurrentSystem.Text = j.Value<string>("StarSystem") ?? "[UNKNOWN]";
                }
            }
        }

        private void JournalScanner_LocationHandler(object? sender, EventArgs e)
        {
            if (e is JournalScanner.LocationEventArgs)
            {
                JObject j = ((JournalScanner.LocationEventArgs)e).Location;

                if (j != null)
                {
                    /*
                     * timestamp
                     * event
                     * Docked
                     * StarSystem
                     * SystemAddress
                     * StarPos
                     * SystemAllegiance
                     * SystemEconomy
                     * SystemEconomy_Localised
                     * SystemSecondEconomy
                     * SystemSecondEconomy_Localised
                     * SystemGovernment
                     * SystemGovernment_Localised
                     * SystemSecurity
                     * SystemSecurity_Localised
                     * Population
                     * Body
                     * BodyID
                     * BodyType
                     */
                    textBoxCurrentSystem.Text = j.Value<string>("StarSystem") ?? "[UNKNOWN]";
                }
            }
        }

        private void JournalScanner_LeaveBodyHandler(object? sender, EventArgs e)
        {
            if (e is JournalScanner.LeaveBodyEventArgs)
            {
                JObject j = ((JournalScanner.LeaveBodyEventArgs)e).LeaveBody;

                if (j != null)
                {
                    textBoxCurrentSystem.Text = j.Value<string>("StarSystem") ?? "[UNKNOWN]";
                }
            }
        }

        private void JournalScanner_EmbarkHandler(object? sender, EventArgs e)
        {
            if (e is JournalScanner.EmbarkEventArgs)
            {
                JObject j = ((JournalScanner.EmbarkEventArgs)e).Embark;

                if (j != null)
                {
                    textBoxCurrentSystem.Text = j.Value<string>("StarSystem") ?? "[UNKNOWN]";
                }
            }
        }

        private void JournalScanner_DisembarkHandler(object? sender, EventArgs e)
        {
            if (e is JournalScanner.DisembarkEventArgs)
            {
                JObject j = ((JournalScanner.DisembarkEventArgs)e).Disembark;

                if (j != null)
                {
                    textBoxCurrentSystem.Text = j.Value<string>("StarSystem") ?? "[UNKNOWN]";
                }
            }
        }

        private void JournalScanner_LiftoffHandler(object? sender, EventArgs e)
        {
            if (e is JournalScanner.LiftoffEventArgs)
            {
                JObject j = ((JournalScanner.LiftoffEventArgs)e).Liftoff;

                if (j != null)
                {
                    textBoxCurrentSystem.Text = j.Value<string>("StarSystem") ?? "[UNKNOWN]";
                }
            }
        }

        private void JournalScanner_TouchdownHandler(object? sender, EventArgs e)
        {
            if (e is JournalScanner.TouchdownEventArgs)
            {
                JObject j = ((JournalScanner.TouchdownEventArgs)e).Touchdown;

                if (j != null)
                {
                    textBoxCurrentSystem.Text = j.Value<string>("StarSystem") ?? "[UNKNOWN]";
                }
            }
        }

        private void JournalScanner_ApproachBodyHandler(object? sender, EventArgs e)
        {
            if (e is JournalScanner.ApproachBodyEventArgs)
            {
                JObject j = ((JournalScanner.ApproachBodyEventArgs)e).ApproachBody;

                if (j != null)
                {
                    /*
                     * {
  "timestamp": "2022-01-14T19:59:02Z",
  "event": "ApproachBody",
  "StarSystem": "Arangorii",
  "SystemAddress": 7230745219802,
  "Body": "Arangorii B 1",
  "BodyID": 50
}
                     */
                    textBoxCurrentSystem.Text = j.Value<string>("StarSystem") ?? "[UNKNOWN]";
                }
            }
        }

        private void JournalScanner_SupercruiseEntryHandler(object? sender, EventArgs e)
        {
            if (e is JournalScanner.SupercruiseEntryEventArgs)
            {
                JObject j = ((JournalScanner.SupercruiseEntryEventArgs)e).SupercruiseEntry;

                if (j != null)
                {
                    /*
                     * timestamp
                     * event
                     * StarSystem
                     * SystemAddress
                     */
                    textBoxCurrentSystem.Text = j.Value<string>("StarSystem") ?? "[UNKNOWN]";
                }
            }
        }

        private void JournalScanner_SupercruiseExitHandler(object? sender, EventArgs e)
        {
            if (e is JournalScanner.SupercruiseExitEventArgs)
            {
                JObject j = ((JournalScanner.SupercruiseExitEventArgs)e).SupercruiseExit;

                if (j != null)
                {
                    /*
                     * timestamp
                     * event
                     * Taxi
                     * Multicrew
                     * StarSystem
                     * SystemAddress
                     * Body
                     * BodyID
                     * BodyType
                     */
                    textBoxCurrentSystem.Text = j.Value<string>("StarSystem") ?? "[UNKNOWN]";
                }
            }
        }

        private void JournalScanner_FSDJumpHandler(object? sender, EventArgs e)
        {
            if (e is JournalScanner.FSDJumpEventArgs)
            {
                JObject j = ((JournalScanner.FSDJumpEventArgs)e).FSDJump;

                if (j != null)
                {
                    /*
                     * timestamp
                     * event
                     * Taxi
                     * Multicrew
                     * StarSystem
                     * SystemAddress
                     * StarPos
                     * SystemAllegiance
                     * SystemEconomy
                     * SystemEconomy_Localised
                     * SystemGovernment
                     * SystemGovernment_Localised
                     * SystemSecurity
                     * SystemSecurity_Localised
                     * Population
                     * Body
                     * BodyID
                     * BodyType
                     * JumpDist
                     * FuelUsed
                     * FuelLevel
                     */
                    textBoxCurrentSystem.Text = j.Value<string>("StarSystem") ?? "[UNKNOWN]";
                }
            }
        }

        private void JournalScanner_ScanHandler(object? sender, EventArgs e)
        {
            if (e is JournalScanner.ScanEventArgs)
            {
                JObject j = ((JournalScanner.ScanEventArgs)e).Scan;

                if (j != null)
                {
                    /*
                     * timestamp
                     * event
                     * ScanType
                     * BodyName
                     * BodyID
                     * Parents
                     * StarSystem
                     * SystemAddress
                     * DistanceFromArrivalLS
                     * WasDiscovered
                     * WasMapped
                     */
                    textBoxCurrentSystem.Text = j.Value<string>("StarSystem") ?? "[UNKNOWN]";
                }
            }
        }

        private void JournalScanner_DockedHandler(object? sender, EventArgs e)
        {
            if (e is JournalScanner.DockedEventArgs)
            {
                JObject j = ((JournalScanner.DockedEventArgs)e).Docked;

                if (j != null)
                {
                    /*
                     * timestamp
                     * event
                     * StationName
                     * StationType
                     * Taxi
                     * Multicrew
                     * StarSystem
                     * SystemAddress
                     * MarketID
                     * StationFaction
                     * StationGovernment
                     * StationGovernment_Localised
                     * StationAllegiance
                     * StationServices
                     * StationEconomy
                     * StationEconomy_Localised
                     * StationEconomies
                     * DistFromStarLS
                     * LandingPads
                     */
                    textBoxCurrentSystem.Text = j.Value<string>("StarSystem") ?? "[UNKNOWN]";
                }
            }
        }

        private void ButtonStartRoute_Click(object sender, EventArgs e)
        {
            if (JournalScanner.FirstRun)
                return;

            mjc.Show();
            _delayedUpdate.Enabled = false;
            JToken jToken;
            try
            {
                jToken = NeutronRouterAPI.GetNewRoute(textBoxCurrentSystem.Text, textBoxTargetSystem.Text, numericUpDownJumpRange.Value, 60);
            }
            catch (Exception ex)
            {
                Type t = ex.GetType();

                if (t == typeof(InvalidEndSystemException))
                {
                    MessageBox.Show("Invalid system", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (t == typeof(InvalidStartSystemException))
                {
                    textBoxCurrentSystem.BackColor = Color.Green;
                    textBoxCurrentSystem.ForeColor = Color.White;
                    _delayedUpdate.Enabled = true;
                    return;
                }
                else
                    throw;
            }

            listView1.Items.Clear();
            bool skipFirst = true;
            bool nextRouteCopied = false;
            uint totalJumps = 0;
            JArray list = jToken.Value<JArray>("system_jumps") ?? new();
            for (int i = 0; i < list.Count; i++)
            {
                JObject j = (JObject)list[i];
                totalJumps += j.Value<uint>("jumps");

                if (skipFirst)
                {
                    skipFirst = false;
                    continue;
                }

                string[] subItems = new string[]
                {
                    j.Value<string>("system"),
                    MakeNumberSmaller(j.Value<decimal>("distance_jumped")),
                    MakeNumberSmaller(j.Value<decimal>("distance_left")),
                    j.Value<string>("jumps"),
                    j.Value<string>("neutron_star")
                };

                ListViewItem lvi = new ListViewItem(subItems);
                if ((!nextRouteCopied && i == list.Count - 1) || (!nextRouteCopied && j.Value<decimal>("distance_jumped") > 100))
                {
                    Clipboard.SetText(subItems[0]);
                    nextRouteCopied = true;
                    lvi.BackColor = Color.Green;
                    lvi.ForeColor = Color.White;
                }

                //if (copySecond)
                //{
                //    Clipboard.SetText(subItems[0]);
                //    copySecond = false;
                //}

                ListViewItem listViewItem = listView1.Items.Add(lvi);
                listViewItem.Tag = j;
            }
            this.Text = $"Route Plotter | {totalJumps} jumps left";
            mjc.Hide();
        }

        private string MakeNumberSmaller(decimal v)
        {
            string[] sizeSuffix = { "Ly", "kLy", "mLy", "gLy" };

            int places = 0;
            while (v > 1000)
            {
                v = v / 1000;
                places++;
            }

            return $"{v:0.00}{sizeSuffix[places]}";
        }

        private void TopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = toolStripMenuItemTopMost.Checked;
        }

        private void UpdateTravelPath(object sender, EventArgs e)
        {
            UpdateTravelPath(true);
        }

        private void DelayedUpdateTick(object? sender, EventArgs e)
        {
            ButtonStartRoute_Click(sender, e);
        }
    }
}