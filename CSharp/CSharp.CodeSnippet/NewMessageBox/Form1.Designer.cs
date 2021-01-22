namespace NewMessageBox
{
    partial class Form1
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
            this.btnYesNoCancel = new System.Windows.Forms.Button();
            this.btnAbortRetryIgnore = new System.Windows.Forms.Button();
            this.btnOkCancel = new System.Windows.Forms.Button();
            this.btnYestNo = new System.Windows.Forms.Button();
            this.btnInfoBoxYesNoCancel = new System.Windows.Forms.Button();
            this.btnInfoBoxOkCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnYesNoCancel
            // 
            this.btnYesNoCancel.Location = new System.Drawing.Point(42, 39);
            this.btnYesNoCancel.Name = "btnYesNoCancel";
            this.btnYesNoCancel.Size = new System.Drawing.Size(153, 23);
            this.btnYesNoCancel.TabIndex = 0;
            this.btnYesNoCancel.Text = "Yes, No, Cancel";
            this.btnYesNoCancel.UseVisualStyleBackColor = true;
            this.btnYesNoCancel.Click += new System.EventHandler(this.btnYesNoCancel_Click);
            // 
            // btnAbortRetryIgnore
            // 
            this.btnAbortRetryIgnore.Location = new System.Drawing.Point(42, 90);
            this.btnAbortRetryIgnore.Name = "btnAbortRetryIgnore";
            this.btnAbortRetryIgnore.Size = new System.Drawing.Size(153, 23);
            this.btnAbortRetryIgnore.TabIndex = 1;
            this.btnAbortRetryIgnore.Text = "Abort, Retry, Ignore";
            this.btnAbortRetryIgnore.UseVisualStyleBackColor = true;
            this.btnAbortRetryIgnore.Click += new System.EventHandler(this.btnOkCancelIgnore_Click);
            // 
            // btnOkCancel
            // 
            this.btnOkCancel.Location = new System.Drawing.Point(42, 181);
            this.btnOkCancel.Name = "btnOkCancel";
            this.btnOkCancel.Size = new System.Drawing.Size(153, 23);
            this.btnOkCancel.TabIndex = 2;
            this.btnOkCancel.Text = "OK, Cancel";
            this.btnOkCancel.UseVisualStyleBackColor = true;
            this.btnOkCancel.Click += new System.EventHandler(this.btnOkOnly_Click);
            // 
            // btnYestNo
            // 
            this.btnYestNo.Location = new System.Drawing.Point(42, 138);
            this.btnYestNo.Name = "btnYestNo";
            this.btnYestNo.Size = new System.Drawing.Size(153, 23);
            this.btnYestNo.TabIndex = 3;
            this.btnYestNo.Text = "Yes, No";
            this.btnYestNo.UseVisualStyleBackColor = true;
            this.btnYestNo.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnInfoBoxYesNoCancel
            // 
            this.btnInfoBoxYesNoCancel.Location = new System.Drawing.Point(321, 39);
            this.btnInfoBoxYesNoCancel.Name = "btnInfoBoxYesNoCancel";
            this.btnInfoBoxYesNoCancel.Size = new System.Drawing.Size(233, 23);
            this.btnInfoBoxYesNoCancel.TabIndex = 4;
            this.btnInfoBoxYesNoCancel.Text = "(InfoBox) Yes, No, Cancel";
            this.btnInfoBoxYesNoCancel.UseVisualStyleBackColor = true;
            this.btnInfoBoxYesNoCancel.Click += new System.EventHandler(this.btnInfoBoxYesNoCancel_Click);
            // 
            // btnInfoBoxOkCancel
            // 
            this.btnInfoBoxOkCancel.Location = new System.Drawing.Point(321, 181);
            this.btnInfoBoxOkCancel.Name = "btnInfoBoxOkCancel";
            this.btnInfoBoxOkCancel.Size = new System.Drawing.Size(233, 23);
            this.btnInfoBoxOkCancel.TabIndex = 5;
            this.btnInfoBoxOkCancel.Text = "(InfoBox) OK, Cancel";
            this.btnInfoBoxOkCancel.UseVisualStyleBackColor = true;
            this.btnInfoBoxOkCancel.Click += new System.EventHandler(this.btnInfoBoxOkCancel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 261);
            this.Controls.Add(this.btnInfoBoxOkCancel);
            this.Controls.Add(this.btnInfoBoxYesNoCancel);
            this.Controls.Add(this.btnYestNo);
            this.Controls.Add(this.btnOkCancel);
            this.Controls.Add(this.btnAbortRetryIgnore);
            this.Controls.Add(this.btnYesNoCancel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnYesNoCancel;
        private System.Windows.Forms.Button btnAbortRetryIgnore;
        private System.Windows.Forms.Button btnOkCancel;
        private System.Windows.Forms.Button btnYestNo;
        private System.Windows.Forms.Button btnInfoBoxYesNoCancel;
        private System.Windows.Forms.Button btnInfoBoxOkCancel;
    }
}

