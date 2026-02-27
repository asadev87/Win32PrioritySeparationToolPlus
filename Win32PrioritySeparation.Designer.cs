namespace Win32PrioritySeparationTool
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.led_DisplayCurrentValue = new Sunny.UI.UILedDisplay();
            this.lb_CurrentValue = new System.Windows.Forms.Label();
            this.cbg_options = new Sunny.UI.UICheckBoxGroup();
            this.lblSortLength = new System.Windows.Forms.Label();
            this.cmbSortLength = new System.Windows.Forms.ComboBox();
            this.lblSortType = new System.Windows.Forms.Label();
            this.cmbSortType = new System.Windows.Forms.ComboBox();
            this.lblSortBoost = new System.Windows.Forms.Label();
            this.cmbSortBoost = new System.Windows.Forms.ComboBox();
            this.chkDarkMode = new System.Windows.Forms.CheckBox();
            this.gb_CurrentInfo = new System.Windows.Forms.GroupBox();
            this.lblCurrentHexValue = new System.Windows.Forms.Label();
            this.lblPriorityRatioValue = new System.Windows.Forms.Label();
            this.lblPriorityRatioTitle = new System.Windows.Forms.Label();
            this.lblForegroundBoostValue = new System.Windows.Forms.Label();
            this.lblForegroundBoostTitle = new System.Windows.Forms.Label();
            this.lblQuantumTypeValue = new System.Windows.Forms.Label();
            this.lblQuantumTypeTitle = new System.Windows.Forms.Label();
            this.lblQuantumLengthValue = new System.Windows.Forms.Label();
            this.lblQuantumLengthTitle = new System.Windows.Forms.Label();
            this.StyleManager = new Sunny.UI.UIStyleManager(this.components);
            this.gb_CurrentInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // led_DisplayCurrentValue
            // 
            this.led_DisplayCurrentValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.led_DisplayCurrentValue.BackColor = System.Drawing.Color.Black;
            this.led_DisplayCurrentValue.CharCount = 2;
            this.led_DisplayCurrentValue.ForeColor = System.Drawing.Color.Lime;
            this.led_DisplayCurrentValue.Location = new System.Drawing.Point(190, 26);
            this.led_DisplayCurrentValue.Name = "led_DisplayCurrentValue";
            this.led_DisplayCurrentValue.Size = new System.Drawing.Size(142, 34);
            this.led_DisplayCurrentValue.TabIndex = 0;
            this.led_DisplayCurrentValue.Text = "Nan";
            // 
            // lb_CurrentValue
            // 
            this.lb_CurrentValue.AutoSize = true;
            this.lb_CurrentValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_CurrentValue.Location = new System.Drawing.Point(15, 33);
            this.lb_CurrentValue.Name = "lb_CurrentValue";
            this.lb_CurrentValue.Size = new System.Drawing.Size(89, 19);
            this.lb_CurrentValue.TabIndex = 1;
            this.lb_CurrentValue.Text = "Current Value";
            // 
            // cbg_options   LEFT WINDOW
            // 
            this.cbg_options.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbg_options.ColumnCount = 8;
            this.cbg_options.ColumnInterval = 1;
            this.cbg_options.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbg_options.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.cbg_options.Items.AddRange(new object[] {
            "2",
            "20",
            "21",
            "22",
            "24",
            "25",
            "26",
            "36",
            "37",
            "38",
            "40",
            "41",
            "42"});
            this.cbg_options.ItemSize = new System.Drawing.Size(72, 72);
            this.cbg_options.Location = new System.Drawing.Point(4, 91);
            this.cbg_options.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbg_options.MinimumSize = new System.Drawing.Size(1, 1);
            this.cbg_options.Name = "cbg_options";
            this.cbg_options.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.cbg_options.RowInterval = 1;
            this.cbg_options.SelectedIndexes = new System.Collections.Generic.List<int>();
            this.cbg_options.Size = new System.Drawing.Size(604, 470);
            this.cbg_options.TabIndex = 2;
            this.cbg_options.Text = "Switch Options";
            this.cbg_options.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbg_options.TitleTop = 8;
            this.cbg_options.ValueChanged += new Sunny.UI.UICheckBoxGroup.OnValueChanged(this.cbg_options_ValueChanged);
            this.cbg_options.Load += new System.EventHandler(this.cbg_options_Load);
            // 
            // lblSortLength
            // 
            this.lblSortLength.AutoSize = true;
            this.lblSortLength.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSortLength.Location = new System.Drawing.Point(8, 51);
            this.lblSortLength.Name = "lblSortLength";
            this.lblSortLength.Size = new System.Drawing.Size(47, 15);
            this.lblSortLength.TabIndex = 3;
            this.lblSortLength.Text = "Length:";
            // 
            // cmbSortLength
            // 
            this.cmbSortLength.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSortLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortLength.FormattingEnabled = true;
            this.cmbSortLength.Items.AddRange(new object[] {
            "All",
            "Short",
            "Long"});
            this.cmbSortLength.Location = new System.Drawing.Point(60, 48);
            this.cmbSortLength.Name = "cmbSortLength";
            this.cmbSortLength.Size = new System.Drawing.Size(95, 21);
            this.cmbSortLength.TabIndex = 4;
            this.cmbSortLength.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.sorter_DrawItem);
            this.cmbSortLength.SelectedIndexChanged += new System.EventHandler(this.sorter_ValueChanged);
            // 
            // lblSortType
            // 
            this.lblSortType.AutoSize = true;
            this.lblSortType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSortType.Location = new System.Drawing.Point(168, 51);
            this.lblSortType.Name = "lblSortType";
            this.lblSortType.Size = new System.Drawing.Size(34, 15);
            this.lblSortType.TabIndex = 5;
            this.lblSortType.Text = "Type:";
            // 
            // cmbSortType
            // 
            this.cmbSortType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSortType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortType.FormattingEnabled = true;
            this.cmbSortType.Items.AddRange(new object[] {
            "All",
            "Variable",
            "Fixed"});
            this.cmbSortType.Location = new System.Drawing.Point(206, 48);
            this.cmbSortType.Name = "cmbSortType";
            this.cmbSortType.Size = new System.Drawing.Size(95, 21);
            this.cmbSortType.TabIndex = 6;
            this.cmbSortType.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.sorter_DrawItem);
            this.cmbSortType.SelectedIndexChanged += new System.EventHandler(this.sorter_ValueChanged);
            // 
            // lblSortBoost
            // 
            this.lblSortBoost.AutoSize = true;
            this.lblSortBoost.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSortBoost.Location = new System.Drawing.Point(314, 51);
            this.lblSortBoost.Name = "lblSortBoost";
            this.lblSortBoost.Size = new System.Drawing.Size(40, 15);
            this.lblSortBoost.TabIndex = 7;
            this.lblSortBoost.Text = "Boost:";
            // 
            // cmbSortBoost
            // 
            this.cmbSortBoost.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSortBoost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortBoost.FormattingEnabled = true;
            this.cmbSortBoost.Items.AddRange(new object[] {
            "All",
            "None",
            "Medium",
            "High"});
            this.cmbSortBoost.Location = new System.Drawing.Point(359, 48);
            this.cmbSortBoost.Name = "cmbSortBoost";
            this.cmbSortBoost.Size = new System.Drawing.Size(95, 21);
            this.cmbSortBoost.TabIndex = 8;
            this.cmbSortBoost.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.sorter_DrawItem);
            this.cmbSortBoost.SelectedIndexChanged += new System.EventHandler(this.sorter_ValueChanged);
            // 
            // chkDarkMode
            // 
            this.chkDarkMode.AutoSize = true;
            this.chkDarkMode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkDarkMode.Location = new System.Drawing.Point(482, 54);
            this.chkDarkMode.Name = "chkDarkMode";
            this.chkDarkMode.Size = new System.Drawing.Size(84, 19);
            this.chkDarkMode.TabIndex = 9;
            this.chkDarkMode.Text = "Dark Mode";
            this.chkDarkMode.UseVisualStyleBackColor = true;
            this.chkDarkMode.CheckedChanged += new System.EventHandler(this.chkDarkMode_CheckedChanged);
            // 
            // gb_CurrentInfo    RIGHT WINDOW
            // 
            this.gb_CurrentInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_CurrentInfo.Controls.Add(this.lblPriorityRatioValue);
            this.gb_CurrentInfo.Controls.Add(this.lblPriorityRatioTitle);
            this.gb_CurrentInfo.Controls.Add(this.lblForegroundBoostValue);
            this.gb_CurrentInfo.Controls.Add(this.lblForegroundBoostTitle);
            this.gb_CurrentInfo.Controls.Add(this.lblQuantumTypeValue);
            this.gb_CurrentInfo.Controls.Add(this.lblQuantumTypeTitle);
            this.gb_CurrentInfo.Controls.Add(this.lblQuantumLengthValue);
            this.gb_CurrentInfo.Controls.Add(this.lblQuantumLengthTitle);
            this.gb_CurrentInfo.Controls.Add(this.lblCurrentHexValue);
            this.gb_CurrentInfo.Controls.Add(this.lb_CurrentValue);
            this.gb_CurrentInfo.Controls.Add(this.led_DisplayCurrentValue);
            this.gb_CurrentInfo.Location = new System.Drawing.Point(608, 47);
            this.gb_CurrentInfo.Name = "gb_CurrentInfo";
            this.gb_CurrentInfo.Size = new System.Drawing.Size(352, 515);
            this.gb_CurrentInfo.TabIndex = 3;
            this.gb_CurrentInfo.TabStop = false;
            this.gb_CurrentInfo.Text = "Current Profile";
            // 
            // lblCurrentHexValue
            // 
            this.lblCurrentHexValue.AutoSize = true;
            this.lblCurrentHexValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentHexValue.Location = new System.Drawing.Point(250, 30);
            this.lblCurrentHexValue.Name = "lblCurrentHexValue";
            this.lblCurrentHexValue.Size = new System.Drawing.Size(50, 19);
            this.lblCurrentHexValue.TabIndex = 10;
            this.lblCurrentHexValue.Text = "(0x00)";
            // 
            // lblPriorityRatioValue
            // 
            this.lblPriorityRatioValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPriorityRatioValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPriorityRatioValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriorityRatioValue.Location = new System.Drawing.Point(190, 206);
            this.lblPriorityRatioValue.Name = "lblPriorityRatioValue";
            this.lblPriorityRatioValue.Size = new System.Drawing.Size(142, 27);
            this.lblPriorityRatioValue.TabIndex = 9;
            this.lblPriorityRatioValue.Text = "-";
            this.lblPriorityRatioValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPriorityRatioTitle
            // 
            this.lblPriorityRatioTitle.AutoSize = true;
            this.lblPriorityRatioTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriorityRatioTitle.Location = new System.Drawing.Point(15, 210);
            this.lblPriorityRatioTitle.Name = "lblPriorityRatioTitle";
            this.lblPriorityRatioTitle.Size = new System.Drawing.Size(153, 19);
            this.lblPriorityRatioTitle.TabIndex = 8;
            this.lblPriorityRatioTitle.Text = "Priority Separation";
            // 
            // lblForegroundBoostValue
            // 
            this.lblForegroundBoostValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblForegroundBoostValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblForegroundBoostValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForegroundBoostValue.Location = new System.Drawing.Point(190, 166);
            this.lblForegroundBoostValue.Name = "lblForegroundBoostValue";
            this.lblForegroundBoostValue.Size = new System.Drawing.Size(142, 27);
            this.lblForegroundBoostValue.TabIndex = 7;
            this.lblForegroundBoostValue.Text = "-";
            this.lblForegroundBoostValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblForegroundBoostTitle
            // 
            this.lblForegroundBoostTitle.AutoSize = true;
            this.lblForegroundBoostTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForegroundBoostTitle.Location = new System.Drawing.Point(15, 170);
            this.lblForegroundBoostTitle.Name = "lblForegroundBoostTitle";
            this.lblForegroundBoostTitle.Size = new System.Drawing.Size(112, 19);
            this.lblForegroundBoostTitle.TabIndex = 6;
            this.lblForegroundBoostTitle.Text = "Foreground Boost";
            // 
            // lblQuantumTypeValue
            // 
            this.lblQuantumTypeValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQuantumTypeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQuantumTypeValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantumTypeValue.Location = new System.Drawing.Point(190, 126);
            this.lblQuantumTypeValue.Name = "lblQuantumTypeValue";
            this.lblQuantumTypeValue.Size = new System.Drawing.Size(142, 27);
            this.lblQuantumTypeValue.TabIndex = 5;
            this.lblQuantumTypeValue.Text = "-";
            this.lblQuantumTypeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblQuantumTypeTitle
            // 
            this.lblQuantumTypeTitle.AutoSize = true;
            this.lblQuantumTypeTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantumTypeTitle.Location = new System.Drawing.Point(15, 130);
            this.lblQuantumTypeTitle.Name = "lblQuantumTypeTitle";
            this.lblQuantumTypeTitle.Size = new System.Drawing.Size(96, 19);
            this.lblQuantumTypeTitle.TabIndex = 4;
            this.lblQuantumTypeTitle.Text = "Quantum Type";
            // 
            // lblQuantumLengthValue
            // 
            this.lblQuantumLengthValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQuantumLengthValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQuantumLengthValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantumLengthValue.Location = new System.Drawing.Point(190, 86);
            this.lblQuantumLengthValue.Name = "lblQuantumLengthValue";
            this.lblQuantumLengthValue.Size = new System.Drawing.Size(142, 27);
            this.lblQuantumLengthValue.TabIndex = 3;
            this.lblQuantumLengthValue.Text = "-";
            this.lblQuantumLengthValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblQuantumLengthTitle
            // 
            this.lblQuantumLengthTitle.AutoSize = true;
            this.lblQuantumLengthTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantumLengthTitle.Location = new System.Drawing.Point(15, 90);
            this.lblQuantumLengthTitle.Name = "lblQuantumLengthTitle";
            this.lblQuantumLengthTitle.Size = new System.Drawing.Size(108, 19);
            this.lblQuantumLengthTitle.TabIndex = 2;
            this.lblQuantumLengthTitle.Text = "Quantum Length";
            // 
            // StyleManager
            // 
            this.StyleManager.DPIScale = true;
            this.StyleManager.GlobalFont = true;
            this.StyleManager.GlobalFontName = "Arial Black";
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(970, 588);
            this.Controls.Add(this.chkDarkMode);
            this.Controls.Add(this.cmbSortBoost);
            this.Controls.Add(this.lblSortBoost);
            this.Controls.Add(this.cmbSortType);
            this.Controls.Add(this.lblSortType);
            this.Controls.Add(this.cmbSortLength);
            this.Controls.Add(this.lblSortLength);
            this.Controls.Add(this.gb_CurrentInfo);
            this.Controls.Add(this.cbg_options);
            this.MinimumSize = new System.Drawing.Size(970, 588);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Win32PrioritySeparation";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 964, 585);
            this.gb_CurrentInfo.ResumeLayout(false);
            this.gb_CurrentInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILedDisplay led_DisplayCurrentValue;
        private System.Windows.Forms.Label lb_CurrentValue;
        private Sunny.UI.UICheckBoxGroup cbg_options;
        private System.Windows.Forms.Label lblSortLength;
        private System.Windows.Forms.ComboBox cmbSortLength;
        private System.Windows.Forms.Label lblSortType;
        private System.Windows.Forms.ComboBox cmbSortType;
        private System.Windows.Forms.Label lblSortBoost;
        private System.Windows.Forms.ComboBox cmbSortBoost;
        private System.Windows.Forms.CheckBox chkDarkMode;
        private System.Windows.Forms.GroupBox gb_CurrentInfo;
        private System.Windows.Forms.Label lblCurrentHexValue;
        private System.Windows.Forms.Label lblPriorityRatioValue;
        private System.Windows.Forms.Label lblPriorityRatioTitle;
        private System.Windows.Forms.Label lblQuantumLengthTitle;
        private System.Windows.Forms.Label lblQuantumLengthValue;
        private System.Windows.Forms.Label lblQuantumTypeTitle;
        private System.Windows.Forms.Label lblQuantumTypeValue;
        private System.Windows.Forms.Label lblForegroundBoostTitle;
        private System.Windows.Forms.Label lblForegroundBoostValue;
        private Sunny.UI.UIStyleManager StyleManager;
    }
}
