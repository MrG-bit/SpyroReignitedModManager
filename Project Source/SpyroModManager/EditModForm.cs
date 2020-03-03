///     Spyro Reignited Mod Manager
///     File: EditModForm.cs
///     Last updated: 2020/02/28
///     Created by: MR.G-bit

using System;
using System.Drawing;
using System.Windows.Forms;

namespace SpyroModManager
{
    public partial class EditModForm : Form
    {
        public string ModName { get; private set; }
        public string ModAuthor { get; private set; }
        public string ModDescription { get; private set; }
        public Bitmap ModImage { get; private set; }
        private bool m_choseImage = false;

        public EditModForm(Mod mod, string pakFileName, string defaultName = "")
        {
            InitializeComponent();

            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            DarkTheme.ToggleDarkTheme(this, DarkTheme.IsDarkTheme);

            lbl_PakName.Text = "Pak name: " + pakFileName;
            if (!string.IsNullOrWhiteSpace(mod.Name)) txt_modName.Text = mod.Name;
            else if (!string.IsNullOrWhiteSpace(defaultName)) txt_modName.Text = defaultName;
            if (!string.IsNullOrWhiteSpace(mod.Author)) txt_modAuthor.Text = mod.Author;
            if (!string.IsNullOrWhiteSpace(mod.Description)) txt_modDescription.Text = mod.Description;
            if (mod.Image != null) pic_modImage.Image = mod.Image;
            else pic_modImage.Image = Properties.Resources.image_spyroVersion_boxart;
        }
        
        // Cancel adding the mod
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // Confirm the details
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_modName.Text))
            {
                MessageBox.Show("You must at least enter a name for the mod.", "Hold up!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ModName = txt_modName.Text;
            ModAuthor = txt_modAuthor.Text;
            ModDescription = txt_modDescription.Text;
            if (m_choseImage)
                ModImage = new Bitmap(pic_modImage.Image);

            DialogResult = DialogResult.OK;
            Close();
        }

        // Choose an image
        private void btn_chooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Choose an image for the mod",
                Filter = "Image Files (*.png; *.jpg; *.jpeg; *.gif; *.bmp)|*.png; *.jpg; *.jpeg; *.gif; *.bmp",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pic_modImage.Image = new Bitmap(openFileDialog.FileName);
                m_choseImage = true;
            }
        }
    }
}
