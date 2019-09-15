using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

// File: InjectorForm.cs
// Created by: MRG-bit
// Last edited: 15/09/2019

namespace SpyroModManager
{
    /// <summary>
    /// Injector form for setting up and connecting the Console Injector.
    /// </summary>
    public partial class InjectorForm : Form
    {
        // Path to the injector executable
        public string InjectorPath { get; private set; } = "";

        /// <summary>
        /// Constructor.
        /// </summary>
        public InjectorForm(string oldPath)
        {
            InitializeComponent();

            // Change the title text
            Text = "Setup Console Injector";

            // Disable maximise button
            MaximizeBox = false;

            // Disable resizing
            FormBorderStyle = FormBorderStyle.FixedDialog;

            // Default values
            SelectInjectorPath(oldPath);
        }

        /// <summary>
        /// Try to select the injector path.
        /// </summary>
        /// <param name="injectorPath">Path to injector executable.</param>
        private void SelectInjectorPath(string injectorPath)
        {
            // Check path is valid and exists
            if (!string.IsNullOrWhiteSpace(injectorPath) && File.Exists(injectorPath) && injectorPath.ToLower().EndsWith(".exe"))
            {
                // Update injector path
                InjectorPath = injectorPath;

                // Update label
                lblPathSelected.Text = "Inject path selected: " + InjectorPath;
                lblPathSelected.ForeColor = Color.Green;

                // Enable the continue button
                btnContinue.Enabled = true;
            }
            else
            {
                // Update label
                lblPathSelected.Text = "Injector path not selected";
                lblPathSelected.ForeColor = Color.Red;

                // Disable the continue button
                btnContinue.Enabled = false;
            }
        }

        /// <summary>
        /// Called when the "Download" button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownload_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://drive.google.com/file/d/1Z6SY-c7wbEPN9FsM-kZHiqtYbAsA6F2g/view");
        }

        /// <summary>
        /// Called when the "Select" button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            // Create an open file dialog
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false,
                Title = "Choose Console Injector Executable",
                Filter = "Executable files (*.exe)|*.exe"
            };

            // Check that the dialog finished successfully
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Try to select the path
                SelectInjectorPath(openFileDialog.FileName);
            }
        }

        /// <summary>
        /// Called when the "Cancel" button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close form
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Called when the "Continue?" button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnContinue_Click(object sender, EventArgs e)
        {
            // Close form
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
