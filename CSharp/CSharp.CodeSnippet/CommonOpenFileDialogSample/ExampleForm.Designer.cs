namespace CommonOpenFileDialogSample
{
    partial class ExampleForm
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
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelectFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectFolder.Location = new System.Drawing.Point(0, 0);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(284, 261);
            this.btnSelectFolder.TabIndex = 0;
            this.btnSelectFolder.Text = "Select Folder";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // ExampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnSelectFolder);
            this.Name = "ExampleForm";
            this.Text = "::: Select Folder";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSelectFolder;
    }
}

