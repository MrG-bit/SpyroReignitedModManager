namespace SpyroModManager
{
    partial class EditModForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.group_modDetails = new System.Windows.Forms.GroupBox();
            this.pic_modImage = new System.Windows.Forms.PictureBox();
            this.btn_chooseImage = new System.Windows.Forms.Button();
            this.lbl_PakName = new System.Windows.Forms.Label();
            this.txt_modDescription = new System.Windows.Forms.TextBox();
            this.txt_modAuthor = new System.Windows.Forms.TextBox();
            this.txt_modName = new System.Windows.Forms.TextBox();
            this.lbl_modDescription = new System.Windows.Forms.Label();
            this.lbl_modAuthor = new System.Windows.Forms.Label();
            this.lbl_modName = new System.Windows.Forms.Label();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.group_modDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_modImage)).BeginInit();
            this.SuspendLayout();
            // 
            // group_modDetails
            // 
            this.group_modDetails.Controls.Add(this.pic_modImage);
            this.group_modDetails.Controls.Add(this.btn_chooseImage);
            this.group_modDetails.Controls.Add(this.lbl_PakName);
            this.group_modDetails.Controls.Add(this.txt_modDescription);
            this.group_modDetails.Controls.Add(this.txt_modAuthor);
            this.group_modDetails.Controls.Add(this.txt_modName);
            this.group_modDetails.Controls.Add(this.lbl_modDescription);
            this.group_modDetails.Controls.Add(this.lbl_modAuthor);
            this.group_modDetails.Controls.Add(this.lbl_modName);
            this.group_modDetails.Location = new System.Drawing.Point(12, 12);
            this.group_modDetails.Name = "group_modDetails";
            this.group_modDetails.Size = new System.Drawing.Size(520, 246);
            this.group_modDetails.TabIndex = 0;
            this.group_modDetails.TabStop = false;
            this.group_modDetails.Text = "Mod Details";
            // 
            // pic_modImage
            // 
            this.pic_modImage.InitialImage = global::SpyroModManager.Properties.Resources.image_spyroVersion_boxart;
            this.pic_modImage.Location = new System.Drawing.Point(315, 19);
            this.pic_modImage.Name = "pic_modImage";
            this.pic_modImage.Size = new System.Drawing.Size(190, 190);
            this.pic_modImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_modImage.TabIndex = 8;
            this.pic_modImage.TabStop = false;
            // 
            // btn_chooseImage
            // 
            this.btn_chooseImage.Location = new System.Drawing.Point(315, 215);
            this.btn_chooseImage.Name = "btn_chooseImage";
            this.btn_chooseImage.Size = new System.Drawing.Size(190, 23);
            this.btn_chooseImage.TabIndex = 7;
            this.btn_chooseImage.Text = "Choose Image";
            this.btn_chooseImage.UseVisualStyleBackColor = true;
            this.btn_chooseImage.Click += new System.EventHandler(this.btn_chooseImage_Click);
            // 
            // lbl_PakName
            // 
            this.lbl_PakName.AutoSize = true;
            this.lbl_PakName.Location = new System.Drawing.Point(6, 220);
            this.lbl_PakName.Name = "lbl_PakName";
            this.lbl_PakName.Size = new System.Drawing.Size(58, 13);
            this.lbl_PakName.TabIndex = 6;
            this.lbl_PakName.Text = "Pak name:";
            // 
            // txt_modDescription
            // 
            this.txt_modDescription.Location = new System.Drawing.Point(9, 106);
            this.txt_modDescription.Multiline = true;
            this.txt_modDescription.Name = "txt_modDescription";
            this.txt_modDescription.Size = new System.Drawing.Size(292, 103);
            this.txt_modDescription.TabIndex = 5;
            // 
            // txt_modAuthor
            // 
            this.txt_modAuthor.Location = new System.Drawing.Point(87, 56);
            this.txt_modAuthor.Name = "txt_modAuthor";
            this.txt_modAuthor.Size = new System.Drawing.Size(214, 20);
            this.txt_modAuthor.TabIndex = 4;
            // 
            // txt_modName
            // 
            this.txt_modName.Location = new System.Drawing.Point(87, 20);
            this.txt_modName.Name = "txt_modName";
            this.txt_modName.Size = new System.Drawing.Size(214, 20);
            this.txt_modName.TabIndex = 3;
            // 
            // lbl_modDescription
            // 
            this.lbl_modDescription.AutoSize = true;
            this.lbl_modDescription.Location = new System.Drawing.Point(6, 90);
            this.lbl_modDescription.Name = "lbl_modDescription";
            this.lbl_modDescription.Size = new System.Drawing.Size(60, 13);
            this.lbl_modDescription.TabIndex = 2;
            this.lbl_modDescription.Text = "Description";
            // 
            // lbl_modAuthor
            // 
            this.lbl_modAuthor.AutoSize = true;
            this.lbl_modAuthor.Location = new System.Drawing.Point(6, 59);
            this.lbl_modAuthor.Name = "lbl_modAuthor";
            this.lbl_modAuthor.Size = new System.Drawing.Size(41, 13);
            this.lbl_modAuthor.TabIndex = 1;
            this.lbl_modAuthor.Text = "Author:";
            // 
            // lbl_modName
            // 
            this.lbl_modName.AutoSize = true;
            this.lbl_modName.Location = new System.Drawing.Point(6, 23);
            this.lbl_modName.Name = "lbl_modName";
            this.lbl_modName.Size = new System.Drawing.Size(38, 13);
            this.lbl_modName.TabIndex = 0;
            this.lbl_modName.Text = "Name:";
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Location = new System.Drawing.Point(340, 275);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(93, 23);
            this.btn_Confirm.TabIndex = 1;
            this.btn_Confirm.Text = "Confirm";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(439, 275);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // EditModForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 307);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btn_Confirm);
            this.Controls.Add(this.group_modDetails);
            this.Name = "EditModForm";
            this.ShowIcon = false;
            this.Text = "Mod Editor";
            this.group_modDetails.ResumeLayout(false);
            this.group_modDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_modImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox group_modDetails;
        private System.Windows.Forms.TextBox txt_modDescription;
        private System.Windows.Forms.TextBox txt_modAuthor;
        private System.Windows.Forms.TextBox txt_modName;
        private System.Windows.Forms.Label lbl_modDescription;
        private System.Windows.Forms.Label lbl_modAuthor;
        private System.Windows.Forms.Label lbl_modName;
        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbl_PakName;
        private System.Windows.Forms.PictureBox pic_modImage;
        private System.Windows.Forms.Button btn_chooseImage;
    }
}