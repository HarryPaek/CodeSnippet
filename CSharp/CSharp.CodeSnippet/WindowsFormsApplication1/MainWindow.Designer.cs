namespace WindowsFormsApplication
{
    partial class MainWindow
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
            this.btnAutoCloseMessageBox = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAutoCloseMessageBox
            // 
            this.btnAutoCloseMessageBox.Location = new System.Drawing.Point(12, 12);
            this.btnAutoCloseMessageBox.Name = "btnAutoCloseMessageBox";
            this.btnAutoCloseMessageBox.Size = new System.Drawing.Size(200, 30);
            this.btnAutoCloseMessageBox.TabIndex = 0;
            this.btnAutoCloseMessageBox.Text = "MessageBox Auto Closing";
            this.btnAutoCloseMessageBox.UseVisualStyleBackColor = true;
            this.btnAutoCloseMessageBox.Click += new System.EventHandler(this.btnAutoCloseMessageBox_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.btnAutoCloseMessageBox);
            this.Name = "MainWindow";
            this.Text = "Main Window";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAutoCloseMessageBox;
    }
}

