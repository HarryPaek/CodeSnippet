namespace SaveFileDialogSample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExampleForm));
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveImage.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveImage.Image")));
            this.btnSaveImage.Location = new System.Drawing.Point(0, 0);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(304, 292);
            this.btnSaveImage.TabIndex = 0;
            this.btnSaveImage.Text = "Save Image";
            this.btnSaveImage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // ExampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 292);
            this.Controls.Add(this.btnSaveImage);
            this.Name = "ExampleForm";
            this.Text = "::: SaveFileDialog Example";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveImage;
    }
}

