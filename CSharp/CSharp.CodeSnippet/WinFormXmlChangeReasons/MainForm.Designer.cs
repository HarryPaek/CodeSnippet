namespace WinFormXmlChangeReasons
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.cBoxChangeReasonList = new System.Windows.Forms.ComboBox();
            this.toolStripLogInInformation = new System.Windows.Forms.ToolStrip();
            this.tsDropDownBtnLocale = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsMenuItemKoKR = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemEnUS = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtnLoginLogout = new System.Windows.Forms.ToolStripButton();
            this.iconImageList = new System.Windows.Forms.ImageList(this.components);
            this.panelMain = new System.Windows.Forms.Panel();
            this.tableLayoutMain.SuspendLayout();
            this.toolStripLogInInformation.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 2;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutMain.Controls.Add(this.cBoxChangeReasonList, 0, 1);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutMain.RowCount = 4;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.Size = new System.Drawing.Size(776, 525);
            this.tableLayoutMain.TabIndex = 0;
            // 
            // cBoxChangeReasonList
            // 
            this.cBoxChangeReasonList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cBoxChangeReasonList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxChangeReasonList.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cBoxChangeReasonList.FormattingEnabled = true;
            this.cBoxChangeReasonList.Location = new System.Drawing.Point(10, 50);
            this.cBoxChangeReasonList.Margin = new System.Windows.Forms.Padding(7);
            this.cBoxChangeReasonList.Name = "cBoxChangeReasonList";
            this.cBoxChangeReasonList.Size = new System.Drawing.Size(371, 23);
            this.cBoxChangeReasonList.TabIndex = 0;
            // 
            // toolStripLogInInformation
            // 
            this.toolStripLogInInformation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsDropDownBtnLocale,
            this.tsBtnLoginLogout});
            this.toolStripLogInInformation.Location = new System.Drawing.Point(0, 0);
            this.toolStripLogInInformation.Name = "toolStripLogInInformation";
            this.toolStripLogInInformation.Padding = new System.Windows.Forms.Padding(3, 3, 13, 3);
            this.toolStripLogInInformation.Size = new System.Drawing.Size(784, 28);
            this.toolStripLogInInformation.TabIndex = 1;
            this.toolStripLogInInformation.Text = "toolStrip1";
            // 
            // tsDropDownBtnLocale
            // 
            this.tsDropDownBtnLocale.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsDropDownBtnLocale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsDropDownBtnLocale.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItemKoKR,
            this.tsMenuItemEnUS});
            this.tsDropDownBtnLocale.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDropDownBtnLocale.Name = "tsDropDownBtnLocale";
            this.tsDropDownBtnLocale.Size = new System.Drawing.Size(54, 19);
            this.tsDropDownBtnLocale.Text = "Locale";
            // 
            // tsMenuItemKoKR
            // 
            this.tsMenuItemKoKR.Name = "tsMenuItemKoKR";
            this.tsMenuItemKoKR.Size = new System.Drawing.Size(112, 22);
            this.tsMenuItemKoKR.Text = "Korean";
            // 
            // tsMenuItemEnUS
            // 
            this.tsMenuItemEnUS.Name = "tsMenuItemEnUS";
            this.tsMenuItemEnUS.Size = new System.Drawing.Size(112, 22);
            this.tsMenuItemEnUS.Text = "English";
            // 
            // tsBtnLoginLogout
            // 
            this.tsBtnLoginLogout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsBtnLoginLogout.ImageTransparentColor = System.Drawing.Color.White;
            this.tsBtnLoginLogout.Name = "tsBtnLoginLogout";
            this.tsBtnLoginLogout.Size = new System.Drawing.Size(41, 19);
            this.tsBtnLoginLogout.Text = "LogIn";
            this.tsBtnLoginLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // iconImageList
            // 
            this.iconImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconImageList.ImageStream")));
            this.iconImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconImageList.Images.SetKeyName(0, "en_US");
            this.iconImageList.Images.SetKeyName(1, "ko_KR");
            this.iconImageList.Images.SetKeyName(2, "Login");
            this.iconImageList.Images.SetKeyName(3, "Logout");
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.tableLayoutMain);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 28);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(3);
            this.panelMain.Size = new System.Drawing.Size(784, 533);
            this.panelMain.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.toolStripLogInInformation);
            this.Name = "MainForm";
            this.Text = "::: Change Reasons From XML";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutMain.ResumeLayout(false);
            this.toolStripLogInInformation.ResumeLayout(false);
            this.toolStripLogInInformation.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.ToolStrip toolStripLogInInformation;
        private System.Windows.Forms.ToolStripDropDownButton tsDropDownBtnLocale;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemKoKR;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemEnUS;
        private System.Windows.Forms.ToolStripButton tsBtnLoginLogout;
        private System.Windows.Forms.ImageList iconImageList;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ComboBox cBoxChangeReasonList;
    }
}

