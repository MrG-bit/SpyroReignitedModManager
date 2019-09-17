using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

// File: MainForm.cs
// Created by: MRG-bit
// Last edited: 15/09/2019

namespace SpyroModManager
{
    /// <summary>
    /// Main form of the mod manager.
    /// </summary>
    public partial class MainForm : Form
    {
        // Version number of the program
        private Version version = new Version(1, 3, 0);

        private string spyroPath = "";          // File path to Spyro.exe (in Steam folders)
        private string paksModPath = "";        // Path to the pak folder (in Steam folders)
        private string pakPath = "";            // Path to normal pak folder
        private string disabledPakModsPath = "";// Path to disabled mod folder
        private string saveFilePath = "";       // Path to the save file folder
        private string moviePath = "";          // Path to the movie folder (in Steam folders)
        private bool wasSpyroOpen = false;      // Keep track of if spyro was open last time checked
        private Timer injectorTimer = null;     // Timer for opening the injector executable
        private Timer cutsceneTimer = null;     // Timer for re-enabling the cutscenes
        private ModManagerData data;            // Reference to the mod manager data
        private int highestOrder = 0;           // Largest order

        // List of mods loaded into the manager
        private BindingList<SpyroMod> mods = new BindingList<SpyroMod>();

        public static bool IsSpyroOpen { get { return IsProcessOpen("Spyro"); } }
        private bool IsValidSpyroPath { get { return spyroPath != "" && spyroPath.ToLower().EndsWith("spyro.exe"); } }
        private bool IsValidInjectorPath { get { return data != null && !string.IsNullOrWhiteSpace(data.injectorPath) && data.injectorPath.ToLower().EndsWith(".exe") && File.Exists(data.injectorPath); } }
        private bool IsVanilla { get { return checkVanilla.Checked; } }
        private bool DoBackupSave { get { return checkBackupSave.Checked; } }
        private bool ModFolderExists { get { return Directory.Exists(PathToModsFolder); } }
        private bool DataFileExists { get { return File.Exists(PathToDataFile); } }
        private string PathToModsFolder { get { return Application.StartupPath + "\\Spyro Reignited Mods"; } }
        private string PathToDataFile { get { return Application.StartupPath + "\\Data.dat"; } }
        private string PathToSpyroGame { get { return IsValidSpyroPath ?  spyroPath.Remove(spyroPath.Length - 9, 9) : ""; }        }
        private string PathToSaveBackups { get { return saveFilePath + "Backups\\"; } }
        private string NewLine { get { return Environment.NewLine; } }
        private SpyroMod SelectedMod { get { if (listMods.SelectedIndex >= 0 && listMods.SelectedIndex < mods.Count) return mods[listMods.SelectedIndex]; else return null; } }

        /// <summary>
        /// Constructor.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // Hook into idle
            Application.Idle += OnApplicationIdle;

            // Hook to close
            FormClosed += OnFormClose;

            // Set form title
            Text = "Spyro Reignited Mod Manager";

            // Disable maximise button
            MaximizeBox = false;

            // Disable form resizing
            FormBorderStyle = FormBorderStyle.FixedDialog;

            // Create timer for injector
            injectorTimer = new Timer
            {
                Interval = 20000,
                Enabled = false
            };
            injectorTimer.Tick += OnInjectorTimerElapsed;

            // Create timer for cutscenes
            cutsceneTimer = new Timer
            {
                Interval = 30000,
                Enabled = false
            };
            cutsceneTimer.Tick += OnCutsceneTimerElapsed;

            // Set the version label text
            lblVersion.Text += version.ToString();

            // Initialise the mod folder
            InitModFolder();

            // Initialise the data file
            InitDataFile();
            
            // Link the list box to the list of mods
            listMods.DataSource = mods;
        }

        /// <summary>
        /// Called when the form is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFormClose(object sender, FormClosedEventArgs e)
        {
            // If the cutscene timer is active, revert the cutscenes straight away
            if (cutsceneTimer.Enabled)
                OnCutsceneTimerElapsed(null, null);
        }

        /// <summary>
        /// Called when the cutscene timer elapses.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCutsceneTimerElapsed(object sender, EventArgs e)
        {
            // Re-enable the cutscenes
            string[] files = Directory.GetFiles(moviePath);

            // Iterate through the files
            foreach (string file in files)
            {
                // Get file info
                FileInfo fileInfo = new FileInfo(file);

                // Check if is a bumper movie file
                if (fileInfo.Name.ToLower().StartsWith("_bumper") && fileInfo.Extension.ToLower() == ".mp4")
                {
                    // Get the new name (remove the underscore)
                    string newFileName = fileInfo.Name.Remove(0, 1);

                    // Rename the file
                    File.Move(fileInfo.FullName, moviePath + newFileName);
                }
            }

            // Stop the timer from repeating
            cutsceneTimer.Stop();
        }

        /// <summary>
        /// Called when the injector timer elapses.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnInjectorTimerElapsed(object sender, EventArgs e)
        {
            // Check if spyro is open
            if (IsSpyroOpen)
            {
                // Stop the timer from repeating
                injectorTimer.Stop();

                // Create a process start info object
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = data.injectorPath,
                    WorkingDirectory = new FileInfo(data.injectorPath).Directory.FullName
                };

                // Start the process
                Process.Start(processStartInfo);
            }
        }

        /// <summary>
        /// Called when nothing in event queue.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnApplicationIdle(object sender, EventArgs e)
        {
            // Check if spyro is open
            bool isSpyroOpen = IsSpyroOpen;

            // State changed
            if (isSpyroOpen != wasSpyroOpen)
            {
                // Spyro was opened
                if (isSpyroOpen)
                {
                    // Disable the checkboxes
                    checkVanilla.Enabled = false;
                    checkConsoleInjector.Enabled = false;
                    checkSkipIntro.Enabled = false;
                    checkBackupSave.Enabled = false;

                    // Disable buttons
                    btnLaunchSpyro.Enabled = false;
                    btnAddMod.Enabled = false;
                }
                // Otherwise spyro was closed
                else
                {
                    // Enable the checkboxes
                    checkVanilla.Enabled = true;
                    checkConsoleInjector.Enabled = true;
                    checkSkipIntro.Enabled = true;
                    checkBackupSave.Enabled = true;

                    // Enable buttons
                    btnLaunchSpyro.Enabled = true;
                    btnAddMod.Enabled = true;

                    // Update vanilla and set files
                    SetVanilla(checkVanilla.Checked);
                }
            }

            // Update old variable
            wasSpyroOpen = isSpyroOpen;
        }

        /// <summary>
        /// Initialise mod folder.
        /// </summary>
        private void InitModFolder()
        {
            // Check if the mod folder exists
            if (!ModFolderExists)
            {
                // Create the mods folder
                Directory.CreateDirectory(PathToModsFolder);
            }
            // Otherwise, load the mods folder
            else
            {
                // Get all the files in the folder
                string[] modFiles = Directory.GetFiles(PathToModsFolder);

                // Create a list for the mods (to sort)
                List<SpyroMod> mods = new List<SpyroMod>();

                // Iterate over each file
                foreach (string filePath in modFiles)
                {
                    // Check that the file is a mod file
                    if (filePath.ToLower().EndsWith(SpyroMod.fileExtension))
                    {
                        // Load the mod
                        SpyroMod mod = SpyroMod.LoadFromFile(filePath);

                        // Find the highest order
                        highestOrder = Math.Max(highestOrder, mod.order);
                        
                        // Add mod to list
                        mods.Add(mod);
                    }
                }

                // Sort the mods by mod.order
                mods.Sort((SpyroMod a, SpyroMod b) =>
                {
                    if (a.order > b.order) return 1;
                    else if (a.order < b.order) return -1;
                    else return 0;
                });

                // Update the list of mods with the sorted list
                this.mods = new BindingList<SpyroMod>(mods);
            }
        }

        /// <summary>
        /// Initialise data file.
        /// </summary>
        private void InitDataFile()
        {
            // Create data file if not found
            if (!DataFileExists)
            {
                // Create a new instance
                data = new ModManagerData();
                ValidateDataObject();
                SaveToDataFile(data);

            }
            // Otherwise, load the data file
            else
            {
                // Create a formatter
                IFormatter formatter = new BinaryFormatter();

                // Open the stream
                Stream stream = new FileStream(PathToDataFile, FileMode.Open, FileAccess.Read);

                // Deserialise
                data = (ModManagerData)formatter.Deserialize(stream);

                // Close the stream
                stream.Close();

                // Validate contents of the data file
                ValidateDataObject();

                // Set if vanilla or not
                SetVanilla(data.isVanilla);

                // Set checkbox for auto save
                checkBackupSave.Checked = data.saveBackup;

                // Set checkbox for console injector
                checkConsoleInjector.Checked = data.useInjector;

                // Set checkbox for skipping cutscenes
                checkSkipIntro.Checked = data.skipIntro;

                // Try to load the spyro path that's in the config
                SelectSpyroPath(data.spyroPath);
            }
        }

        /// <summary>
        /// Validate the data object if it has been added to or is brand new.
        /// </summary>
        private void ValidateDataObject()
        {
            // Return if data is null
            if (data == null)
                return;

            // Validate path
            if (data.spyroPath == null)
            {
                // Try to load the path automatically

                // Drive letter
                char drive = 'C';

                // Path to Spyro.exe
                string path = ":\\Program Files (x86)\\Steam\\steamapps\\common\\Spyro Reignited Trilogy\\Spyro.exe";

                // Check if the path is valid on either the C drive or D drive
                if (File.Exists(drive.ToString() + path) || File.Exists((++drive).ToString() + path))
                {
                    // Select the path
                    SelectSpyroPath(drive.ToString() + path);
                }
                // Otherwise set the path to an empty string
                else
                {
                    // Set to empty string
                    data.spyroPath = "";
                }
            }

            // Validate injector path
            if (data.injectorPath == null)
            {
                // Set to an empty string
                data.injectorPath = "";
            }
        }       

        /// <summary>
        /// Save information to the data file.
        /// </summary>
        private void SaveToDataFile(ModManagerData data)
        {
            // Return if data is null
            if (data == null)
                return;

            // Create a formatter
            IFormatter formatter = new BinaryFormatter();

            // Open the stream
            Stream stream = new FileStream(PathToDataFile, FileMode.Create, FileAccess.Write);

            // Serialise
            formatter.Serialize(stream, data);

            // Close the stream
            stream.Close();
        }

        /// <summary>
        /// Save a mod to the mod folder.
        /// </summary>
        /// <param name="mod">Mod to save.</param>
        private void SaveToModsFolder(SpyroMod mod)
        {
            // Check that the mod folder exists and the mod isn't null
            if (!ModFolderExists || mod == null || IsSpyroOpen)
                return;

            // Save mod to mods folder
            mod.SaveToFile(PathToModsFolder + "\\" + mod.fileName);
        }

        /// <summary>
        /// Select the path to Spyro.exe (in Steam folders).
        /// </summary>
        /// <param name="spyroPath">Path to Spyro.exe.</param>
        /// <param name="updateDataFile">Should the data file be updated with this path.</param>
        private void SelectSpyroPath(string spyroPath)
        {
            // Check that the file is Spyro.exe
            if (spyroPath.ToLower().EndsWith("spyro.exe"))
            {
                // Update the path variable
                this.spyroPath = spyroPath;

                // Update the spyro path label
                lblSpyroPath.Text = "Spyro.exe path: " + spyroPath;

                // Determine the og pak path
                pakPath = PathToSpyroGame + "Falcon\\Content\\Paks\\";

                // Clear mods from paks folder
                string[] pakFiles = Directory.GetFiles(pakPath);

                // Iterate over the files
                foreach (string fileName in pakFiles)
                {
                    // Get info on the file
                    FileInfo fileInfo = new FileInfo(fileName);
                    
                    // Check if file is under 6 gigabytes
                    if (fileInfo.Extension == ".pak" && fileInfo.Length <= 6442450944)
                    {
                        // Delete the pak file
                        File.Delete(fileName);
                    }
                }

                // Determine the pak mod path
                paksModPath = PathToSpyroGame + "Falcon\\Content\\Paks\\~mods\\";
                Directory.CreateDirectory(paksModPath);

                // Determine the disabled pak path
                disabledPakModsPath = PathToSpyroGame + "Falcon\\Content\\~disabled\\";
                Directory.CreateDirectory(disabledPakModsPath);

                // Determine the save file path
                saveFilePath = FindSaveFilePath();
                Directory.CreateDirectory(PathToSaveBackups);

                // Check if not running vanilla
                if (!IsVanilla)
                {
                    // Validate mods
                    string[] enabledModFiles = Directory.GetFiles(paksModPath);
                    string[] disabledModFiles = Directory.GetFiles(disabledPakModsPath);

                    // Iterate through the file names
                    for (int i = 0; i < enabledModFiles.Length + disabledModFiles.Length; ++i)
                    {
                        // Check if in the enabled folder or disabled folders
                        bool inEnabledFolder = i < enabledModFiles.Length;

                        // Get the file name
                        string fileName = (inEnabledFolder ? enabledModFiles[i] : disabledModFiles[i - enabledModFiles.Length]);

                        // Get file info
                        FileInfo fileInfo = new FileInfo(fileName);

                        // Spyro mod
                        SpyroMod mod;

                        // Check that the mod exists
                        if (fileInfo.Extension == ".pak" && ModExists(fileInfo.Name, out mod))
                        {
                            // Enable and save
                            mod.enabled = inEnabledFolder;
                            SaveToModsFolder(mod);
                        }
                        // Otherwise delete the file
                        else
                        {
                            // Delete the file
                            File.Delete(fileName);
                        }
                    }
                }

                // Determine the movie path
                moviePath = PathToSpyroGame + "Falcon\\Content\\Movies\\";

                // Update the path loaded label
                lblPathLoaded.Text = "Path loaded";
                lblPathLoaded.ForeColor = Color.Green;

                // Update path labels
                lblSpyroPath.Text = "Spyro.exe: " + PathToSpyroGame;
                lblSavePath.Text = "Save folder: " + saveFilePath;

                // Update data file
                data.spyroPath = this.spyroPath;
                SaveToDataFile(data);

                // Disable button
                btnSpyroPath.Enabled = false;
            }
        }

        /// <summary>
        /// Add a new mod.
        /// </summary>
        /// <param name="modPath">Path to the .pak or .srtmod file.</param>
        private void AddNewMod(string modPath, bool fromPak)
        {
            // Return if spyro.exe path isn't loaded
            if (!IsValidSpyroPath || IsSpyroOpen)
                return;

            SpyroMod mod;                       // Mod being loaded
            bool deleteOriginal = false;        // Delete the original file

            // Check if loading a .pak file
            if (fromPak)
            {
                // Create a mod form
                ModForm modForm = new ModForm(modPath, null);

                // Check that the form closed OK
                if (modForm.ShowDialog() == DialogResult.OK)
                {
                    // Create a new mod
                    mod = new SpyroMod(modForm.ModName + SpyroMod.fileExtension, false, modForm.ModName, modForm.ModCreator, modForm.ModDescription);

                    // Add the .pak data
                    mod.ImportPak(modPath);

                    // Set the thumbnail
                    mod.SetThumbnail(modForm.ThumbnailPath);

                    // Set to delete the original pak file if the user wants to
                    deleteOriginal = modForm.DeletePakFile;
                }
                else
                    return;
            }
            // Otherwise loading a .srtmod file
            else
            {
                // Load the mod
                mod = SpyroMod.LoadFromFile(modPath);

                // Flag to delete the original file
                deleteOriginal = true;
            }

            // Validate file name
            ValidateFilename(mod, 0);

            // Init the mod disabled
            mod.enabled = false;

            // Set order
            //mod.order = mods.Count;
            mod.order = ++highestOrder;

            // Add mod to list of mods
            mods.Add(mod);

            // Change selected mod to the new mod
            listMods.SelectedIndex = mods.Count - 1;

            // If this is the first mod, force update the mod information
            if (listMods.SelectedIndex == 0)
                SelectedModChanged();

            // Check if should delete the original file
            if (deleteOriginal)
            {
                // Delete the file
                File.Delete(modPath);
            }

            // Save to mods folder
            SaveToModsFolder(mod);
        }

        /// <summary>
        /// Set whether running with mods or in vanilla.
        /// </summary>
        /// <param name="vanilla">Value.</param>
        private void SetVanilla(bool vanilla)
        {
            // Set the checkbox
            checkVanilla.Checked = vanilla;

            // Save to data file
            data.isVanilla = vanilla;
            SaveToDataFile(data);
            
            // Check for cancel
            if (!IsValidSpyroPath || IsSpyroOpen)
                return;

            // Iterate through the mods
            foreach (SpyroMod mod in mods)
            {
                // Check if the mod is enabled
                if (mod.enabled)
                {
                    // Check if vanilla
                    if (IsVanilla)
                    {
                        // Disable the mod
                        DisableMod(mod);

                        // Set to enabled and save
                        mod.enabled = true;
                        SaveToModsFolder(mod);
                    }
                    // Otherwise enable the mod
                    else
                    {
                        mod.enabled = false;
                        EnableMod(mod);
                    }
                }
            }
        }

        /// <summary>
        /// Enable the given mod.
        /// </summary>
        /// <param name="mod">Mod to enable.</param>
        private void EnableMod(SpyroMod mod)
        {
            // Check to cancel
            if (mod == null || mod.enabled || !IsValidSpyroPath || IsSpyroOpen)
                return;

            // Enable the mod
            mod.enabled = true;

            // Check if running mods
            if (!IsVanilla)
            {
                // Check if the file exists in the ~disabled folder
                if (FileExists(mod.PakFileName, disabledPakModsPath))
                {
                    // Move to the ~mods folder
                    File.Move(disabledPakModsPath + mod.PakFileName, paksModPath + mod.PakFileName);
                }
                else
                {
                    // Output the .pak content to the ~mods folder
                    mod.ExportPak(paksModPath + mod.PakFileName);
                }
            }

            // Update the mod
            SaveToModsFolder(mod);
        }

        /// <summary>
        /// Disable the given mod.
        /// </summary>
        /// <param name="mod">Mod to disable.</param>
        private void DisableMod(SpyroMod mod)
        {
            // Check to cancel
            if (mod == null || !mod.enabled || !IsValidSpyroPath || IsSpyroOpen)
                return;

            // Disable the mod
            mod.enabled = false;

            // Check if in ~mods folder
            if (FileExists(mod.PakFileName, paksModPath))
            {
                // Move to ~disabled folder
                File.Move(paksModPath + mod.PakFileName, disabledPakModsPath + mod.PakFileName);
            }

            // Update the mod
            SaveToModsFolder(mod);
        }

        /// <summary>
        /// Edit the mod.
        /// </summary>
        /// <param name="mod">Mod to edit.</param>
        /// <param name="newName">New name.</param>
        /// <param name="newCreator">New creator.</param>
        /// <param name="newDescription">New description.</param>
        private void EditMod(SpyroMod mod, string newName, string newCreator, string newDescription, string thumbnailPath)
        {
            // Check to cancel
            if (mod == null || mod.locked || string.IsNullOrWhiteSpace(newName) || !IsValidSpyroPath)
                return;

            // Check if the mod is enabled and should be updated in the pak folder
            bool reactivate = mod.enabled;

            // Delete mod file from folder
            File.Delete(PathToModsFolder + "\\" + mod.fileName);

            // Remember the old pak name
            string oldPakName = mod.PakFileName;

            // Update the name
            mod.name = newName;

            // Update the pak name
            mod.pakName = newName;
            
            // Update the file name
            mod.fileName = newName + SpyroMod.fileExtension;

            // Update the creator
            mod.creator = newCreator;

            // Update the description
            mod.description = newDescription;

            // Update the thumbnail
            mod.SetThumbnail(thumbnailPath);

            // Rename file if pak name changed
            if (!oldPakName.Equals(mod.PakFileName))
            {
                string path = (mod.enabled ? paksModPath : disabledPakModsPath);

                // Check file exists
                if (File.Exists(path + oldPakName))
                    File.Move(path + oldPakName, path + mod.PakFileName);
            }

            // Validate file name
            ValidateFilename(mod, 1);

            // Save mod
            SaveToModsFolder(mod);
        }

        /// <summary>
        /// Remove a mod.
        /// </summary>
        /// <param name="mod">Mod to remove.</param>
        /// <param name="removeInstance">Whether to also remove the instance of the mod from the list.</param>
        private void RemoveMod(SpyroMod mod, bool removeInstance = true)
        {
            // Check to cancel
            if (mod == null || !IsValidSpyroPath || IsSpyroOpen)
                return;

            // Disable if enabled
            if (mod.enabled)
                DisableMod(mod);

            // Delete file from ~disabled
            File.Delete(disabledPakModsPath + mod.PakFileName);

            // Delete mod file from folder
            File.Delete(PathToModsFolder + "\\" + mod.fileName);

            // Remove the instance
            if (removeInstance)
            {
                // Get index of mod
                int index = mods.IndexOf(mod);

                // Decrease orders above
                for (int i = index + 1; i < mods.Count; ++i)
                    ChangeOrder(mods[i], mods[i].order - 1);

                // Remove from list
                mods.Remove(mod);

                // Re-calculate highest order
                highestOrder = 0;
                foreach (SpyroMod m in mods)
                    highestOrder = Math.Max(highestOrder, m.order);

                // Update button text and description
                UpdateListBindings();
                SelectedModChanged();
            }
        }
        
        /// <summary>
        /// Change the order of a mod.
        /// </summary>
        /// <param name="mod">Mod to change the order of.</param>
        /// <param name="order">New order.</param>
        private void ChangeOrder(SpyroMod mod, int order)
        {
            // Check to cancel
            if (mod == null || !IsValidSpyroPath)
                return;

            // Check if the mod is enabled and should be reenabled after
            bool reactivate = mod.enabled;

            // If enabled, disable
            if (reactivate)
                DisableMod(mod);

            // Change the order
            mod.order = order;

            // Enable if it was enabled before - and save the mod
            if (reactivate)
                EnableMod(mod);
            // Update the mod file
            else
                SaveToModsFolder(mod);
        }

        /// <summary>
        /// Change the order of the selected mod.
        /// </summary>
        /// <param name="direction">Up (-1) or down (1) the list.</param>
        private void MoveSelectedMod(int direction)
        {
            // Check to cancel
            if (SelectedMod == null || !IsValidSpyroPath || IsSpyroOpen)
                return;

            // Check that it is a valid move
            if ((direction == -1 && listMods.SelectedIndex > 0) ||
                (direction == 1 && listMods.SelectedIndex < mods.Count - 1))
            {
                // Change the order
                ChangeOrder(mods[listMods.SelectedIndex], listMods.SelectedIndex + direction);
                ChangeOrder(mods[listMods.SelectedIndex + direction], listMods.SelectedIndex);

                // Swap the values in the list
                Swap(mods, listMods.SelectedIndex, listMods.SelectedIndex + direction);

                // Move the selected index
                listMods.SelectedIndex += direction;
            }
        }

        /// <summary>
        /// Update the list box bindings.
        /// </summary>
        private void UpdateListBindings()
        {
            if (mods != null)
            {
                // Reset the list box
                mods.ResetBindings();
            }
        }
        
        /// <summary>
        /// Call when the selected mod changes.
        /// </summary>
        private void SelectedModChanged()
        {
            // Update mod description
            if (SelectedMod != null)
            {
                lblModOrigName.Text = "Name: " + SelectedMod.name;
                lblModCreator.Text = "Created by " + (string.IsNullOrWhiteSpace(SelectedMod.creator) ? "N/A" : SelectedMod.creator);
                txtModDescription.Text = (string.IsNullOrWhiteSpace(SelectedMod.description) ? "No description." : SelectedMod.description);
                lblModFileName.Text = "Filename: " + SelectedMod.fileName;
                picThumbnail.Image = SelectedMod.thumbnail != null ? SelectedMod.thumbnail : Properties.Resources.ReignitedTitle;

                // Display if the mod is locked (if in DEBUG build)
#if DEBUG
                txtModDescription.Text += NewLine + NewLine +
                    "Locked: " + SelectedMod.locked.ToString();
                txtModDescription.Text += NewLine +
                    "Pak Name: " + SelectedMod.PakFileName;
                txtModDescription.Text += NewLine +
                    "Highest Order: " + highestOrder;
#endif

                btnToggle.Text = SelectedMod.enabled ? "Disable" : "Enable";
                btnEditMod.Enabled = !SelectedMod.locked;
            }
            else
            {
                lblModOrigName.Text = "Name:";
                lblModCreator.Text = "Created by";
                txtModDescription.Text = "";
                lblModFileName.Text = "Filename:";
                picThumbnail.Image = Properties.Resources.SpyroStand;

                btnToggle.Text = "Enable";
                btnEditMod.Enabled = true;
            }
        }

        /// <summary>
        /// Changes the file name variable on mod so it doesn't clash with any others.
        /// </summary>
        /// <param name="mod">Mod to validate.</param>
        private void ValidateFilename(SpyroMod mod, int allowUpTo)
        {
            // Check if a mod with that name already exists
            if (DoesModWithFileNameExist(mod.name + SpyroMod.fileExtension, allowUpTo))
            {
                string modFileName = mod.name;
                int modNumb = 0;
                do
                {
                    modFileName = mod.name + "_" + (++modNumb).ToString();
                }
                while (DoesModWithFileNameExist(modFileName + SpyroMod.fileExtension, allowUpTo));

                mod.fileName = mod.name + "_" + modNumb.ToString() + SpyroMod.fileExtension;
            }
        }

        /// <summary>
        /// Check if a mod with a file name exists.
        /// </summary>
        /// <param name="fileName">File name to check for.</param>
        /// <returns>True if a mod exists with that file name.</returns>
        private bool DoesModWithFileNameExist(string fileName, int allow = 0)
        {
            foreach (SpyroMod mod in mods)
                if (mod.fileName.Equals(fileName) && allow-- <= 0)
                    return true;
            return false;
        }

        /// <summary>
        /// Find the path to the save games.
        /// </summary>
        /// <returns></returns>
        private string FindSaveFilePath()
        {
            // Check to cancel
            if (!IsValidSpyroPath)
                return "";

            // Save file path
            string saveFilePath = "";

            // Get to user data folder
            DirectoryInfo info = new DirectoryInfo(PathToSpyroGame);
            string userDataPath = info.Parent.Parent.Parent.FullName + "\\userdata\\";

            // Get steam users in folder
            string[] steamUsers = Directory.GetDirectories(userDataPath);

            // Find spyro in steam users
            foreach (string user in steamUsers)
            {
                if (Directory.Exists(user + "\\996580"))
                    saveFilePath = user + "\\996580\\remote\\Falcon\\Saved\\SaveGames\\";
            }

            // Return save file path
            return saveFilePath;
        }

        /// <summary>
        /// Swap two elements in a list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Reference to the list.</param>
        /// <param name="indexA">Index A.</param>
        /// <param name="indexB">Index B.</param>
        private void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }

        /// <summary>
        /// Check a mod exists.
        /// </summary>
        /// <param name="pakName"></param>
        /// <param name="outMod"></param>
        /// <returns></returns>
        private bool ModExists(string pakName, out SpyroMod outMod)
        {
            foreach (SpyroMod mod in mods)
            {
                if (mod.PakFileName.Equals(pakName))
                {
                    outMod = mod;
                    return true;
                }
            }
            outMod = null;
            return false;
        }

        /// <summary>
        /// Check if a file exists in a folder.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="directory"></param>
        /// <returns></returns>
        private bool FileExists(string fileName, string directory)
        {
            string[] files = Directory.GetFiles(directory);

            foreach (string fName in files)
            {
                FileInfo fileInfo = new FileInfo(fName);

                if (fileInfo.Name.Equals(fileName))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Check if a process is open.
        /// </summary>
        /// <param name="name">Name of the process.</param>
        /// <returns>True if the process is open.</returns>
        private static bool IsProcessOpen(string name)
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.ToLower() == name.ToLower())
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Called when the "Choose Spyro.exe" button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSpyroPath_Click(object sender, EventArgs e)
        {
            // Cancel if spyro is open
            if (IsSpyroOpen)
                return;

            // Create an open file dialog
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                CheckPathExists = true,
                InitialDirectory = (IsValidSpyroPath ? PathToSpyroGame : ""),
                Multiselect = false,
                Title = "Choose Spyro.exe in your Steam folder",
                Filter = "Spyro Executable (*Spyro.exe)|*Spyro.exe"
            };

            // Check that the dialog finished successfully
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Select the path
                SelectSpyroPath(openFileDialog.FileName);
            }
        }

        /// <summary>
        /// Called when the "Launch Spyro" button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLaunchSpyro_Click(object sender, EventArgs e)
        {
            // Check that spyro isn't already open and there's a valid path to launch the exe
            if (!IsSpyroOpen && IsValidSpyroPath)
            {
                // Check if the console injector should be used
                if (checkConsoleInjector.Checked)
                {
                    // Check if the injector path isn't valid
                    if (!IsValidInjectorPath)
                    {
                        // Create injector form
                        InjectorForm injectorForm = new InjectorForm("");

                        // Check the form finished OK
                        if (injectorForm.ShowDialog() == DialogResult.OK)
                        {
                            // Update the data file
                            data.injectorPath = injectorForm.InjectorPath;
                            SaveToDataFile(data);
                        }
                        // Otherwise cancel
                        else
                            return;
                    }

                    // Start the injector timer
                    injectorTimer.Stop();
                    injectorTimer.Start();
                }

                // Check if should skip intro cutscenes
                if (data.skipIntro)
                {
                    // Check the cutscene timer isn't already enabled
                    if (!cutsceneTimer.Enabled)
                    {
                        // Disable the cutscenes
                        string[] files = Directory.GetFiles(moviePath);

                        // Iterate through the files
                        foreach (string file in files)
                        {
                            // Get file info
                            FileInfo fileInfo = new FileInfo(file);

                            // Check if is a bumper movie file
                            if (fileInfo.Name.ToLower().StartsWith("bumper") && fileInfo.Extension.ToLower() == ".mp4")
                            {
                                // Get the new name (remove the underscore)
                                string newFileName = "_" + fileInfo.Name;

                                // Rename the file
                                File.Move(fileInfo.FullName, moviePath + newFileName);
                            }
                        }
                    }

                    // Start the cutscene timer to revert the changes
                    cutsceneTimer.Stop();
                    cutsceneTimer.Start();
                }

                // Check that save file is valid
                if (!string.IsNullOrWhiteSpace(saveFilePath))
                {
                    // If backup save
                    if (DoBackupSave)
                    {
                        // Get files in save folder
                        string[] fileNames = Directory.GetFiles(saveFilePath);

                        // Iterate through
                        foreach (string fileName in fileNames)
                        {
                            // Check for the save file
                            if (fileName.EndsWith("FalconSave.106.sav"))
                            {
                                // Load content
                                byte[] saveContent = File.ReadAllBytes(fileName);

                                // Save to backup
                                File.WriteAllBytes(PathToSaveBackups + DateTime.Now.ToString("yyyyMMddTHHmmss") + "-FalconSave.106.sav.backup", saveContent);
                            }
                        }
                    }

                    // Check for old saves
                    string[] backupFiles = Directory.GetFiles(PathToSaveBackups);

                    // Iterate over the files
                    foreach (string backupFileName in backupFiles)
                    {
                        // Get fileinfo
                        FileInfo fileInfo = new FileInfo(backupFileName);
                        
                        // Check if the file is 30 days old
                        if ((DateTime.Now - fileInfo.CreationTime).TotalDays > 5)
                        {
                            // Delete the backup
                            File.Delete(backupFileName);
                        }
                    }
                }

                // Start the process
                Process.Start(spyroPath);

                // Minimise the form
                WindowState = FormWindowState.Minimized;
            }
        }

        /// <summary>
        /// Called when the "Add Mod(s)" button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddMod_Click(object sender, EventArgs e)
        {
            // Check that a spyro path is loaded and spyro isn't open
            if (!IsValidSpyroPath || IsSpyroOpen)
                return;

            // Create an open file dialog
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = true,
                Title = "Select Pak or Spyro Mod Files",
                Filter = "Mod files (*.pak, *.srtmod)|*.pak;*.srtmod"
            };

            // Check that the dialog finished successfully
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Iterate through selected files
                foreach (string path in openFileDialog.FileNames)
                {
                    // Add each as a mod
                    AddNewMod(path, path.ToLower().EndsWith(".pak"));
                }
            }
        }

        /// <summary>
        /// Called when the "Enable/Disable" button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToggle_Click(object sender, EventArgs e)
        {
            // Check that a mod is selected
            if (SelectedMod != null)
            {
                // If the mod is enabled, disable it
                if (SelectedMod.enabled)
                    DisableMod(SelectedMod);
                // Otherwise enable it
                else
                    EnableMod(SelectedMod);

                // Update button text and list box bindings
                SelectedModChanged();
                UpdateListBindings();
            }
        }

        /// <summary>
        /// Called when the "Move Up" button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            // Move the mod up the list
            MoveSelectedMod(-1);
        }

        /// <summary>
        /// Called when the "Move Down" button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            // Move the mod down the list
            MoveSelectedMod(1);
        }

        /// <summary>
        /// Called when the "Deactivate All" button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeactivateAll_Click(object sender, EventArgs e)
        {
            // Disable each mod
            foreach (SpyroMod mod in mods)
                DisableMod(mod);

            // Update list bindings
            UpdateListBindings();
            // Mod changed
            SelectedModChanged();
        }
        
        /// <summary>
        /// Called when the "Remove Mod" button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveMod_Click(object sender, EventArgs e)
        {
            // Check that a mod is selected
            if (SelectedMod != null)
            {
                // Remove the selected mod
                RemoveMod(SelectedMod);
            }
        }

        /// <summary>
        /// Called when the "Rename" button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditMod_Click(object sender, EventArgs e)
        {
            // Check that a valid spyro path is loaded and a mod is selected
            if (IsValidSpyroPath && !IsSpyroOpen && SelectedMod != null)
            {
                // Create a mod form
                ModForm modForm = new ModForm(null, SelectedMod);

                // Check if the form finished OK
                if (modForm.ShowDialog() == DialogResult.OK)
                {
                    // Edit the mod
                    EditMod(SelectedMod, modForm.ModName, modForm.ModCreator, modForm.ModDescription, modForm.ThumbnailPath);

                    // Update list box and UI
                    UpdateListBindings();
                    SelectedModChanged();
                }
            }
        }

        /// <summary>
        /// Called when the selected item in the list box is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listMods_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update UI
            SelectedModChanged();
        }

        /// <summary>
        /// Called when something is dragged over the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            // Get the file paths dropped
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            // Check if should continue
            if (files.Length == 0 || !IsValidSpyroPath || IsSpyroOpen)
                return;

            // Get the file path
            string filePath = files.First();

            // Check that the file exists and is a valid file type
            if (File.Exists(filePath) && (filePath.ToLower().EndsWith(".pak") || filePath.ToLower().EndsWith(SpyroMod.fileExtension)))
            {
                // Add as a new mod
                AddNewMod(filePath, filePath.ToLower().EndsWith(".pak"));

                // Delete the original file if it is a mod file
                if (filePath.ToLower().EndsWith(SpyroMod.fileExtension))
                    File.Delete(filePath);
            }
        }
        
        /// <summary>
        /// Called when something is dragged onto the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            // Allow the object if it is a file
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Move;
            // Otherwise don't allow it
            else
                e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// Called when the "With No Mods" checkbox is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkVanilla_CheckedChanged(object sender, EventArgs e)
        {
            // Check if can set
            if (IsValidSpyroPath && !IsSpyroOpen)
            {
                // Set vanilla based on the check box value
                SetVanilla(checkVanilla.Checked);
            }
        }

        /// <summary>
        /// Called when the "Use Console Injector" checkbox is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkConsoleInjector_CheckedChanged(object sender, EventArgs e)
        {
            // Save to file
            data.useInjector = checkConsoleInjector.Checked;
            SaveToDataFile(data);
        }

        /// <summary>
        /// Called when the "Skip Intro Cutscenes" checkbox is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkSkipIntro_CheckedChanged(object sender, EventArgs e)
        {
            // Save to file
            data.skipIntro = checkSkipIntro.Checked;
            SaveToDataFile(data);
        }

        private void checkBackupSave_CheckedChanged(object sender, EventArgs e)
        {
            // Save to file
            data.saveBackup = checkBackupSave.Checked;
            SaveToDataFile(data);
        }
    }
}
