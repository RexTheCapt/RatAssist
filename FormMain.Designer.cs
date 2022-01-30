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
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxClientName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownCaseNR = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPlatform = new System.Windows.Forms.TextBox();
            this.checkBoxCodeRed = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSystemName = new System.Windows.Forms.TextBox();
            this.groupBoxCaseInfo = new System.Windows.Forms.GroupBox();
            this.buttonClearCase = new System.Windows.Forms.Button();
            this.groupBoxRatInfo = new System.Windows.Forms.GroupBox();
            this.buttonSetTarget = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxCurrentSystem = new System.Windows.Forms.TextBox();
            this.groupBoxSpansh = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonDisable = new System.Windows.Forms.RadioButton();
            this.radioButtonUseUser = new System.Windows.Forms.RadioButton();
            this.radioButtonUseClient = new System.Windows.Forms.RadioButton();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeaderSystem = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderJumped = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderLeft = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderJumps = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderNeutron = new System.Windows.Forms.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCaseNR)).BeginInit();
            this.groupBoxCaseInfo.SuspendLayout();
            this.groupBoxRatInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBoxSpansh.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Set case";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxClientName
            // 
            this.textBoxClientName.Location = new System.Drawing.Point(86, 109);
            this.textBoxClientName.Name = "textBoxClientName";
            this.textBoxClientName.Size = new System.Drawing.Size(120, 23);
            this.textBoxClientName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Client name:";
            // 
            // numericUpDownCaseNR
            // 
            this.numericUpDownCaseNR.Location = new System.Drawing.Point(86, 167);
            this.numericUpDownCaseNR.Name = "numericUpDownCaseNR";
            this.numericUpDownCaseNR.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownCaseNR.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Case NR:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Platform:";
            // 
            // textBoxPlatform
            // 
            this.textBoxPlatform.Location = new System.Drawing.Point(86, 138);
            this.textBoxPlatform.Name = "textBoxPlatform";
            this.textBoxPlatform.Size = new System.Drawing.Size(120, 23);
            this.textBoxPlatform.TabIndex = 5;
            // 
            // checkBoxCodeRed
            // 
            this.checkBoxCodeRed.AutoSize = true;
            this.checkBoxCodeRed.Location = new System.Drawing.Point(86, 196);
            this.checkBoxCodeRed.Name = "checkBoxCodeRed";
            this.checkBoxCodeRed.Size = new System.Drawing.Size(77, 19);
            this.checkBoxCodeRed.TabIndex = 7;
            this.checkBoxCodeRed.Text = "Code Red";
            this.checkBoxCodeRed.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "System name:";
            // 
            // textBoxSystemName
            // 
            this.textBoxSystemName.Location = new System.Drawing.Point(86, 80);
            this.textBoxSystemName.Name = "textBoxSystemName";
            this.textBoxSystemName.Size = new System.Drawing.Size(120, 23);
            this.textBoxSystemName.TabIndex = 8;
            // 
            // groupBoxCaseInfo
            // 
            this.groupBoxCaseInfo.BackColor = System.Drawing.Color.Gray;
            this.groupBoxCaseInfo.Controls.Add(this.buttonClearCase);
            this.groupBoxCaseInfo.Controls.Add(this.button1);
            this.groupBoxCaseInfo.Controls.Add(this.label4);
            this.groupBoxCaseInfo.Controls.Add(this.textBoxClientName);
            this.groupBoxCaseInfo.Controls.Add(this.textBoxSystemName);
            this.groupBoxCaseInfo.Controls.Add(this.label1);
            this.groupBoxCaseInfo.Controls.Add(this.checkBoxCodeRed);
            this.groupBoxCaseInfo.Controls.Add(this.numericUpDownCaseNR);
            this.groupBoxCaseInfo.Controls.Add(this.label3);
            this.groupBoxCaseInfo.Controls.Add(this.label2);
            this.groupBoxCaseInfo.Controls.Add(this.textBoxPlatform);
            this.groupBoxCaseInfo.Location = new System.Drawing.Point(12, 12);
            this.groupBoxCaseInfo.Name = "groupBoxCaseInfo";
            this.groupBoxCaseInfo.Size = new System.Drawing.Size(216, 219);
            this.groupBoxCaseInfo.TabIndex = 10;
            this.groupBoxCaseInfo.TabStop = false;
            this.groupBoxCaseInfo.Text = "Case info";
            // 
            // buttonClearCase
            // 
            this.buttonClearCase.Location = new System.Drawing.Point(6, 51);
            this.buttonClearCase.Name = "buttonClearCase";
            this.buttonClearCase.Size = new System.Drawing.Size(200, 23);
            this.buttonClearCase.TabIndex = 10;
            this.buttonClearCase.Text = "Clear case";
            this.buttonClearCase.UseVisualStyleBackColor = true;
            // 
            // groupBoxRatInfo
            // 
            this.groupBoxRatInfo.BackColor = System.Drawing.Color.Gray;
            this.groupBoxRatInfo.Controls.Add(this.buttonSetTarget);
            this.groupBoxRatInfo.Controls.Add(this.label7);
            this.groupBoxRatInfo.Controls.Add(this.textBox1);
            this.groupBoxRatInfo.Controls.Add(this.numericUpDown1);
            this.groupBoxRatInfo.Controls.Add(this.label6);
            this.groupBoxRatInfo.Controls.Add(this.label5);
            this.groupBoxRatInfo.Controls.Add(this.textBoxCurrentSystem);
            this.groupBoxRatInfo.Location = new System.Drawing.Point(12, 237);
            this.groupBoxRatInfo.Name = "groupBoxRatInfo";
            this.groupBoxRatInfo.Size = new System.Drawing.Size(216, 144);
            this.groupBoxRatInfo.TabIndex = 11;
            this.groupBoxRatInfo.TabStop = false;
            this.groupBoxRatInfo.Text = "User info";
            // 
            // buttonSetTarget
            // 
            this.buttonSetTarget.Location = new System.Drawing.Point(6, 109);
            this.buttonSetTarget.Name = "buttonSetTarget";
            this.buttonSetTarget.Size = new System.Drawing.Size(200, 23);
            this.buttonSetTarget.TabIndex = 12;
            this.buttonSetTarget.Text = "Set target";
            this.buttonSetTarget.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Target sys:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(86, 80);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 23);
            this.textBox1.TabIndex = 12;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Location = new System.Drawing.Point(86, 51);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown1.TabIndex = 10;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Jump range:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Current sys:";
            // 
            // textBoxCurrentSystem
            // 
            this.textBoxCurrentSystem.Location = new System.Drawing.Point(86, 22);
            this.textBoxCurrentSystem.Name = "textBoxCurrentSystem";
            this.textBoxCurrentSystem.Size = new System.Drawing.Size(120, 23);
            this.textBoxCurrentSystem.TabIndex = 10;
            // 
            // groupBoxSpansh
            // 
            this.groupBoxSpansh.BackColor = System.Drawing.Color.Gray;
            this.groupBoxSpansh.Controls.Add(this.groupBox1);
            this.groupBoxSpansh.Controls.Add(this.listView1);
            this.groupBoxSpansh.Location = new System.Drawing.Point(234, 10);
            this.groupBoxSpansh.Name = "groupBoxSpansh";
            this.groupBoxSpansh.Size = new System.Drawing.Size(397, 367);
            this.groupBoxSpansh.TabIndex = 12;
            this.groupBoxSpansh.TabStop = false;
            this.groupBoxSpansh.Text = "Spansh";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonDisable);
            this.groupBox1.Controls.Add(this.radioButtonUseUser);
            this.groupBox1.Controls.Add(this.radioButtonUseClient);
            this.groupBox1.Location = new System.Drawing.Point(6, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 48);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Route to:";
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
            // 
            // radioButtonUseUser
            // 
            this.radioButtonUseUser.AutoSize = true;
            this.radioButtonUseUser.Location = new System.Drawing.Point(137, 22);
            this.radioButtonUseUser.Name = "radioButtonUseUser";
            this.radioButtonUseUser.Size = new System.Drawing.Size(48, 19);
            this.radioButtonUseUser.TabIndex = 7;
            this.radioButtonUseUser.Text = "User";
            this.radioButtonUseUser.UseVisualStyleBackColor = true;
            // 
            // radioButtonUseClient
            // 
            this.radioButtonUseClient.AutoSize = true;
            this.radioButtonUseClient.Location = new System.Drawing.Point(75, 22);
            this.radioButtonUseClient.Name = "radioButtonUseClient";
            this.radioButtonUseClient.Size = new System.Drawing.Size(56, 19);
            this.radioButtonUseClient.TabIndex = 6;
            this.radioButtonUseClient.Text = "Client";
            this.radioButtonUseClient.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.Silver;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSystem,
            this.columnHeaderJumped,
            this.columnHeaderLeft,
            this.columnHeaderJumps,
            this.columnHeaderNeutron});
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(6, 70);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(385, 289);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
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
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(642, 389);
            this.Controls.Add(this.groupBoxSpansh);
            this.Controls.Add(this.groupBoxRatInfo);
            this.Controls.Add(this.groupBoxCaseInfo);
            this.Name = "FormMain";
            this.Text = "Rat Assist";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCaseNR)).EndInit();
            this.groupBoxCaseInfo.ResumeLayout(false);
            this.groupBoxCaseInfo.PerformLayout();
            this.groupBoxRatInfo.ResumeLayout(false);
            this.groupBoxRatInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBoxSpansh.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

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
        private TextBox textBoxSystemName;
        private GroupBox groupBoxCaseInfo;
        private GroupBox groupBoxRatInfo;
        private Button buttonClearCase;
        private Label label7;
        private TextBox textBox1;
        private NumericUpDown numericUpDown1;
        private Label label6;
        private Label label5;
        private TextBox textBoxCurrentSystem;
        private Button buttonSetTarget;
        private GroupBox groupBoxSpansh;
        private GroupBox groupBox1;
        private RadioButton radioButtonDisable;
        private RadioButton radioButtonUseUser;
        private RadioButton radioButtonUseClient;
        private ListView listView1;
        private ColumnHeader columnHeaderSystem;
        private ColumnHeader columnHeaderJumped;
        private ColumnHeader columnHeaderLeft;
        private ColumnHeader columnHeaderJumps;
        private ColumnHeader columnHeaderNeutron;
    }
}