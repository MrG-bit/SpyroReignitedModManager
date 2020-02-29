///     Spyro Reignited Mod Manager
///     File: FormLaunchOptions.cs
///     Last updated: 2020/02/29
///     Created by: MR.G-bit

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SpyroModManager
{
    public partial class FormLaunchOptions : Form
    {
        public bool UseConsoleInjector { get; private set; } = false;
        public string ConsoleInjectorPath { get; private set; } = "";
        public bool Vanilla { get; private set; } = false;
        public bool SkipIntroCutscenes { get; private set; } = false;
        public bool BackupSave { get; private set; } = false;
        public string SavePath { get; private set; } = "";
        public bool AutoCloseLauncher { get; private set; } = false;

        public FormLaunchOptions(Data dataCopy)
        {
            InitializeComponent();

            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            DarkTheme.ToggleDarkTheme(this, DarkTheme.IsDarkTheme);

            if (string.IsNullOrWhiteSpace(dataCopy.m_consoleInjectorPath) || !File.Exists(dataCopy.m_consoleInjectorPath))
            {
                chk_consoleInjector.Enabled = false;
                lbl_linkedInjector.Text = "Console Injector not linked";
                lbl_linkedInjector.ForeColor = Color.Red;
            }
            else
            {
                ConsoleInjectorPath = dataCopy.m_consoleInjectorPath;
                chk_consoleInjector.Checked = dataCopy.m_useConsoleInjector;
                lbl_linkedInjector.Text = "Console Injector linked";
                lbl_linkedInjector.ForeColor = Color.Green;
            }

            if (string.IsNullOrWhiteSpace(dataCopy.m_savePath) || !File.Exists(dataCopy.m_savePath))
            {
                chk_backupSave.Enabled = false;
                btn_clearBackups.Enabled = false;
                btn_manageBackups.Enabled = false;
                lbl_linkedSaveDir.Text = "Save file not linked";
                lbl_linkedSaveDir.ForeColor = Color.Red;
            }
            else
            {
                SavePath = dataCopy.m_savePath;
                chk_backupSave.Checked = dataCopy.m_backupSave;
                btn_clearBackups.Enabled = true;
                btn_manageBackups.Enabled = true;
                lbl_linkedSaveDir.Text = "Save file linked";
                lbl_linkedSaveDir.ForeColor = Color.Green;
            }

            chk_skipCutscenes.Checked = dataCopy.m_skipIntroCutscenes;
            //chk_vanilla.Checked = dataCopy.m_vanilla;
            chk_closeLauncher.Checked = dataCopy.m_autoClose;
        }

        // Cancel the form
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // Confirm the options
        private void btn_confirm_Click(object sender, EventArgs e)
        {
            UseConsoleInjector = chk_consoleInjector.Checked;
            BackupSave = chk_backupSave.Checked;
            SkipIntroCutscenes = chk_skipCutscenes.Checked;
            //Vanilla = chk_vanilla.Checked;
            AutoCloseLauncher = chk_closeLauncher.Checked;

            DialogResult = DialogResult.OK;
            Close();
        }

        // Open website to download the console injector
        private void btn_downloadInjector_Click(object sender, EventArgs e)
        {
            Process.Start("https://steamcommunity.com/sharedfiles/filedetails/?id=1858593302");
        }

        // Choose the console injector executable
        private void btn_injectorPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Choose the Console Injector Executable",
                Filter = "Console Injector (*.exe)|*.exe",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ConsoleInjectorPath = openFileDialog.FileName;
                chk_consoleInjector.Enabled = true;
                lbl_linkedInjector.Text = "Console Injector linked";
                lbl_linkedInjector.ForeColor = Color.Green;
            }
        }

        // Choose the save file
        private void btn_chooseSaveDir_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Choose FalconSave.106.sav",
                Filter = "Save file (*.sav)|*.sav",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SavePath = openFileDialog.FileName;
                chk_backupSave.Enabled = true;
                btn_clearBackups.Enabled = true;
                btn_manageBackups.Enabled = true;
                lbl_linkedSaveDir.Text = "Save file linked";
                lbl_linkedSaveDir.ForeColor = Color.Green;
            }
        }

        // Clear backup files
        private void btn_clearBackups_Click(object sender, EventArgs e)
        {
            string saveDir = Path.GetDirectoryName(SavePath);
            if (Directory.Exists(Path.Combine(saveDir, "Backups")))
            {
                Directory.Delete(Path.Combine(saveDir, "Backups"), true);
                MessageBox.Show("Cleared backups.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        // Open directory containing backups
        private void btn_manageBackups_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Path.GetDirectoryName(SavePath));
        }
    }
}
