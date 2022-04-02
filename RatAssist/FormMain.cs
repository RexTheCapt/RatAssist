using System.Diagnostics;

using EDNeutronRouterPlugin;
using EDNeutronRouterPlugin.Exceptions;

using EdTools;

using Newtonsoft.Json.Linq;

namespace RatAssist
{
    public partial class FormMain : Form
    {
        private MessageJumpCalculation mjc;
        internal JournalScanner JournalScanner { get; private set; }
        public static readonly string JournalPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\Saved Games\\Frontier Developments\\Elite Dangerous";
        private readonly System.Windows.Forms.Timer delayedUpdate;
        private readonly System.Windows.Forms.Timer scanJournal;
        private bool RatMode
        {
            get
            {
                if (!File.Exists("ratmode"))
                    return false;
                using (StreamReader sr = new("ratmode"))
                    return sr.ReadLine().Equals("yes");
            }
            set
            {
                using (StreamWriter sw = new("ratmode"))
                    sw.WriteLine(value? "yes" : "no");
            }
        }
        private List<ToolStripMenuItem> quickSelectItems = new();
        private DateTime quickSelectTimestamp = DateTime.MinValue;
        private decimal fuelMax;
        private decimal fuelLevel;
        private Panel panelFuelLevelForeground;

        public FormMain()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.Rat_Spansh_Tool1;

            SetRatMode(RatMode);
            #region Make fuel foreground control
            Panel p = new Panel();
            p.Location = panelFuelLevelBackground.Location;
            p.Size = panelFuelLevelBackground.Size;
            p.BackColor = Color.Green;
            groupBoxUserInfo.Controls.Add(p);
            panelFuelLevelForeground = p;
            p.BringToFront();
            #endregion

            mjc = new()
            {
                Background = panelMessageBackground,
                Foreground = labelMessageForeground,
                Form = this
            };

            delayedUpdate = new System.Windows.Forms.Timer()
            {
                Enabled = false,
                Interval = 1000,
            };
            delayedUpdate.Tick += DelayedUpdateTick;

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
            JournalScanner.LoadGameHandler += JournalScanner_LoadGameHandler;
            JournalScanner.RefuelAllHandler += JournalScanner_RefuelAllHandler;
            JournalScanner.ReservoirReplenishedHandler += JournalScanner_ReservoirReplenishedHandler;
            JournalScanner.FuelScoopHandler += JournalScanner_FuelScoopHandler;
            #endregion

            scanJournal = new()
            {
                Enabled = true,
                Interval = 100
            };
            scanJournal.Tick += ScanJournal_Tick;

            mjc.Hide();
        }

        private void JournalScanner_FuelScoopHandler(object? sender, EventArgs e)
        {
            /*
             * timestamp
             * event
             * Scooped
             * Total
             */
            JournalScanner.FuelScoopEventArgs eArgs = (JournalScanner.FuelScoopEventArgs)e;
            JObject fuelScoop = eArgs.FuelScoop;

            fuelLevel = fuelScoop.Value<decimal>("Total");

            FuelAlert();
        }

        private void JournalScanner_ReservoirReplenishedHandler(object? sender, EventArgs e)
        {
            /*
             * timestamp
             * event
             * FuelMain
             * FuelReservoir
             */
            JournalScanner.ReservoirReplenishedEventArgs eArgs = (JournalScanner.ReservoirReplenishedEventArgs)e;
            JObject reservoirReplenished = eArgs.ReservoirReplenished;

            fuelLevel = reservoirReplenished.Value<decimal>("FuelMain");

            FuelAlert();
        }

        private void FuelAlert()
        {
            if (fuelLevel == 0 || fuelMax == 0) return;

            decimal prcnt = (fuelLevel / fuelMax);

            int width = panelFuelLevelBackground.Width;
            panelFuelLevelForeground.Width = (int)((decimal)width * prcnt);

            if (prcnt * 100 < 25)
                timerFuelAlert.Enabled = true;
            else if (timerFuelAlert.Enabled)
            {
                timerFuelAlert.Enabled = false;
                panelMessageBackground.Visible = false;
                panelMessageBackground.Click += null;
                labelMessageForeground.Click += null;
            }
        }

        private void JournalScanner_RefuelAllHandler(object? sender, EventArgs e)
        {
            /*
             * RefuelAll
             * Cost
             * Amount
             */
            JournalScanner.RefuelAllEventArgs eArgs = (JournalScanner.RefuelAllEventArgs)e;
            JObject refuelAll = eArgs.RefuelAll;

            fuelLevel += refuelAll.Value<decimal>("Amount");

            FuelAlert();
        }

        private void JournalScanner_LoadGameHandler(object? sender, EventArgs e)
        {
            /*
             * timestamp
             * event
             * FID
             * Commander
             * Horizons
             * Ship
             * Ship_Localised
             * ShipID
             * ShipName
             * ShipIdent
             * FuelLevel
             * FuelCapacity
             * GameMode
             * Credits
             * Loan
             */
            JournalScanner.LoadGameEventArgs eArgs = (JournalScanner.LoadGameEventArgs)e;

            JObject loadGame = eArgs.LoadGame;

            fuelMax = loadGame.Value<decimal>("FuelCapacity");
            fuelLevel = loadGame.Value<decimal>("FuelLevel");

            FuelAlert();
        }

        private void ScanJournal_Tick(object? sender, EventArgs e)
        {
            JournalScanner.TimerScan(true);
        }

        private void ButtonSetCase_Click(object sender, EventArgs e)
        {
            string[] splits = Clipboard.GetText().Split('–');

            if (splits.Length != 1)
            {
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
                            textBoxClientSystemName.Text = tmpA[1].Trim();
                            //landMark = tmpA[2].Replace("(","").Replace(")", "").Trim();
                            break;
                    }
                }
            }
            else
            {
                splits = Clipboard.GetText().Replace(" - ", "|").Split('|');

                try
                {
                    textBoxClientName.Text = splits[0].Split(':')[1].Trim();
                    textBoxClientSystemName.Text = splits[1].Split(':')[1].Trim();
                    textBoxPlatform.Text = splits[2].Split(':')[1].Trim();
                    checkBoxCodeRed.Checked = splits[3].Split(':')[1].Trim().Equals("NOT OK");
                    string language = splits[4].Split(':')[1].Trim();
                    string ircNick;

                    if (splits.Length > 5)
                        ircNick = splits[5].Split(':')[1].Trim();
                }
                catch
                {
                    ButtonClearCase_Click(this, null);
                    return;
                }
            }

            ButtonSetClientTargetSystem(sender, e);
        }

        private void ButtonClearCase_Click(object sender, EventArgs e)
        {
            textBoxClientSystemName.Text = "";
            textBoxClientName.Text = "";
            textBoxPlatform.Text = "";
            numericUpDownCaseNR.Value = 0;
            checkBoxCodeRed.Checked = false;
            radioButtonDisable.Checked = true;
        }

        private void CheckBoxCodeRed_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxCodeRed.BackColor = checkBoxCodeRed.Checked ? Color.Red : checkBoxCodeRed.Parent.BackColor;
        }

        private void JournalScanner_LoadoutHandler(object? sender, EventArgs e)
        {
            /*
             * timestamp
             * event
             * Ship
             * ShipID
             * ShipName
             * ShipIdent
             * HullValue
             * ModulesValue
             * HullHealth
             * UnladenMass
             * CargoCapacity
             * MaxJumpRange
             * FuelCapacity
             * Rebuy
             * Modules
             */

            JournalScanner.LoadoutEventArgs eArgs = (JournalScanner.LoadoutEventArgs)e;

            JObject? jObject = eArgs.Loadout.Value<JObject>("FuelCapacity");
            fuelMax = jObject.Value<decimal>("Main");

            FuelAlert();
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
            if (listViewJumpList.SelectedItems.Count == 1)
            {
                ListViewItem listViewItem = listViewJumpList.SelectedItems[0];
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

            RadioButton rb;

            if (radioButtonDisable.Checked)
                return;
            else if (radioButtonUseClient.Checked)
                RadioSetRouteMode(radioButtonUseClient, new EventArgs());
            else if (radioButtonUseUser.Checked)
                RadioSetRouteMode(radioButtonUseUser, new EventArgs());
            else
                throw new Exception("Invalid route setting");

            _ranUpdateInSystem = textBoxCurrentSystem.Text;
        }

        private void JournalScanner_CarrierJumpHandler(object? sender, EventArgs e)
        {
            JournalScanner.CarrierJumpEventArgs eArgs = (JournalScanner.CarrierJumpEventArgs)e;
            JObject carrierJump = eArgs.CarrierJump;
            textBoxCurrentSystem.Text = carrierJump.Value<string>("StarSystem") ?? "[UNKNOWN]";
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
                    fuelLevel = j.Value<decimal>("FuelLevel");
                }
            }

            FuelAlert();
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
            delayedUpdate.Enabled = false;
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
                    delayedUpdate.Enabled = true;
                    return;
                }
                else
                    throw;
            }

            listViewJumpList.Items.Clear();
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

                ListViewItem listViewItem = listViewJumpList.Items.Add(lvi);
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

        private void RadioSetRouteMode(object sender, EventArgs e)
        {
            if (radioButtonDisable.Checked)
                return;

            RadioButton rb = (RadioButton)sender;
            string tag = (string)rb.Tag;
            string targetSystem;

            if (tag.Equals("Client"))
                targetSystem = textBoxClientSystemName.Text;
            else if (tag.Equals("User"))
                targetSystem = textBoxTargetSystem.Text;
            else
                throw new Exception("Unknown radio tag");

            JToken jToken;
            mjc.Show();

            try
            {
                jToken = NeutronRouterAPI.GetNewRoute(textBoxCurrentSystem.Text, targetSystem, numericUpDownJumpRange.Value, 60);
            }
            catch (Exception ex)
            {
                mjc.Error();
                Type t = ex.GetType();

                if (t == typeof(InvalidEndSystemException))
                {
                    MessageBox.Show("Invalid system", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (t == typeof(InvalidStartSystemException))
                {
                    //textBoxCurrentSystem.BackColor = Color.Green;
                    //textBoxCurrentSystem.ForeColor = Color.White;
                    delayedUpdate.Enabled = true;
                    return;
                }
                else
                    //throw;
                    return;
            }

            listViewJumpList.Items.Clear();
            bool skipFirst = true;
            bool nextRouteCopied = false;
            uint totalJumps = 0;
            decimal firstDistanceLeft = 0;
            JArray list = jToken.Value<JArray>("system_jumps") ?? new();
            for (int i = 0; i < list.Count; i++)
            {
                JObject j = (JObject)list[i];
                totalJumps += j.Value<uint>("jumps");

                if (skipFirst)
                {
                    skipFirst = false;
                    firstDistanceLeft = j.Value<decimal>("distance_left");
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
                //if ((!nextRouteCopied && i == list.Count - 1) || (!nextRouteCopied && firstDistanceLeft - j.Value<decimal>("distance_left") > numericUpDownJumpRange.Value * 4))
                if (!nextRouteCopied)
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

                ListViewItem listViewItem = listViewJumpList.Items.Add(lvi);
                listViewItem.Tag = j;
            }
            mjc.Hide();
        }

        private void RadioDisableRoute(object sender, EventArgs e)
        {

        }

        private void ButtonSetUserSystem(object sender, EventArgs e)
        {
            radioButtonUseUser.Checked = true;
            RadioSetRouteMode(radioButtonUseUser, new EventArgs());
        }

        private void ButtonSetClientTargetSystem(object sender, EventArgs e)
        {
            radioButtonUseClient.Checked = true;
            RadioSetRouteMode(radioButtonUseClient, new EventArgs());
        }

        private void toggleRatModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RatMode = !RatMode;
            SetRatMode(RatMode);
        }

        private void SetRatMode(bool rm)
        {
            if (rm)
                radioButtonDisable.Checked = true;
            else
                radioButtonUseUser.Checked = true;

            groupBoxCaseInfo.Visible = rm;
            groupBoxRouteMode.Visible = rm;

            groupBoxUserInfo.Location = rm ? new(5, 235) : new(5, 30);
            groupBoxUserInfo.Width = rm ? 216 : groupBoxSpansh.Width;

            listViewJumpList.Location = rm ? new(5, 70) : new(5, 16);
            listViewJumpList.Height = rm ? 252 : 150;
            groupBoxSpansh.Height = rm ? listViewJumpList.Height + listViewJumpList.Location.Y + 6 : listViewJumpList.Height + listViewJumpList.Location.Y + 5;
            groupBoxSpansh.Location = rm ? new(227, 30) : new(5, groupBoxUserInfo.Height + 5 + groupBoxUserInfo.Location.Y);
            panelMessageBackground.Location = new(5, listViewJumpList.Location.Y + listViewJumpList.Height - panelMessageBackground.Height - 10);
            //panelMessageBackground.Location = rm ? new(5, 269) : new Point(5, 269 - 54);

            this.Size = new Size(groupBoxSpansh.Location.X + groupBoxSpansh.Width + 20, groupBoxSpansh.Location.Y + groupBoxSpansh.Height + 45);

            FuelAlert();
        }

        private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string qsf = "quickselect.txt";
            if (!File.Exists(qsf))
                using (StreamWriter sw = new(qsf))
                    sw.WriteLine("# Please write a single star system per line\n" +
                                 "# use # to comment out lines.\n" +
                                 "# Keep in mind it can take about 10 seconds to update the quick select list.");

            Process.Start("notepad.exe", Path.GetFullPath(qsf));
        }

        private void timerUpdateQuickSelect_Tick(object sender, EventArgs e)
        {
            string qsf = "quickselect.txt";
            DateTime lastWriteTime = (new FileInfo(qsf)).LastWriteTime;

            if (File.Exists(qsf) && lastWriteTime > quickSelectTimestamp)
            {
                for (int i = quickSelectItems.Count - 1; i >= 0; i--)
                {
                    ToolStripMenuItem sys = quickSelectItems[i];
                    quickSelectItems.Remove(sys);
                    sys.Dispose();
                }

                quickSelectItems.Clear();

                using (StreamReader sr = new(qsf))
                    while (!sr.EndOfStream)
                    {
                        string? line = sr.ReadLine();
                        if (line == null) continue;
                        if (line.StartsWith("#")) continue;
                        if (line.Length == 0) continue;

                        ToolStripMenuItem mi = new ToolStripMenuItem();
                        mi.Text = line;
                        mi.Click += QuickTarget;
                        quickSelectItems.Add(mi);
                        quickSelectToolStripMenuItem.DropDownItems.Add(mi);
                    }

                quickSelectTimestamp = lastWriteTime;
            }
        }

        private void QuickTarget(object? sender, EventArgs e)
        {
            if (sender == null) return;
            ToolStripMenuItem? mi = (ToolStripMenuItem)sender;
            
            if (mi == null) return;

            textBoxTargetSystem.Text = mi.Text;
            radioButtonUseUser.Checked = true;
        }

        private void timerFuelAlert_Tick(object sender, EventArgs e)
        {
            panelMessageBackground.Visible = true;
            labelMessageForeground.Visible = true;

            panelMessageBackground.BackColor = panelMessageBackground.BackColor == Color.Yellow ? Color.Black : Color.Yellow;

            labelMessageForeground.BackColor = panelMessageBackground.BackColor == Color.Black ? Color.Black : Color.Yellow;
            labelMessageForeground.ForeColor = panelMessageBackground.BackColor == Color.Yellow ? Color.Black : Color.Yellow;

            labelMessageForeground.Text = "WARNING FUEL LEVEL LOW, CLICK ME TO CALL FUELRATS";

            labelMessageForeground.Click += CallFuelRats;
            panelMessageBackground.Click += CallFuelRats;

            fuelratsOpened = false;
        }

        bool fuelratsOpened = false;
        private void CallFuelRats(object? sender, EventArgs e)
        {
            if (fuelratsOpened) return;

            var uri = "https://fuelrats.com";
            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = uri;
            System.Diagnostics.Process.Start(psi);

            fuelratsOpened = true;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout about = new FormAbout();
            about.Show();
        }
    }
}