﻿namespace EventCancelExample
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
            this.isDataSaved = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // isDataSaved
            // 
            this.isDataSaved.AutoSize = true;
            this.isDataSaved.Location = new System.Drawing.Point(49, 43);
            this.isDataSaved.Name = "isDataSaved";
            this.isDataSaved.Size = new System.Drawing.Size(88, 16);
            this.isDataSaved.TabIndex = 0;
            this.isDataSaved.Text = "Data Saved";
            this.isDataSaved.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.isDataSaved);
            this.Name = "Form1";
            this.Text = "Main Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox isDataSaved;
    }
}

