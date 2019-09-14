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
        private Version version = new Version(1, 2, 1);

        private string spyroPath = "";      // File path to Spyro.exe (in Steam folders)
        private string pakPath = "";        // Path to the pak folder (in Steam folders)
        private ModManagerData data;        // Reference to the mod manager data

        // List of mods loaded into the manager
        private BindingList<SpyroMod> mods = new BindingList<SpyroMod>();

        public static bool IsSpyroOpen { get { return IsProcessOpen("Spyro"); } }
        private bool IsValidSpyroPath { get { return spyroPath != "" && spyroPath.ToLower().EndsWith("spyro.exe"); } }
        private bool ModFolderExists { get { return Directory.Exists(PathToModsFolder); } }
        private bool DataFileExists { get { return File.Exists(PathToDataFile); } }
        private string PathToModsFolder { get { return Application.StartupPath + "\\Spyro Reignited Mods"; } }
        private string PathToDataFile { get { return Application.StartupPath + "\\Data.dat"; } }
        private string PathToSpyroGame { get { return IsValidSpyroPath ? spyroPath.Remove(spyroPath.Length - 9, 9) : ""; } }
        private string NewLine { get { return Environment.NewLine; } }
        private SpyroMod SelectedMod { get { if (listMods.SelectedIndex >= 0 && listMods.SelectedIndex < mods.Count) return mods[listMods.SelectedIndex]; else return null; } }

        /// <summary>
        /// Constructor.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // Set form title
            Text = "Spyro Reignited Mod Manager";

            // Disable maximise button
            MaximizeBox = false;

            // Disable form resizing
            FormBorderStyle = FormBorderStyle.FixedDialog;

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

                // Determine the pak path
                pakPath = PathToSpyroGame + "Falcon\\Content\\Paks\\";

                // Update the pak path label
                lblPakPath.Text = "Pak folder: " + pakPath;

                // Update the path loaded label
                lblPathLoaded.Text = "Path loaded";
                lblPathLoaded.ForeColor = Color.Green;

                // Update data file
                data.spyroPath = this.spyroPath;
                SaveToDataFile(data);
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
            mod.order = mods.Count;

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

            // Determine the path to output the .pak file
            string path = pakPath + "pakchunk" + (3 + mod.order) + "-" + mod.name + ".pak";

            // Output the .pak content to the path
            mod.ExportPak(path);

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

            // Determine the path to remove the .pak file
            string path = pakPath + "pakchunk" + (3 + mod.order) + "-" + mod.name + ".pak";

            // Delete the file if it exists
            if (File.Exists(path))
                File.Delete(path);

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

            // Disable the mod if it is activated
            if (reactivate)
                DisableMod(mod);

            // Remove the mod file, but not the instance
            RemoveMod(mod, false);

            // Update the name
            mod.name = newName;
            
            // Update the file name
            mod.fileName = newName + SpyroMod.fileExtension;

            // Update the creator
            mod.creator = newCreator;

            // Update the description
            mod.description = newDescription;

            // Update the thumbnail
            mod.SetThumbnail(thumbnailPath);

            // Validate file name
            ValidateFilename(mod, 1);

            // Enable the mod if it was activated before (and save to file)
            if (reactivate)
                EnableMod(mod);
            // Save the mod to file
            else
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

            // Delete file
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

                // Update button text
                UpdateListBindings();
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
                picThumbnail.Image = Properties.Resources.ReignitedTitle;

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
                Filter = "Executable files (*.exe)|*.exe"
            };

            // Check that the dialog finished successfully
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Select the path
                SelectSpyroPath(openFileDialog.FileName);
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
    }
}
