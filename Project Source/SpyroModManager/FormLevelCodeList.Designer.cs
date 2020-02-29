namespace SpyroModManager
{
    partial class FormLevelCodeList
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
            this.list_levelNames = new System.Windows.Forms.ListView();
            this.Version = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LevelName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.InternalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // list_levelNames
            // 
            this.list_levelNames.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Version,
            this.LevelName,
            this.InternalName});
            this.list_levelNames.FullRowSelect = true;
            this.list_levelNames.GridLines = true;
            this.list_levelNames.HideSelection = false;
            this.list_levelNames.Location = new System.Drawing.Point(12, 12);
            this.list_levelNames.MultiSelect = false;
            this.list_levelNames.Name = "list_levelNames";
            this.list_levelNames.Size = new System.Drawing.Size(446, 617);
            this.list_levelNames.TabIndex = 0;
            this.list_levelNames.UseCompatibleStateImageBehavior = false;
            this.list_levelNames.View = System.Windows.Forms.View.Details;
            // 
            // Version
            // 
            this.Version.Text = "Version";
            this.Version.Width = 75;
            // 
            // LevelName
            // 
            this.LevelName.Text = "Level Name";
            this.LevelName.Width = 175;
            // 
            // InternalName
            // 
            this.InternalName.Text = "Internal Name";
            this.InternalName.Width = 175;
            // 
            // FormLevelCodeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 641);
            this.Controls.Add(this.list_levelNames);
            this.Name = "FormLevelCodeList";
            this.Text = "Internal Level Name List";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView list_levelNames;
        private System.Windows.Forms.ColumnHeader Version;
        private System.Windows.Forms.ColumnHeader LevelName;
        private System.Windows.Forms.ColumnHeader InternalName;
    }
}