namespace RatAssist
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxClientName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownCaseNR = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPlatform = new System.Windows.Forms.TextBox();
            this.checkBoxCodeRed = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxClientSystemName = new System.Windows.Forms.TextBox();
            this.groupBoxCaseInfo = new System.Windows.Forms.GroupBox();
            this.buttonSetClientTargetSystem = new System.Windows.Forms.Button();
            this.buttonClearCase = new System.Windows.Forms.Button();
            this.groupBoxUserInfo = new System.Windows.Forms.GroupBox();
            this.panelFuelLevelBackground = new System.Windows.Forms.Panel();
            this.buttonSetUserSystem = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxTargetSystem = new System.Windows.Forms.TextBox();
            this.numericUpDownJumpRange = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxCurrentSystem = new System.Windows.Forms.TextBox();
            this.groupBoxSpansh = new System.Windows.Forms.GroupBox();
            this.panelMessageBackground = new System.Windows.Forms.Panel();
            this.labelMessageForeground = new System.Windows.Forms.Label();
            this.groupBoxRouteMode = new System.Windows.Forms.GroupBox();
            this.radioButtonDisable = new System.Windows.Forms.RadioButton();
            this.radioButtonUseUser = new System.Windows.Forms.RadioButton();
            this.radioButtonUseClient = new System.Windows.Forms.RadioButton();
            this.listViewJumpList = new System.Windows.Forms.ListView();
            this.columnHeaderSystem = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderJumped = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderLeft = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderJumps = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderNeutron = new System.Windows.Forms.ColumnHeader();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTopMost = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleRatModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quickSelectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eDITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerUpdateQuickSelect = new System.Windows.Forms.Timer(this.components);
            this.timerFuelAlert = new System.Windows.Forms.Timer(this.components);
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCaseNR)).BeginInit();
            this.groupBoxCaseInfo.SuspendLayout();
            this.groupBoxUserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownJumpRange)).BeginInit();
            this.groupBoxSpansh.SuspendLayout();
            this.panelMessageBackground.SuspendLayout();
            this.groupBoxRouteMode.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Set case";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ButtonSetCase_Click);
            // 
            // textBoxClientName
            // 
            this.textBoxClientName.Location = new System.Drawing.Point(93, 84);
            this.textBoxClientName.Name = "textBoxClientName";
            this.textBoxClientName.Size = new System.Drawing.Size(113, 23);
            this.textBoxClientName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Client name:";
            // 
            // numericUpDownCaseNR
            // 
            this.numericUpDownCaseNR.Location = new System.Drawing.Point(93, 130);
            this.numericUpDownCaseNR.Name = "numericUpDownCaseNR";
            this.numericUpDownCaseNR.Size = new System.Drawing.Size(113, 23);
            this.numericUpDownCaseNR.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Case NR:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Platform:";
            // 
            // textBoxPlatform
            // 
            this.textBoxPlatform.Location = new System.Drawing.Point(93, 107);
            this.textBoxPlatform.Name = "textBoxPlatform";
            this.textBoxPlatform.Size = new System.Drawing.Size(113, 23);
            this.textBoxPlatform.TabIndex = 5;
            // 
            // checkBoxCodeRed
            // 
            this.checkBoxCodeRed.AutoSize = true;
            this.checkBoxCodeRed.Location = new System.Drawing.Point(93, 153);
            this.checkBoxCodeRed.Name = "checkBoxCodeRed";
            this.checkBoxCodeRed.Size = new System.Drawing.Size(77, 19);
            this.checkBoxCodeRed.TabIndex = 7;
            this.checkBoxCodeRed.Text = "Code Red";
            this.checkBoxCodeRed.UseVisualStyleBackColor = true;
            this.checkBoxCodeRed.CheckedChanged += new System.EventHandler(this.CheckBoxCodeRed_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "System name:";
            // 
            // textBoxClientSystemName
            // 
            this.textBoxClientSystemName.Location = new System.Drawing.Point(93, 61);
            this.textBoxClientSystemName.Name = "textBoxClientSystemName";
            this.textBoxClientSystemName.Size = new System.Drawing.Size(113, 23);
            this.textBoxClientSystemName.TabIndex = 8;
            // 
            // groupBoxCaseInfo
            // 
            this.groupBoxCaseInfo.BackColor = System.Drawing.Color.Gray;
            this.groupBoxCaseInfo.Controls.Add(this.buttonSetClientTargetSystem);
            this.groupBoxCaseInfo.Controls.Add(this.buttonClearCase);
            this.groupBoxCaseInfo.Controls.Add(this.button1);
            this.groupBoxCaseInfo.Controls.Add(this.label4);
            this.groupBoxCaseInfo.Controls.Add(this.textBoxClientName);
            this.groupBoxCaseInfo.Controls.Add(this.textBoxClientSystemName);
            this.groupBoxCaseInfo.Controls.Add(this.label1);
            this.groupBoxCaseInfo.Controls.Add(this.checkBoxCodeRed);
            this.groupBoxCaseInfo.Controls.Add(this.numericUpDownCaseNR);
            this.groupBoxCaseInfo.Controls.Add(this.label3);
            this.groupBoxCaseInfo.Controls.Add(this.label2);
            this.groupBoxCaseInfo.Controls.Add(this.textBoxPlatform);
            this.groupBoxCaseInfo.Location = new System.Drawing.Point(5, 30);
            this.groupBoxCaseInfo.Name = "groupBoxCaseInfo";
            this.groupBoxCaseInfo.Size = new System.Drawing.Size(216, 200);
            this.groupBoxCaseInfo.TabIndex = 10;
            this.groupBoxCaseInfo.TabStop = false;
            this.groupBoxCaseInfo.Text = "Case info";
            // 
            // buttonSetClientTargetSystem
            // 
            this.buttonSetClientTargetSystem.Location = new System.Drawing.Point(6, 172);
            this.buttonSetClientTargetSystem.Name = "buttonSetClientTargetSystem";
            this.buttonSetClientTargetSystem.Size = new System.Drawing.Size(200, 23);
            this.buttonSetClientTargetSystem.TabIndex = 11;
            this.buttonSetClientTargetSystem.Text = "Set target system";
            this.buttonSetClientTargetSystem.UseVisualStyleBackColor = true;
            this.buttonSetClientTargetSystem.Click += new System.EventHandler(this.ButtonSetClientTargetSystem);
            // 
            // buttonClearCase
            // 
            this.buttonClearCase.Location = new System.Drawing.Point(6, 38);
            this.buttonClearCase.Name = "buttonClearCase";
            this.buttonClearCase.Size = new System.Drawing.Size(200, 23);
            this.buttonClearCase.TabIndex = 10;
            this.buttonClearCase.Text = "Clear case";
            this.buttonClearCase.UseVisualStyleBackColor = true;
            this.buttonClearCase.Click += new System.EventHandler(this.ButtonClearCase_Click);
            // 
            // groupBoxUserInfo
            // 
            this.groupBoxUserInfo.BackColor = System.Drawing.Color.Gray;
            this.groupBoxUserInfo.Controls.Add(this.panelFuelLevelBackground);
            this.groupBoxUserInfo.Controls.Add(this.buttonSetUserSystem);
            this.groupBoxUserInfo.Controls.Add(this.label7);
            this.groupBoxUserInfo.Controls.Add(this.textBoxTargetSystem);
            this.groupBoxUserInfo.Controls.Add(this.numericUpDownJumpRange);
            this.groupBoxUserInfo.Controls.Add(this.label6);
            this.groupBoxUserInfo.Controls.Add(this.label5);
            this.groupBoxUserInfo.Controls.Add(this.textBoxCurrentSystem);
            this.groupBoxUserInfo.Location = new System.Drawing.Point(5, 235);
            this.groupBoxUserInfo.Name = "groupBoxUserInfo";
            this.groupBoxUserInfo.Size = new System.Drawing.Size(216, 123);
            this.groupBoxUserInfo.TabIndex = 11;
            this.groupBoxUserInfo.TabStop = false;
            this.groupBoxUserInfo.Text = "User info";
            // 
            // panelFuelLevelBackground
            // 
            this.panelFuelLevelBackground.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFuelLevelBackground.BackColor = System.Drawing.Color.IndianRed;
            this.panelFuelLevelBackground.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelFuelLevelBackground.Location = new System.Drawing.Point(3, 84);
            this.panelFuelLevelBackground.Name = "panelFuelLevelBackground";
            this.panelFuelLevelBackground.Size = new System.Drawing.Size(211, 10);
            this.panelFuelLevelBackground.TabIndex = 14;
            // 
            // buttonSetUserSystem
            // 
            this.buttonSetUserSystem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetUserSystem.Location = new System.Drawing.Point(7, 94);
            this.buttonSetUserSystem.Name = "buttonSetUserSystem";
            this.buttonSetUserSystem.Size = new System.Drawing.Size(200, 23);
            this.buttonSetUserSystem.TabIndex = 12;
            this.buttonSetUserSystem.Text = "Set target system";
            this.buttonSetUserSystem.UseVisualStyleBackColor = true;
            this.buttonSetUserSystem.Click += new System.EventHandler(this.ButtonSetUserSystem);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Target sys:";
            // 
            // textBoxTargetSystem
            // 
            this.textBoxTargetSystem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTargetSystem.Location = new System.Drawing.Point(93, 61);
            this.textBoxTargetSystem.Name = "textBoxTargetSystem";
            this.textBoxTargetSystem.Size = new System.Drawing.Size(113, 23);
            this.textBoxTargetSystem.TabIndex = 12;
            // 
            // numericUpDownJumpRange
            // 
            this.numericUpDownJumpRange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownJumpRange.DecimalPlaces = 2;
            this.numericUpDownJumpRange.Location = new System.Drawing.Point(94, 38);
            this.numericUpDownJumpRange.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownJumpRange.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownJumpRange.Name = "numericUpDownJumpRange";
            this.numericUpDownJumpRange.Size = new System.Drawing.Size(111, 23);
            this.numericUpDownJumpRange.TabIndex = 10;
            this.numericUpDownJumpRange.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Jump range:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Current sys:";
            // 
            // textBoxCurrentSystem
            // 
            this.textBoxCurrentSystem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCurrentSystem.Location = new System.Drawing.Point(93, 15);
            this.textBoxCurrentSystem.Name = "textBoxCurrentSystem";
            this.textBoxCurrentSystem.ReadOnly = true;
            this.textBoxCurrentSystem.Size = new System.Drawing.Size(113, 23);
            this.textBoxCurrentSystem.TabIndex = 10;
            this.textBoxCurrentSystem.TextChanged += new System.EventHandler(this.UpdateTravelPath);
            // 
            // groupBoxSpansh
            // 
            this.groupBoxSpansh.BackColor = System.Drawing.Color.Gray;
            this.groupBoxSpansh.Controls.Add(this.panelMessageBackground);
            this.groupBoxSpansh.Controls.Add(this.groupBoxRouteMode);
            this.groupBoxSpansh.Controls.Add(this.listViewJumpList);
            this.groupBoxSpansh.Location = new System.Drawing.Point(227, 30);
            this.groupBoxSpansh.Name = "groupBoxSpansh";
            this.groupBoxSpansh.Size = new System.Drawing.Size(378, 328);
            this.groupBoxSpansh.TabIndex = 12;
            this.groupBoxSpansh.TabStop = false;
            this.groupBoxSpansh.Text = "Spansh";
            // 
            // panelMessageBackground
            // 
            this.panelMessageBackground.BackColor = System.Drawing.Color.Gray;
            this.panelMessageBackground.Controls.Add(this.labelMessageForeground);
            this.panelMessageBackground.Location = new System.Drawing.Point(6, 269);
            this.panelMessageBackground.Name = "panelMessageBackground";
            this.panelMessageBackground.Size = new System.Drawing.Size(364, 29);
            this.panelMessageBackground.TabIndex = 15;
            // 
            // labelMessageForeground
            // 
            this.labelMessageForeground.AutoSize = true;
            this.labelMessageForeground.Location = new System.Drawing.Point(8, 7);
            this.labelMessageForeground.Name = "labelMessageForeground";
            this.labelMessageForeground.Size = new System.Drawing.Size(112, 15);
            this.labelMessageForeground.TabIndex = 10;
            this.labelMessageForeground.Text = "Calculating jumps...";
            // 
            // groupBoxRouteMode
            // 
            this.groupBoxRouteMode.Controls.Add(this.radioButtonDisable);
            this.groupBoxRouteMode.Controls.Add(this.radioButtonUseUser);
            this.groupBoxRouteMode.Controls.Add(this.radioButtonUseClient);
            this.groupBoxRouteMode.Location = new System.Drawing.Point(6, 16);
            this.groupBoxRouteMode.Name = "groupBoxRouteMode";
            this.groupBoxRouteMode.Size = new System.Drawing.Size(364, 48);
            this.groupBoxRouteMode.TabIndex = 8;
            this.groupBoxRouteMode.TabStop = false;
            this.groupBoxRouteMode.Text = "Route to:";
            // 
            // radioButtonDisable
            // 
            this.radioButtonDisable.AutoSize = true;
            this.radioButtonDisable.Checked = true;
            this.radioButtonDisable.Location = new System.Drawing.Point(6, 22);
            this.radioButtonDisable.Name = "radioButtonDisable";
            this.radioButtonDisable.Size = new System.Drawing.Size(63, 19);
            this.radioButtonDisable.TabIndex = 5;
            this.radioButtonDisable.TabStop = true;
            this.radioButtonDisable.Text = "Disable";
            this.radioButtonDisable.UseVisualStyleBackColor = true;
            this.radioButtonDisable.Click += new System.EventHandler(this.RadioDisableRoute);
            // 
            // radioButtonUseUser
            // 
            this.radioButtonUseUser.AutoSize = true;
            this.radioButtonUseUser.Location = new System.Drawing.Point(75, 22);
            this.radioButtonUseUser.Name = "radioButtonUseUser";
            this.radioButtonUseUser.Size = new System.Drawing.Size(48, 19);
            this.radioButtonUseUser.TabIndex = 7;
            this.radioButtonUseUser.Tag = "User";
            this.radioButtonUseUser.Text = "User";
            this.radioButtonUseUser.UseVisualStyleBackColor = true;
            this.radioButtonUseUser.Click += new System.EventHandler(this.RadioSetRouteMode);
            // 
            // radioButtonUseClient
            // 
            this.radioButtonUseClient.AutoSize = true;
            this.radioButtonUseClient.Location = new System.Drawing.Point(129, 22);
            this.radioButtonUseClient.Name = "radioButtonUseClient";
            this.radioButtonUseClient.Size = new System.Drawing.Size(56, 19);
            this.radioButtonUseClient.TabIndex = 6;
            this.radioButtonUseClient.Tag = "Client";
            this.radioButtonUseClient.Text = "Client";
            this.radioButtonUseClient.UseVisualStyleBackColor = true;
            this.radioButtonUseClient.Click += new System.EventHandler(this.RadioSetRouteMode);
            // 
            // listViewJumpList
            // 
            this.listViewJumpList.BackColor = System.Drawing.Color.Silver;
            this.listViewJumpList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSystem,
            this.columnHeaderJumped,
            this.columnHeaderLeft,
            this.columnHeaderJumps,
            this.columnHeaderNeutron});
            this.listViewJumpList.FullRowSelect = true;
            this.listViewJumpList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewJumpList.Location = new System.Drawing.Point(6, 70);
            this.listViewJumpList.Name = "listViewJumpList";
            this.listViewJumpList.Size = new System.Drawing.Size(364, 252);
            this.listViewJumpList.TabIndex = 4;
            this.listViewJumpList.UseCompatibleStateImageBehavior = false;
            this.listViewJumpList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderSystem
            // 
            this.columnHeaderSystem.Text = "System";
            this.columnHeaderSystem.Width = 100;
            // 
            // columnHeaderJumped
            // 
            this.columnHeaderJumped.Text = "Jumped";
            // 
            // columnHeaderLeft
            // 
            this.columnHeaderLeft.Text = "Left";
            // 
            // columnHeaderJumps
            // 
            this.columnHeaderJumps.Text = "Jumps";
            this.columnHeaderJumps.Width = 80;
            // 
            // columnHeaderNeutron
            // 
            this.columnHeaderNeutron.Text = "Neutron";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSettings,
            this.toggleRatModeToolStripMenuItem,
            this.quickSelectToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(627, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemSettings
            // 
            this.toolStripMenuItemSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemTopMost});
            this.toolStripMenuItemSettings.Name = "toolStripMenuItemSettings";
            this.toolStripMenuItemSettings.Size = new System.Drawing.Size(61, 20);
            this.toolStripMenuItemSettings.Text = "Settings";
            // 
            // toolStripMenuItemTopMost
            // 
            this.toolStripMenuItemTopMost.Name = "toolStripMenuItemTopMost";
            this.toolStripMenuItemTopMost.Size = new System.Drawing.Size(123, 22);
            this.toolStripMenuItemTopMost.Text = "Top most";
            this.toolStripMenuItemTopMost.Click += new System.EventHandler(this.TopMost_CheckedChanged);
            // 
            // toggleRatModeToolStripMenuItem
            // 
            this.toggleRatModeToolStripMenuItem.Name = "toggleRatModeToolStripMenuItem";
            this.toggleRatModeToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.toggleRatModeToolStripMenuItem.Text = "ToggleRatMode";
            this.toggleRatModeToolStripMenuItem.Click += new System.EventHandler(this.toggleRatModeToolStripMenuItem_Click);
            // 
            // quickSelectToolStripMenuItem
            // 
            this.quickSelectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eDITToolStripMenuItem});
            this.quickSelectToolStripMenuItem.Name = "quickSelectToolStripMenuItem";
            this.quickSelectToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.quickSelectToolStripMenuItem.Text = "QuickSelect";
            // 
            // eDITToolStripMenuItem
            // 
            this.eDITToolStripMenuItem.Name = "eDITToolStripMenuItem";
            this.eDITToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.eDITToolStripMenuItem.Text = "[EDIT]";
            this.eDITToolStripMenuItem.Click += new System.EventHandler(this.eDITToolStripMenuItem_Click);
            // 
            // timerUpdateQuickSelect
            // 
            this.timerUpdateQuickSelect.Enabled = true;
            this.timerUpdateQuickSelect.Interval = 10000;
            this.timerUpdateQuickSelect.Tick += new System.EventHandler(this.timerUpdateQuickSelect_Tick);
            // 
            // timerFuelAlert
            // 
            this.timerFuelAlert.Interval = 1000;
            this.timerFuelAlert.Tick += new System.EventHandler(this.timerFuelAlert_Tick);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(627, 444);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBoxSpansh);
            this.Controls.Add(this.groupBoxUserInfo);
            this.Controls.Add(this.groupBoxCaseInfo);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Rat Assist";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCaseNR)).EndInit();
            this.groupBoxCaseInfo.ResumeLayout(false);
            this.groupBoxCaseInfo.PerformLayout();
            this.groupBoxUserInfo.ResumeLayout(false);
            this.groupBoxUserInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownJumpRange)).EndInit();
            this.groupBoxSpansh.ResumeLayout(false);
            this.panelMessageBackground.ResumeLayout(false);
            this.panelMessageBackground.PerformLayout();
            this.groupBoxRouteMode.ResumeLayout(false);
            this.groupBoxRouteMode.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private TextBox textBoxClientName;
        private Label label1;
        private NumericUpDown numericUpDownCaseNR;
        private Label label2;
        private Label label3;
        private TextBox textBoxPlatform;
        private CheckBox checkBoxCodeRed;
        private Label label4;
        private TextBox textBoxClientSystemName;
        private GroupBox groupBoxCaseInfo;
        private GroupBox groupBoxUserInfo;
        private Button buttonClearCase;
        private Label label7;
        private TextBox textBoxTargetSystem;
        private NumericUpDown numericUpDownJumpRange;
        private Label label6;
        private Label label5;
        private TextBox textBoxCurrentSystem;
        private Button buttonSetUserSystem;
        private GroupBox groupBoxSpansh;
        private GroupBox groupBoxRouteMode;
        private RadioButton radioButtonDisable;
        private RadioButton radioButtonUseUser;
        private RadioButton radioButtonUseClient;
        private ListView listViewJumpList;
        private ColumnHeader columnHeaderSystem;
        private ColumnHeader columnHeaderJumped;
        private ColumnHeader columnHeaderLeft;
        private ColumnHeader columnHeaderJumps;
        private ColumnHeader columnHeaderNeutron;
        private Label labelMessageForeground;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItemSettings;
        private ToolStripMenuItem toolStripMenuItemTopMost;
        private Panel panelMessageBackground;
        private Button buttonSetClientTargetSystem;
        private ToolStripMenuItem toggleRatModeToolStripMenuItem;
        private ToolStripMenuItem quickSelectToolStripMenuItem;
        private ToolStripMenuItem eDITToolStripMenuItem;
        private System.Windows.Forms.Timer timerUpdateQuickSelect;
        private Panel panelFuelLevelBackground;
        private System.Windows.Forms.Timer timerFuelAlert;
        private ToolStripMenuItem aboutToolStripMenuItem;
    }
}