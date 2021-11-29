using System;
using System.Windows.Forms;

namespace ExceptionHandling.Samples
{
    public class Example01
    {
        public void Execute()
        {
            Exception mainException = null;

            try
            {
                mainException = new NotImplementedException(string.Format("'{0}' Not Implemented!!!", this.GetType().Name));

                throw mainException;
            }
            catch
            {
                throw;
            }
            finally
            {
                MessageBox.Show(string.Format("Main Exception=[{0}]", mainException.Message), string.Format("::: {0} Exception...", this.GetType().Name), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
