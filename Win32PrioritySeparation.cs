using Microsoft.Win32;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win32PrioritySeparationTool
{
    public partial class FormMain : UIForm
    {
        private const int MinSupportedValue = 0;
        private const int MaxSupportedValue = 63;
        private const int DefaultValue = 38;
        private const int SupportedBitsMask = 0x3F;

        int? Win32PrioritySeparationValue;
        RegistryKey registryKey;
        private bool isUpdatingSelection;
        private bool isUpdatingSorters;
        private bool isDarkModeEnabled;
        private readonly List<int> availableValues = new List<int>();

        public FormMain()
        {
            InitializeComponent();
            StyleManager.Style = UIStyle.Purple;
            registryKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\PriorityControl", true);
            isUpdatingSorters = true;
            cmbSortLength.SelectedIndex = 0;
            cmbSortType.SelectedIndex = 0;
            cmbSortBoost.SelectedIndex = 0;
            isUpdatingSorters = false;
            PopulateOptions();
            chkDarkMode.Checked = Properties.Settings.Default.DarkModeEnabled;
            ApplyTheme(chkDarkMode.Checked);
        }

        private void AutoFitCurrentInfoPanel()
        {
            const int panelGap = 8;
            const int panelRightPadding = 16;
            const int formRightPadding = 4;

            int maxContentRight = 0;
            foreach (Control ctrl in gb_CurrentInfo.Controls)
            {
                int width = ctrl.AutoSize ? ctrl.PreferredSize.Width : ctrl.Width;
                int right = ctrl.Left + width;
                if (right > maxContentRight)
                {
                    maxContentRight = right;
                }
            }

            gb_CurrentInfo.Width = maxContentRight + panelRightPadding;
            gb_CurrentInfo.Left = cbg_options.Right + panelGap;

            int desiredClientWidth = gb_CurrentInfo.Right + formRightPadding;
            this.ClientSize = new Size(desiredClientWidth, this.ClientSize.Height);

            int borderWidthDelta = this.MinimumSize.Width - this.ClientSize.Width;
            this.MinimumSize = new Size(desiredClientWidth + borderWidthDelta, this.MinimumSize.Height);
        }

        private void PopulateOptions()
        {
            ClearAllSelections();

            availableValues.Clear();
            cbg_options.Items.Clear();
            for (int i = MinSupportedValue; i <= MaxSupportedValue; i++)
            {
                if ((i & 0x03) == 0x03)
                {
                    continue;
                }

                if (!ValueMatchesSorters(i))
                {
                    continue;
                }

                availableValues.Add(i);
                cbg_options.Items.Add($"{i}\r\n0x{i:X2}");
            }

            // Clear again after rebind to prevent index carry-over in filtered grids.
            ClearAllSelections();
            cbg_options.Invalidate();
        }

        private bool ValueMatchesSorters(int value)
        {
            string lengthFilter = cmbSortLength.SelectedItem?.ToString() ?? "All";
            string typeFilter = cmbSortType.SelectedItem?.ToString() ?? "All";
            string boostFilter = cmbSortBoost.SelectedItem?.ToString() ?? "All";

            if (lengthFilter == "Short" && (value & 0x08) != 0)
            {
                return false;
            }

            if (lengthFilter == "Long" && (value & 0x08) == 0)
            {
                return false;
            }

            if (typeFilter == "Variable" && (value & 0x04) != 0)
            {
                return false;
            }

            if (typeFilter == "Fixed" && (value & 0x04) == 0)
            {
                return false;
            }

            if (boostFilter != "All" && GetForegroundBoostText(value) != boostFilter)
            {
                return false;
            }

            return true;
        }

        private string GetForegroundBoostText(int value)
        {
            switch (value & 0x03)
            {
                case 0:
                    return "None";
                case 1:
                    return "Medium";
                case 2:
                    return "High";
                default:
                    return "Reserved";
            }
        }

        private int GetCurrentValueOfItemsIdx()
        {
            if (!Win32PrioritySeparationValue.HasValue)
            {
                return -1;
            }

            int value = Win32PrioritySeparationValue.Value;
            if (value < MinSupportedValue || value > MaxSupportedValue)
            {
                return -1;
            }

            return availableValues.IndexOf(value);
        }

        private void LoadCurrentValue()
        {
            if (registryKey == null)
            {
                MessageBox.Show("Registry key not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var rawValue = registryKey.GetValue("Win32PrioritySeparation");
            if (rawValue == null)
            {
                registryKey.SetValue("Win32PrioritySeparation", DefaultValue, RegistryValueKind.DWord);
                Win32PrioritySeparationValue = DefaultValue;
            }
            else
            {
                Win32PrioritySeparationValue = Convert.ToInt32(rawValue) & SupportedBitsMask;
            }

            if ((Win32PrioritySeparationValue.Value & 0x03) == 0x03)
            {
                registryKey.SetValue("Win32PrioritySeparation", DefaultValue, RegistryValueKind.DWord);
                Win32PrioritySeparationValue = DefaultValue;
            }

            led_DisplayCurrentValue.Text = Win32PrioritySeparationValue.ToString();
            lblCurrentHexValue.Text = $"(0x{Win32PrioritySeparationValue.Value:X2})";
            UpdateSchedulingFields(Win32PrioritySeparationValue.Value);
        }

        private void UpdateSchedulingFields(int value)
        {
            lblQuantumLengthValue.Text = (value & 0x08) != 0 ? "Long" : "Short";
            lblQuantumTypeValue.Text = (value & 0x04) != 0 ? "Fixed" : "Variable";

            switch (value & 0x03)
            {
                case 0:
                    lblForegroundBoostValue.Text = "None";
                    lblPriorityRatioValue.Text = "1:1";
                    break;
                case 1:
                    lblForegroundBoostValue.Text = "Medium";
                    lblPriorityRatioValue.Text = "2:1";
                    break;
                case 2:
                    lblForegroundBoostValue.Text = "High";
                    lblPriorityRatioValue.Text = "3:1";
                    break;
                default:
                    lblForegroundBoostValue.Text = "Reserved";
                    lblPriorityRatioValue.Text = "N/A";
                    break;
            }
        }

        private void sorter_ValueChanged(object sender, EventArgs e)
        {
            if (isUpdatingSorters)
            {
                return;
            }

            PopulateOptions();

            if (!Win32PrioritySeparationValue.HasValue)
            {
                return;
            }

            int selectedIdx = GetCurrentValueOfItemsIdx();
            if (selectedIdx >= 0)
            {
                SetSingleSelection(selectedIdx);
            }
            else
            {
                ClearAllSelections();
            }
        }

        private void cbg_options_Load(object sender, EventArgs e)
        {
            AutoFitCurrentInfoPanel();

            if (registryKey == null)
            {
                MessageBox.Show("Registry key not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadCurrentValue();
            var selectedIdx = GetCurrentValueOfItemsIdx();
            // If the registry value is outside supported range, fallback to default.
            if (selectedIdx < 0)
            {
                selectedIdx = availableValues.IndexOf(DefaultValue);
                if (selectedIdx < 0)
                {
                    selectedIdx = 0;
                }

                if (!availableValues.Any())
                {
                    MessageBox.Show("No values match the selected sorter criteria.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var value = availableValues[selectedIdx];
                registryKey.SetValue("Win32PrioritySeparation", value, RegistryValueKind.DWord);
                LoadCurrentValue();
            }

            SetSingleSelection(selectedIdx);
        }

        private void SetSingleSelection(int selectedIndex)
        {
            isUpdatingSelection = true;
            try
            {
                cbg_options.SelectedIndexes.Clear();
                cbg_options.SelectedIndexes = new List<int>() { selectedIndex };
            }
            finally
            {
                isUpdatingSelection = false;
            }
        }

        private void ClearAllSelections()
        {
            isUpdatingSelection = true;
            try
            {
                cbg_options.SelectedIndexes.Clear();
                cbg_options.SelectedIndexes = new List<int>();
            }
            finally
            {
                isUpdatingSelection = false;
            }
        }

        private void cbg_options_ValueChanged(object sender, CheckBoxGroupEventArgs e)
        {
            if (isUpdatingSelection)
            {
                return;
            }

            if (registryKey == null)
            {
                MessageBox.Show("Registry key not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (e.SelectedIndexes == null || !e.SelectedIndexes.Any())
            {
                var currentIdxOnEmpty = GetCurrentValueOfItemsIdx();
                if (currentIdxOnEmpty >= 0)
                {
                    SetSingleSelection(currentIdxOnEmpty);
                }
                return;
            }

            var currentIdx = GetCurrentValueOfItemsIdx();
            var nextIdx = e.SelectedIndexes.First();
            if (currentIdx >= 0)
            {
                var candidateIndexes = e.SelectedIndexes.Where(idx => idx != currentIdx).ToList();
                if (candidateIndexes.Count == 0)
                {
                    SetSingleSelection(currentIdx);
                    return;
                }

                nextIdx = candidateIndexes[0];
            }

            SetSingleSelection(nextIdx);

            if (nextIdx < 0 || nextIdx >= availableValues.Count)
            {
                return;
            }

            var selectedValue = availableValues[nextIdx];

            if (selectedValue != Win32PrioritySeparationValue)
            {
                registryKey.SetValue("Win32PrioritySeparation", selectedValue, RegistryValueKind.DWord);
                LoadCurrentValue();
            }
        }

        private void chkDarkMode_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DarkModeEnabled = chkDarkMode.Checked;
            Properties.Settings.Default.Save();
            ApplyTheme(chkDarkMode.Checked);
        }

        private void ApplyTheme(bool darkMode)
        {
            isDarkModeEnabled = darkMode;
            Color formBack = darkMode ? Color.FromArgb(32, 32, 36) : SystemColors.Control;
            Color panelBack = darkMode ? Color.FromArgb(44, 44, 50) : SystemColors.Control;
            Color inputBack = darkMode ? Color.FromArgb(56, 56, 64) : SystemColors.Window;
            Color text = darkMode ? Color.Gainsboro : SystemColors.ControlText;

            this.StyleCustomMode = darkMode;
            this.BackColor = formBack;
            this.ForeColor = text;

            if (darkMode)
            {
                this.Style = UIStyle.Custom;
                this.RectColor = Color.FromArgb(86, 86, 98);
                this.TitleColor = Color.FromArgb(44, 44, 50);
                this.TitleForeColor = Color.Gainsboro;
            }
            else
            {
                this.Style = UIStyle.Purple;
                this.StyleCustomMode = false;
            }

            ApplyThemeRecursive(this, panelBack, inputBack, text, darkMode);

            // Keep LED readable regardless of theme.
            led_DisplayCurrentValue.BackColor = Color.Black;
            led_DisplayCurrentValue.ForeColor = Color.Lime;

            cmbSortLength.Invalidate();
            cmbSortType.Invalidate();
            cmbSortBoost.Invalidate();
        }

        private void ApplyThemeRecursive(Control parent, Color panelBack, Color inputBack, Color text, bool darkMode)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is UICheckBoxGroup checkBoxGroup)
                {
                    checkBoxGroup.StyleCustomMode = darkMode;
                    checkBoxGroup.Style = darkMode ? UIStyle.Custom : UIStyle.Purple;
                    checkBoxGroup.BackColor = panelBack;
                    checkBoxGroup.FillColor = darkMode ? Color.FromArgb(38, 38, 44) : SystemColors.Control;
                    checkBoxGroup.FillColor2 = checkBoxGroup.FillColor;
                    checkBoxGroup.FillDisableColor = checkBoxGroup.FillColor;
                    checkBoxGroup.ForeColor = text;
                    checkBoxGroup.ForeDisableColor = text;
                    checkBoxGroup.RectColor = darkMode ? Color.FromArgb(104, 104, 118) : Color.FromArgb(84, 61, 194);
                    checkBoxGroup.RectDisableColor = checkBoxGroup.RectColor;
                    checkBoxGroup.CheckBoxColor = darkMode ? Color.FromArgb(124, 106, 214) : Color.FromArgb(84, 61, 194);
                    checkBoxGroup.HoverColor = darkMode ? Color.FromArgb(66, 66, 74) : Color.FromArgb(220, 236, 255);
                }
                else if (control is ComboBox || control is TextBox)
                {
                    control.BackColor = inputBack;
                    control.ForeColor = text;
                }
                else if (control is CheckBox || control is Label || control is GroupBox || control is UICheckBoxGroup)
                {
                    control.BackColor = panelBack;
                    control.ForeColor = text;
                }
                else
                {
                    control.BackColor = panelBack;
                    control.ForeColor = text;
                }

                if (control.HasChildren)
                {
                    ApplyThemeRecursive(control, panelBack, inputBack, text, darkMode);
                }
            }
        }

        private void sorter_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            if (combo == null)
            {
                return;
            }

            Color backColor = isDarkModeEnabled ? Color.FromArgb(56, 56, 64) : SystemColors.Window;
            Color selectedBackColor = isDarkModeEnabled ? Color.FromArgb(84, 84, 96) : SystemColors.Highlight;
            Color foreColor = isDarkModeEnabled ? Color.Gainsboro : SystemColors.ControlText;
            Color selectedForeColor = isDarkModeEnabled ? Color.WhiteSmoke : SystemColors.HighlightText;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                using (SolidBrush selectedBrush = new SolidBrush(selectedBackColor))
                {
                    e.Graphics.FillRectangle(selectedBrush, e.Bounds);
                }
            }
            else
            {
                using (SolidBrush backBrush = new SolidBrush(backColor))
                {
                    e.Graphics.FillRectangle(backBrush, e.Bounds);
                }
            }

            string itemText = e.Index >= 0 ? combo.Items[e.Index].ToString() : combo.Text;
            if (!string.IsNullOrEmpty(itemText))
            {
                TextRenderer.DrawText(
                    e.Graphics,
                    itemText,
                    combo.Font,
                    e.Bounds,
                    ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ? selectedForeColor : foreColor,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
            }

            e.DrawFocusRectangle();
        }
    }
}
