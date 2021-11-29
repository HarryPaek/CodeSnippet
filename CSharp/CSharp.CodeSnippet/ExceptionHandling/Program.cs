using ExceptionHandling.Samples;
using System;
using System.Windows.Forms;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new Example01().Execute();

                MessageBox.Show("No Exception In [Example01]", "::: Exception...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Exception=[{0}]", ex.Message), "::: Exception from Example01", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            /*
            try
            {
                new Example02().Execute();

                MessageBox.Show("No Exception In [Example02]", "::: Exception...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Exception=[{0}]", ex.Message), "::: Exception from Example02", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            try
            {
                new Example03().Execute();

                MessageBox.Show("No Exception In [Example03]", "::: Exception...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Exception=[{0}]", ex.Message), "::: Exception from Example03", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            */

            try
            {
                new Example04().Execute();

                MessageBox.Show("No Exception In [Example04]", "::: Exception...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Exception=[{0}]", ex.Message), "::: Exception from Example04", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
