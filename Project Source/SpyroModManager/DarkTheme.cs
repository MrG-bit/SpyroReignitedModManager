///     Spyro Reignited Mod Manager
///     File: DarkTheme.cs
///     Last updated: 2020/02/28
///     Created by: MR.G-bit

using System.Drawing;
using System.Windows.Forms;

namespace SpyroModManager
{
    public static class DarkTheme
    {
        public static bool IsDarkTheme { get; private set; } = false;

        // Form
        public static readonly Color _formDarkBackColour = Color.FromArgb(35, 39, 42);
        public static readonly Color _formLightBackColour = SystemColors.Control;

        // Label, group box, checkbox
        public static readonly Color _lblDarkForeColour = Color.White;
        public static readonly Color _lblLightForeColour = SystemColors.ControlText;

        // Text box, combo box
        public static readonly Color _txtDarkForeColour = Color.White;
        public static readonly Color _txtDarkBackColour = Color.FromArgb(44, 47, 51);
        public static readonly Color _txtLightForeColour = SystemColors.WindowText;
        public static readonly Color _txtLightBackColour = SystemColors.Window;

        // Listbox, listview
        public static readonly Color _listDarkForeColour = Color.White;
        public static readonly Color _listDarkBackColour = Color.FromArgb(44, 47, 51);
        public static readonly Color _listLightForeColour = SystemColors.WindowText;
        public static readonly Color _listLightBackColour = SystemColors.Window;

        public static void ToggleDarkTheme(Form form, bool enabled)
        {
            IsDarkTheme = enabled;

            form.BackColor = enabled ? _formDarkBackColour : _formLightBackColour;

            foreach (Control control in form.Controls)
                ToggleDarkTheme(control, enabled);
        }

        private static void ToggleDarkTheme(Control control, bool enabled)
        {
            if ((string)control.Tag == "IgnoreTheme")
                return;

            if (control is Label || control is CheckBox)
            {
                control.ForeColor = enabled ? _lblDarkForeColour : _lblLightForeColour;
            }
            else if (control is TextBox || control is ComboBox)
            {
                control.ForeColor = enabled ? _txtDarkForeColour : _txtLightForeColour;
                control.BackColor = enabled ? _txtDarkBackColour : _txtLightBackColour;
            }
            else if (control is GroupBox)
            {
                GroupBox groupBox = (GroupBox)control;
                Color[] colours = new Color[groupBox.Controls.Count];
                for (int i = 0; i < colours.Length; ++i)
                    colours[i] = groupBox.Controls[i].ForeColor;

                groupBox.ForeColor = enabled ? _lblDarkForeColour : _lblLightForeColour;

                for (int i = 0; i < colours.Length; ++i)
                {
                    groupBox.Controls[i].ForeColor = colours[i];
                    ToggleDarkTheme(groupBox.Controls[i], enabled);
                }
            }
            else if (control is ListBox || control is ListView)
            {
                control.ForeColor = enabled ? _listDarkForeColour : _listLightForeColour;
                control.BackColor = enabled ? _listDarkBackColour : _listLightBackColour;
            }
        }
    }
}
