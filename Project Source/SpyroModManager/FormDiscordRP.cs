///     Spyro Reignited Mod Manager
///     File: FormDiscordRP.cs
///     Last updated: 2020/02/28
///     Created by: MR.G-bit

using System;
using System.Windows.Forms;

namespace SpyroModManager
{
    public partial class FormDiscordRP : Form
    {
        public bool UseDiscordRP { get; private set; }
        public int SpyroVersion { get; private set; }

        public FormDiscordRP(Data dataCopy)
        {
            InitializeComponent();

            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            DarkTheme.ToggleDarkTheme(this, DarkTheme.IsDarkTheme);

            chk_useDiscordRP.Checked = dataCopy.m_useDiscordRP;
            combo_spyroVersion.SelectedIndex = dataCopy.m_spyroVersion;
        }

        // Confirm
        private void btn_confirm_Click(object sender, EventArgs e)
        {
            UseDiscordRP = chk_useDiscordRP.Checked;
            SpyroVersion = combo_spyroVersion.SelectedIndex;

            DialogResult = DialogResult.OK;
            Close();
        }

        // Cancel
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
