namespace ShowModalWithInterface
{
    partial class MainForm
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
            this.btnShowModal = new System.Windows.Forms.Button();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnShowModal
            // 
            this.btnShowModal.Location = new System.Drawing.Point(77, 184);
            this.btnShowModal.Name = "btnShowModal";
            this.btnShowModal.Size = new System.Drawing.Size(132, 43);
            this.btnShowModal.TabIndex = 0;
            this.btnShowModal.Text = "Show Modal";
            this.btnShowModal.UseVisualStyleBackColor = true;
            this.btnShowModal.Click += new System.EventHandler(this.btnShowModal_Click);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(77, 50);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(155, 21);
            this.txtKey.TabIndex = 1;
            this.txtKey.Text = "Key Text";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(77, 109);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(155, 21);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.Text = "Description Text";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.btnShowModal);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowModal;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtDescription;
    }
}

