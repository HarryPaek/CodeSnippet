using GetFontSizeInPixels.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace GetFontSizeInPixels
{
    public partial class MainForm : Form
    {
        int idx = 0;
        Timer timer = new Timer();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // this.panelUpper.a.AutoSizeMode = AutoScaleMode.None;
            this.panelUpper.Font = new Font("Tahoma", 30, FontStyle.Bold, GraphicsUnit.Pixel);

            timer.Interval = 2000;
            timer.Tick += timer_Tick;
            timer.Enabled = true;

            this.Size = new Size(812, 400);

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            /*
            const string sampleText = "Sample Text";

            int y = 10;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            e.Graphics.DrawString(sampleText, this.Font, Brushes.Green, 10, y);
            y += this.Font.Height;

            using (StringFormat string_format = new StringFormat())
            {
                string_format.Alignment = StringAlignment.Near;
                string_format.LineAlignment = StringAlignment.Near;

                // Get the form's font size in pixels no matter
                // what unit was used to create the font.
                float size_in_pixels = this.Font.SizeInPoints / 72 * e.Graphics.DpiX;

                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddString(sampleText, this.Font.FontFamily, (int)this.Font.Style, size_in_pixels, new Point(10, y), string_format);
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(Brushes.Green, path);
                }
            }
            */
        }

        private void panelUpper_Paint(object sender, PaintEventArgs e)
        {
            const string sampleText = "Sample Text";

            int y = 10;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            e.Graphics.DrawString(sampleText, this.panelUpper.Font, Brushes.Green, 10, y);
            y += this.panelUpper.Font.Height;

            using (StringFormat string_format = new StringFormat())
            {
                string_format.Alignment = StringAlignment.Near;
                string_format.LineAlignment = StringAlignment.Near;

                // Get the form's font size in pixels no matter
                // what unit was used to create the font.
                float size_in_pixels = this.panelUpper.Font.SizeInPoints / 72 * e.Graphics.DpiX;

                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddString(sampleText, this.panelUpper.Font.FontFamily, (int)this.panelUpper.Font.Style, size_in_pixels, new Point(10, y), string_format);
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(Brushes.Green, path);
                }
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            DrawText();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            timer.Enabled = false;
            timer.Enabled = true;

            DrawText();
            LableText();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            idx++;

            if (idx > 3)
                idx = 0;

            DrawText();
            LableText();
        }


        private void DrawText()
        {
            // text and font
            string text = string.Format("{0}, one_two_three_four_five_six_seven_eight_nine_ten_eleven_twelve", idx);

            Font font = new System.Drawing.Font("Tahoma", 30, FontStyle.Regular, GraphicsUnit.Point);

            switch (idx)
            {
                case 0:
                    this.picBoxFont.Image = TextDrawing.DrawTextToBitmap(text, font, Color.Red, TextDrawing.DrawMethod.AutoSizeAccordingToText, new RectangleF(0, 0, this.picBoxFont.Width, this.picBoxFont.Height));
                    break;
                case 1:
                    this.picBoxFont.Image = TextDrawing.DrawTextToBitmap(text, font, Color.Red, TextDrawing.DrawMethod.AutoFitInConstantRectangleWithoutWarp, new RectangleF(0, 0, this.picBoxFont.Width, this.picBoxFont.Height));
                    break;
                case 2:
                    this.picBoxFont.Image = TextDrawing.DrawTextToBitmap(text, font, Color.Red, TextDrawing.DrawMethod.AutoWarpInConstantRectangle, new RectangleF(0, 0, this.picBoxFont.Width, this.picBoxFont.Height));
                    break;
                case 3:
                    this.picBoxFont.Image = TextDrawing.DrawTextToBitmap(text, font, Color.Red, TextDrawing.DrawMethod.AutoFitInConstantRectangleWithWarp, new RectangleF(0, 0, this.picBoxFont.Width, this.picBoxFont.Height));
                    break;
            }

            this.Text = string.Format("{0}, Please resize window size by mouse to see drawing methods differences.", (TextDrawing.DrawMethod)idx);
        }

        private void LableText()
        {
            //this.lblDisplayText
            // text and font
            string sampleText = "one two three four five six seven eight nine ten eleven twelve";
            Font font = new System.Drawing.Font("Tahoma", 10, FontStyle.Regular, GraphicsUnit.Point);

            int fontSize = TextDrawing.GetMaximumFontSizeFitInRectangle(sampleText, font, new RectangleF(0, 0, this.lblDisplayText.Width, this.lblDisplayText.Height), false);

            this.lblDisplayText.Font = new Font(font.FontFamily, fontSize, font.Style, GraphicsUnit.Point);
            this.lblDisplayText.Text = sampleText;
        }


        private void lblDisplayText_Paint(object sender, PaintEventArgs e)
        {
        }

        /*
        private float GetMaximumFontSizeFitInRectangle(string text, Font font, Control control, bool isWarp, float minFontSize = 0.5f, float maxFontSize = 100.0f)
        {
            Rectangle rect = new Rectangle(0, 0, control.Width, control.Height);

            float newFontSize = minFontSize;

            while(newFontSize <= maxFontSize)
            {
                Font newFont = new Font(font.FontFamily, newFontSize, font.Style);
                StringBuilder sb = new StringBuilder();

                if (isWarp) {
                    List<string> ls = WarpText(text, newFont, rect.Width, control);
                    for (int i = 0; i < ls.Count; ++i)
                    {
                        sb.Append(ls[i] + Environment.NewLine);
                    }
                }
                else {
                    sb.Append(text);
                }

                SizeF size = MeasureDrawTextSize(sb.ToString(), newFont, control);

                if (size.Width >= rect.Width || size.Height >= rect.Height)
                    return (newFontSize - 0.5f);

                if (newFontSize >= maxFontSize)
                    return (newFontSize - 0.5f);

                newFontSize += 0.5f;
            }

            return newFontSize;
        }

        private List<string> WarpText(string text, Font font, int lineWidthInPixels, Control control = null)
        {
            string[] originalLines = text.Split(new string[] { " " }, StringSplitOptions.None);

            List<string> wrappedLines = new List<string>();

            StringBuilder actualLine = new StringBuilder();
            double actualWidthInPixels = 0;

            foreach (string str in originalLines)
            {
                SizeF size = MeasureDrawTextSize(str, font, control);

                actualLine.Append(str + " ");
                actualWidthInPixels += size.Width;

                if (actualWidthInPixels > lineWidthInPixels) {
                    actualLine = actualLine.Remove(actualLine.ToString().Length - str.Length - 1, str.Length);
                    wrappedLines.Add(actualLine.ToString());
                    actualLine.Clear();
                    actualLine.Append(str + " ");
                    actualWidthInPixels = size.Width;
                }
            }

            if (actualLine.Length > 0) {
                wrappedLines.Add(actualLine.ToString());
            }

            return wrappedLines;
        }

        private SizeF MeasureDrawTextSize(string text, Font font, Control control = null)
        {
            Graphics graphics = null;

            try
            {
                if (control != null)
                    graphics = control.CreateGraphics();
                else
                    graphics = this.CreateGraphics();

                return graphics.MeasureString(text, font);

                // return new Size((int)(Math.Ceiling(size.Width)), (int)(Math.Ceiling(size.Height)));
            }
            finally
            {
                if (graphics != null)
                    graphics.Dispose();

                graphics = null;
            }
        }
        */
    }
}
