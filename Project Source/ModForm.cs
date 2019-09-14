using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

// File: ModForm.cs
// Created by: MRG-bit
// Last edited: 15/09/2019

namespace SpyroModManager
{
    /// <summary>
    /// Mod form for adding/editing a mod.
    /// </summary>
    public partial class ModForm : Form
    {
        public string ModName { get; private set; }             // Name of the mod
        public string ModCreator { get; private set; }          // Creator of the mod
        public string ModDescription { get; private set; }      // Description of the mod
        public bool DeletePakFile { get; private set; }         // Delete the imported .pak file
        public string ThumbnailPath { get; private set; }       // Path of the thumbnail selected

        private readonly string pakPath;        // Path to the .pak file being imported (NULL if editing a mod)
        private readonly SpyroMod editMod;      // Reference to the spyro mod being edited (NULL if creating a new mod)

        // Check if the name field is valid
        private bool IsNameValid
        {
            get
            {
                return !string.IsNullOrWhiteSpace(ModName);
            }
        }

        // Check if all the fields (name, creator, description) are valid
        private bool IsAllValid
        {
            get
            {
                return !string.IsNullOrWhiteSpace(ModName) &&
                    !string.IsNullOrWhiteSpace(ModCreator) &&
                    !string.IsNullOrWhiteSpace(ModDescription);
            }
        }

        // Are we adding a new mod
        private bool IsAddingNewMod { get { return editMod == null; } }

        /// <summary>
        /// Constructor.
        /// </summary>
        public ModForm(string pakPath = null, SpyroMod editMod = null)
        {
            InitializeComponent();

            // Change the title text
            Text = "Edit Mod";

            // Disable maximise button
            MaximizeBox = false;

            // Give control to the text box
            ActiveControl = txtModName;

            // Disable resizing
            FormBorderStyle = FormBorderStyle.FixedDialog;

            // Set the path of the .pak file being loaded in
            this.pakPath = pakPath;

            // Set the edit mod
            this.editMod = editMod;
            
            // Check that the pak name isn't null (adding a new mod)
            if (this.pakPath != null)
            {
                // Set the text to show the name of the pak being imported in
                lblTop.Text = "Adding mod from .pak file: " + pakPath.Split('\\').Last();
            }
            // Otherwise we are editing an existing mod
            else
            {
                // Disable the group box with information about deleting the old .pak file
                groupDeletePak.Enabled = false;
            }

            // Check that the original mod isn't null
            if (editMod != null)
            {
                // Set default values
                txtModName.Text = editMod.name;
                txtModCreator.Text = editMod.creator;
                txtModDescription.Text = editMod.description;

                // Set default thumbnail if there is one
                if (editMod.thumbnail != null)
                {
                    picThumbnail.Image = editMod.thumbnail;
                }
            }
        }
        
        /// <summary>
        /// Load the fields into variables.
        /// </summary>
        private void LoadFields()
        {
            ModName = string.IsNullOrWhiteSpace(txtModName.Text) ? "" : txtModName.Text;
            ModCreator = string.IsNullOrWhiteSpace(txtModCreator.Text) ? "" : txtModCreator.Text;
            ModDescription = string.IsNullOrWhiteSpace(txtModDescription.Text) ? "" : txtModDescription.Text;
            DeletePakFile = checkBoxDeletePakFile.Checked;
        }

        /// <summary>
        /// Called when the "Confirm" button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Load the fields
            LoadFields();

            // Check if spyro process is running
            if (MainForm.IsSpyroOpen)
            {
                // Close the form
                DialogResult = DialogResult.Cancel;
                Close();
            }
            // Otherwise, check that the name field is valid
            else if (IsNameValid)
            {
                // Close the form
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        /// Called when the "Cancel" button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close the form
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Called when the "Create Shareable Copy" button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShareableCopy_Click(object sender, EventArgs e)
        {
            // Load the fields
            LoadFields();

            // Check that the fields are valid and spyro process isn't running
            if (IsAllValid && !MainForm.IsSpyroOpen)
            {
                // Create a copy
                SpyroMod shareableMod;

                // Check if we're adding a new mod
                if (IsAddingNewMod)
                {
                    shareableMod = new SpyroMod(ModName + SpyroMod.fileExtension, false, ModName, ModCreator, ModDescription);
                    shareableMod.ImportPak(pakPath);
                }
                // Otherwise we are editing a mod
                else
                {
                    // Create a copy of the mod
                    shareableMod = new SpyroMod(editMod)
                    {
                        name = ModName,
                        creator = ModCreator,
                        description = ModDescription
                    };
                }

                // Lock the mod
                shareableMod.locked = true;

                // Add the thumbnail if one is selected
                if (!string.IsNullOrWhiteSpace(ThumbnailPath) && File.Exists(ThumbnailPath))
                    shareableMod.SetThumbnail(ThumbnailPath);

                // Disable the shareable version of the mod
                shareableMod.enabled = false;

                // Create a save file dialog
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    CheckPathExists = true,
                    Title = "Save a Shareable Mod",
                    Filter = "Spyro Reignited Mod|*.srtmod"
                };

                // Check dialog is OK
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Check path is valid
                    if (saveFileDialog.FileName != "")
                    {
                        // Save to file
                        shareableMod.SaveToFile(saveFileDialog.FileName);
                    }
                }
            }
        }

        /// <summary>
        /// Called when the "Choose Thumbnail" button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChooseThumbnail_Click(object sender, EventArgs e)
        {
            // Create an open file dialog
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Choose an Image File",
                Multiselect = false,
                InitialDirectory = "C:\\Pictures",
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif)|*.jpg;*.jpeg;*.png;*.gif"
            };

            // Check the dialog closed OK
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Update the picture box
                picThumbnail.Image = new Bitmap(openFileDialog.FileName);

                // Set the field
                ThumbnailPath = openFileDialog.FileName;
            }
        }
    }
}
