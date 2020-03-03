///     Spyro Reignited Mod Manager
///     Version: 2.0.2
///     File: MainForm.cs
///     Last updated: 2020/03/02
///     Created by: MR.G-bit

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace SpyroModManager
{
    public partial class MainForm : Form
    {
        private string ApplicationDir { get { return AppDomain.CurrentDomain.BaseDirectory; } }
        private string DataDirectory { get { return ApplicationDir; } }
        private string DataFileName { get { return "data.dat"; } }
        private bool IsPathLoaded { get { return !string.IsNullOrWhiteSpace(m_data.m_spyroDir); } }
        private Mod SelectedMod { get { return list_mods.SelectedIndices.Count > 0 ? m_mods[list_mods.SelectedIndices[0]] : null; } }
        private int SelectedIndex { get { return list_mods.SelectedIndices.Count > 0 ? list_mods.SelectedIndices[0] : -1; } set { list_mods.Items[value].Selected = true; } }

        private Data m_data = null;
        private readonly bool m_loading = false;
        private List<Mod> m_mods = new List<Mod>();
        private readonly Timer m_injectorTimer = new Timer();
        private readonly Timer m_processTimer = new Timer();
        private Process m_spyroProcess = null;
        private int m_enabledCount = 0;

        public MainForm()
        {
            InitializeComponent();

            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            FormClosed += OnMainForm_FormClosed;
            Application.Idle += OnApplication_Idle;

            lbl_version.Text = "Version: 2.0.2";

            btn_addMod.Enabled = false;
            btn_launchSpyro.Enabled = false;
            btn_launchOptions.Enabled = false;

            m_injectorTimer.Interval = 1000 * 45;
            m_injectorTimer.Tick += OnInjectorTimer_Tick;
            m_injectorTimer.Enabled = false;

            m_processTimer.Interval = 1000 * 10;
            m_processTimer.Tick += OnProcessTimer_Tick;
            m_processTimer.Enabled = false;

            list_mods.SelectedIndexChanged += OnListMods_SelectedIndexChanged;
            
            m_loading = true;
            InitDataFolder();
            InitModsFolder();
            if (m_data.m_useDiscordRP)
                EnableDiscordRP();
            m_loading = false;
        }

        // Called when the selected index is changed by the user
        private void OnListMods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_mods.Items.Count > 0 && list_mods.SelectedIndices.Count > 0)
                SelectModItem(SelectedIndex);
        }

        // Idle update
        private void OnApplication_Idle(object sender, EventArgs e)
        {
            //if (m_data != null && !m_data.m_openedOnce)
            //{
            //    m_data.m_openedOnce = true;
            //}
        }

        // Deinitialise discord client
        private void OnMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DiscordRP.ClientActive)
                DiscordRP.Deinitialise();
        }

        // When spyro is closed
        private void OnSpyroProcess_Exited(object sender, EventArgs e)
        {
            m_spyroProcess.Exited -= OnSpyroProcess_Exited;
            DiscordRP.SetInModder();
            btn_launchSpyro.Enabled = true;
        }

        // Start the console injector
        private void OnInjectorTimer_Tick(object sender, EventArgs e)
        {
            Process.Start(m_data.m_consoleInjectorPath);
            m_injectorTimer.Enabled = false;

            if (m_data.m_autoClose)
                Close();
        }

        // Check for spyro process after launching the game
        private void OnProcessTimer_Tick(object sender, EventArgs e)
        {
            SetupSpyroProcess(TryGetSpyroProcess());
            m_processTimer.Stop();
        }

        // Create and/or load the data folder
        private void InitDataFolder()
        {
            if (!File.Exists(Path.Combine(DataDirectory, DataFileName)))
            {
                m_data = new Data();
                m_data.Save(Path.Combine(DataDirectory, DataFileName));
            }
            else
            {
                m_data = Data.Load(Path.Combine(DataDirectory, DataFileName));

                if (!string.IsNullOrWhiteSpace(m_data.m_spyroDir))
                    SetSpyroDir(m_data.m_spyroDir);
                if (m_data.m_darkTheme)
                {
                    DarkTheme.ToggleDarkTheme(this, true);
                    chk_toggleDarkTheme.Checked = true;
                }
            }
        }

        // Load mods from the mods folder
        private void InitModsFolder()
        {
            Mod.ModDirectory = Path.Combine(ApplicationDir, "mods");

            if (!Directory.Exists(Mod.ModDirectory))
            {
                Directory.CreateDirectory(Mod.ModDirectory);
            }
            else if (IsPathLoaded)
            {
                List<Mod> mods = new List<Mod>();
                string[] files = Directory.GetFiles(Mod.ModDirectory);
                foreach (string file in files)
                {
                    if (Path.GetExtension(file) != ".mod")
                        continue;
                    Mod mod = Mod.LoadModDetails(file);
                    mod.VerifyPak();
                    if (mod.Enabled)
                        ++m_enabledCount;
                    mods.Add(mod);
                }

                // Add mods to binding list
                m_mods = new List<Mod>(mods.OrderBy(m => m.Order));

                for (int i = 0; i < m_mods.Count; ++i)
                    AddModItem(i);
            }
        }

        // Set up the spyro directory ~disabed and ~mods folders
        private void SetSpyroDir(string spyroDir)
        {
            if (spyroDir != m_data.m_spyroDir)
            {
                m_data.m_spyroDir = spyroDir;
                m_data.Save(Path.Combine(DataDirectory, DataFileName));
            }

            Mod.EnabledPakDirectory = Path.Combine(m_data.m_spyroDir, "Falcon\\Content\\Paks\\~mods");
            Mod.DisabledPakDirectory = Path.Combine(m_data.m_spyroDir, "Falcon\\Content\\~disabled");
            Directory.CreateDirectory(Mod.EnabledPakDirectory);
            Directory.CreateDirectory(Mod.DisabledPakDirectory);

            lbl_pathLoaded.Text = "Path loaded";
            lbl_pathLoaded.ForeColor = Color.Green;
            btn_chooseSpyroExe.Enabled = false;

            btn_addMod.Enabled = true;
            btn_launchSpyro.Enabled = true;
            btn_launchOptions.Enabled = true;
        }

        // Swap order of mod
        private void SwapOrder(uint order, int direction)
        {
            Mod selectedMod = m_mods[(int)order];
            Mod swapWithMod = m_mods[(int)order + direction];

            m_mods[(int)order + direction] = selectedMod;
            m_mods[(int)order] = swapWithMod;

            selectedMod.ChangeOrder((uint)(order + direction));
            swapWithMod.ChangeOrder(order);

            SelectModItem((int)order + direction);
            UpdateModItem((int)order);
        }

        // Select a mod item in the list view
        private void SelectModItem(int index)
        {
            if (SelectedIndex != index)
                SelectedIndex = index;
            
            UpdateModItem(index);

            // Buttons
            btn_Toggle.Enabled = SelectedMod.IsConnectedToPak;
            btn_Toggle.Text = SelectedMod.Enabled ? "Disable" : "Enable";
            btn_moveModDown.Enabled = SelectedIndex < m_mods.Count - 1;
            btn_moveModUp.Enabled = SelectedIndex > 0;
            btn_editMod.Enabled = SelectedMod.IsConnectedToPak;
            btn_updateMod.ForeColor = SelectedMod.IsConnectedToPak ? Color.Black : Color.Red;

            // Mod details
            lbl_modName.Text = "Name: " + SelectedMod.Name;
            lbl_modAuthor.Text = "Author: " + SelectedMod.Author;
            txt_modDescription.Text = SelectedMod.Description;
            lbl_pakConnected.Text = (SelectedMod.IsConnectedToPak ? "Connected to .pak file" + "\nFile name: " + SelectedMod.PakFileName : "Not connected to .pak file.\nClick \"Update .pak File\" to set a new .pak file.");
            lbl_pakConnected.ForeColor = SelectedMod.IsConnectedToPak ? Color.Green : Color.Red;
            pic_modImage.Image = SelectedMod.Image == null ? Properties.Resources.image_spyroVersion_boxart : SelectedMod.Image;
        }

        // Update a specific mod item in the list view
        private void UpdateModItem(int index)
        {
            ListViewItem listViewItem = list_mods.Items[index];
            Mod mod = m_mods[index];
            listViewItem.UseItemStyleForSubItems = false;
            listViewItem.Text = mod.Order.ToString();
            listViewItem.SubItems[1].Text = mod.Enabled ? "Enabled" : "Disabled";
            listViewItem.SubItems[1].BackColor = mod.Enabled ? Color.FromArgb(176, 255, 197) : Color.FromArgb(255, 176, 176);
            listViewItem.SubItems[2].Text = mod.Name;

            if (m_enabledCount == 0)
                btn_disableAll.Text = "Enable All";
            else
                btn_disableAll.Text = "Disable All";
        }

        // Add a mod item in the list view
        private void AddModItem(int index)
        {
            ListViewItem listViewItem = new ListViewItem("");
            listViewItem.SubItems.Add("");
            listViewItem.SubItems.Add("");
            list_mods.Items.Add(listViewItem);
            UpdateModItem(index);
        }

        // Remove a mod item in the list view
        private void RemoveModItem(int index)
        {
            list_mods.Items.RemoveAt(index);
        }

        // Enable or disable the intro cutscene files
        private void ToggleCutsceneFiles(bool enabled)
        {
            string cutsceneDir = Path.Combine(m_data.m_spyroDir, "Falcon\\Content\\Movies");
            ToggleCutscene(cutsceneDir, "BumperATVI.mp4", enabled);
            ToggleCutscene(cutsceneDir, "BumperATVI_Gamma.mp4", enabled);
            ToggleCutscene(cutsceneDir, "BumperTFB.mp4", enabled);
            ToggleCutscene(cutsceneDir, "BumperTFB_Gamma.mp4", enabled);
            ToggleCutscene(cutsceneDir, "BumperUnreal.mp4", enabled);
            ToggleCutscene(cutsceneDir, "BumperUnreal_Gamma.mp4", enabled);
        }

        // Toggle a given cutscene
        private void ToggleCutscene(string cutsceneDir, string cutsceneName, bool enabled)
        {
            if (!enabled)
                File.Move(Path.Combine(cutsceneDir, cutsceneName), Path.Combine(cutsceneDir, cutsceneName + ".no"));
            else
                File.Move(Path.Combine(cutsceneDir, cutsceneName + ".no"), Path.Combine(cutsceneDir, cutsceneName));
        }

        // Enable the discord rp
        private void EnableDiscordRP()
        {
            DiscordRP.Initialise("", "");
            if (!SetupSpyroProcess(TryGetSpyroProcess()))
                DiscordRP.SetInModder();
            DiscordRP.SetSpyroVersion(m_data.m_spyroVersion);

            lbl_discordRPEnabled.Text = "Discord Rich Presence is enabled";
            lbl_discordRPEnabled.ForeColor = Color.Green;
        }

        // Disable the discord rp
        private void DisableDiscordRP()
        {
            DiscordRP.Deinitialise();

            lbl_discordRPEnabled.Text = "Discord Rich Presence is disabled";
            lbl_discordRPEnabled.ForeColor = Color.Red;
        }

        // Get number of mods enabled
        private int GetNumberOfActiveMods()
        {
            int count = 0;
            foreach (Mod mod in m_mods)
                if (mod.IsConnectedToPak && mod.Enabled)
                    ++count;
            return count;
        }

        // Try to get the spyro process
        private Process TryGetSpyroProcess()
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
                if (process.ProcessName == "Spyro-Win64-Shipping")
                    return process; 
            return null;
        }

        // Setup the spyro process
        private bool SetupSpyroProcess(Process process)
        {
            m_spyroProcess = process;
            if (m_spyroProcess != null)
            {
                m_spyroProcess.EnableRaisingEvents = true;
                m_spyroProcess.Exited += OnSpyroProcess_Exited;
                DiscordRP.SetInGame(GetNumberOfActiveMods());
                btn_launchSpyro.Enabled = false;
                return true;
            }
            return false;
        }

        // Choose Spyro exe
        private void btn_chooseSpyroExe_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Title = "Choose Spyro.exe",
                Filter = "Spyro (*.exe)|*.exe",
                Multiselect = false
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                m_data.m_spyroExePath = fileDialog.FileName;
                SetSpyroDir(Path.GetDirectoryName(fileDialog.FileName));
            }
        }

        // Add mods
        private void btn_addMod_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Title = "Choose mod file",
                Filter = "Mod (*.pak)|*.pak",
                Multiselect = false
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                Mod mod = new Mod();
                EditModForm editModForm = new EditModForm(mod, Path.GetFileName(fileDialog.FileName), Path.GetFileNameWithoutExtension(fileDialog.FileName));
                if (editModForm.ShowDialog() == DialogResult.OK)
                {
                    mod.Name = editModForm.ModName;
                    mod.Author = editModForm.ModAuthor;
                    mod.Description = editModForm.ModDescription;
                    mod.Image = editModForm.ModImage;
                    mod.Order = (uint)m_mods.Count;
                    mod.ConnectPak(fileDialog.FileName);
                    mod.SaveModDetails();

                    m_mods.Add(mod);
                    AddModItem(m_mods.Count - 1);
                    SelectModItem(m_mods.Count - 1);
                }
            }
        }

        // Enable or disable the selected mod
        private void btn_Toggle_Click(object sender, EventArgs e)
        {
            if (m_mods.Count == 0 || SelectedMod == null)
                return;

            if (SelectedMod.IsConnectedToPak)
            {
                if (SelectedMod.Enabled)
                {
                    SelectedMod.DisableMod();
                    --m_enabledCount;
                }
                else
                {
                    SelectedMod.EnableMod();
                    ++m_enabledCount;
                }

                UpdateModItem(SelectedIndex);
            }
        }

        // Move selected mod up in the list
        private void btn_moveModUp_Click(object sender, EventArgs e)
        {
            if (m_mods.Count == 0 || SelectedMod == null)
                return;

            SwapOrder(SelectedMod.Order, -1);
        }

        // Move selected mod down in the list
        private void btn_moveModDown_Click(object sender, EventArgs e)
        {
            if (m_mods.Count == 0 || SelectedMod == null)
                return;

            SwapOrder(SelectedMod.Order, +1);
        }

        // Remove selected mod
        private void btn_RemoveMod_Click(object sender, EventArgs e)
        {
            if (m_mods.Count == 0 || SelectedMod == null)
                return;

            // Delete files off disk
            if (SelectedMod.IsConnectedToPak)
                File.Delete(Path.Combine(SelectedMod.PakDirectory, SelectedMod.PakFileName));
            File.Delete(Path.Combine(Mod.ModDirectory, SelectedMod.ModFileName));

            int selectedIndex = SelectedIndex;
            for (int i = selectedIndex + 1; i < m_mods.Count; ++i)
            {
                m_mods[i].ChangeOrder(m_mods[i].Order - 1);
                UpdateModItem(i);
            }

            if (SelectedMod.Enabled)
                --m_enabledCount;

            m_mods.RemoveAt(selectedIndex);
            RemoveModItem(selectedIndex);

            if (m_mods.Count > 0)
                SelectModItem(Math.Min(selectedIndex, m_mods.Count - 1));
        }

        // Edit the selected mod
        private void btn_editMod_Click(object sender, EventArgs e)
        {
            if (m_mods.Count == 0 || SelectedMod == null)
                return;

            EditModForm editModForm = new EditModForm(SelectedMod, SelectedMod.PakFileName);

            if (editModForm.ShowDialog() == DialogResult.OK)
            {
                SelectedMod.ChangeName(editModForm.ModName);
                SelectedMod.Author = editModForm.ModAuthor;
                SelectedMod.Description = editModForm.ModDescription;
                SelectedMod.Image = editModForm.ModImage;
                SelectedMod.SaveModDetails();
                UpdateModItem(SelectedIndex);
            }
        }

        // Update mod and replace .pak file
        private void btn_updateMod_Click(object sender, EventArgs e)
        {
            if (m_mods.Count == 0 || SelectedMod == null)
                return;

            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Title = "Choose updated mod file",
                Filter = "Mod (*.pak)|*.pak",
                Multiselect = false
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (SelectedMod.IsConnectedToPak)
                    File.Delete(Path.Combine(SelectedMod.PakDirectory, SelectedMod.PakFileName));
                SelectedMod.ConnectPak(fileDialog.FileName);
                UpdateModItem(SelectedIndex);
                MessageBox.Show("Updated .pak file.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Toggle dark theme
        private void chk_toggleDarkTheme_CheckedChanged(object sender, EventArgs e)
        {
            if (m_loading) return;

            DarkTheme.ToggleDarkTheme(this, !DarkTheme.IsDarkTheme);
            m_data.m_darkTheme = DarkTheme.IsDarkTheme;
            m_data.Save(Path.Combine(DataDirectory, DataFileName));
        }

        // Launch game
        private void btn_launchSpyro_Click(object sender, EventArgs e)
        {
            Process.Start(m_data.m_spyroExePath);
            m_processTimer.Start();

            if (m_data.m_useConsoleInjector)
            {
                if (File.Exists(m_data.m_consoleInjectorPath))
                    m_injectorTimer.Start();
                else
                    MessageBox.Show("Console Injector not linked.", "Hold up!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (m_data.m_backupSave)
            {
                if (File.Exists(m_data.m_savePath))
                {
                    string saveDirectory = Path.GetDirectoryName(m_data.m_savePath);
                    if (!Directory.Exists(Path.Combine(saveDirectory, "Backups")))
                        Directory.CreateDirectory(Path.Combine(saveDirectory, "Backups"));
                    File.Copy(m_data.m_savePath, Path.Combine(saveDirectory, "Backups", DateTime.Now.ToString("yyyy_dd_M__HH_mm_ss") + " " + Path.GetFileName(m_data.m_savePath) + ".backup"));
                }
                else
                    MessageBox.Show("Save file not linked.", "Hold up!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (m_data.m_autoClose && !m_data.m_useConsoleInjector)
                Close();
        }

        // Open launch options dialog
        private void btn_launchOptions_Click(object sender, EventArgs e)
        {
            FormLaunchOptions launchOptions = new FormLaunchOptions(new Data(m_data));

            if (launchOptions.ShowDialog() == DialogResult.OK)
            {
                m_data.m_useConsoleInjector = launchOptions.UseConsoleInjector;
                m_data.m_consoleInjectorPath = launchOptions.ConsoleInjectorPath;

                m_data.m_backupSave = launchOptions.BackupSave;
                m_data.m_savePath = launchOptions.SavePath;

                if (m_data.m_skipIntroCutscenes != launchOptions.SkipIntroCutscenes)
                    ToggleCutsceneFiles(!launchOptions.SkipIntroCutscenes);
                m_data.m_skipIntroCutscenes = launchOptions.SkipIntroCutscenes;

                m_data.m_vanilla = launchOptions.Vanilla;
                m_data.m_autoClose = launchOptions.AutoCloseLauncher;

                m_data.Save(Path.Combine(DataDirectory, DataFileName));
            }
        }

        // Open discord rp settings
        private void btn_discordSettings_Click(object sender, EventArgs e)
        {
            FormDiscordRP formDiscordRP = new FormDiscordRP(new Data(m_data));

            if (formDiscordRP.ShowDialog() == DialogResult.OK)
            {
                m_data.m_spyroVersion = formDiscordRP.SpyroVersion;
                m_data.m_useDiscordRP = formDiscordRP.UseDiscordRP;

                if (m_data.m_useDiscordRP && DiscordRP.ClientActive)
                    DiscordRP.SetSpyroVersion(m_data.m_spyroVersion);
                else if (m_data.m_useDiscordRP && !DiscordRP.ClientActive)
                    EnableDiscordRP();
                else if (DiscordRP.ClientActive)
                    DisableDiscordRP();

                m_data.Save(Path.Combine(DataDirectory, DataFileName));
            }
        }

        // Disable all mods
        private void btn_disableAll_Click(object sender, EventArgs e)
        {
            if (m_mods.Count == 0)
                return;

            if (m_enabledCount > 0)
            {
                m_enabledCount = 0;
                for (int i = 0; i < m_mods.Count; ++i)
                {
                    m_mods[i].DisableMod();
                    UpdateModItem(i);
                }
            }
            else
            {
                m_enabledCount = m_mods.Count;
                for (int i = 0; i < m_mods.Count; ++i)
                {
                    m_mods[i].EnableMod();
                    UpdateModItem(i);
                }
            }
        }

        // Show list of cheat codes
        private void btn_showCheatList_Click(object sender, EventArgs e)
        {
            FormCheatCodeList formCheatCodeList = new FormCheatCodeList(new Data(m_data));
            
            if (formCheatCodeList.ShowDialog() != DialogResult.No)
            {
                m_data.m_preferredInput = formCheatCodeList.PreferredInput;
                m_data.Save(Path.Combine(DataDirectory, DataFileName));
            }
        }

        // Show list of level codes
        private void btn_levelCodes_Click(object sender, EventArgs e)
        {
            FormLevelCodeList levelCodeList = new FormLevelCodeList();
            levelCodeList.ShowDialog();
        }
    }
}
