using ExceptionHandling.Extensions;
using ExceptionHandling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ExceptionHandling.Samples
{
    public class Example04
    {
        public void Execute()
        {
            Exception mainException = null;

            ModelA exModel01 = null;
            ModelA exModel02 = null;

            List<ModelA> exModel03 = null;
            IEnumerable<ModelA> exModel04 = null;
            IEnumerable<ModelA> exModel05 = null;

            int? exInt01 = null;
            int? exInt02 = null;
            IEnumerable<int> exInt03 = null;
            IEnumerable<int> exInt04 = null;
            IEnumerable<int> exInt05 = null;
            try
            {
                exModel01 = new ModelA { Name = "Ex-Model 01" };
                exModel03 = new List<ModelA> { exModel01 };
                exModel05= new List<ModelA> { exModel01 };

                exInt01 = int.MaxValue;
                exInt03 = new[] { 1, 3 };
                exInt04 = new List<int> { 2, 4, 9};

                MessageBox.Show(string.Format("exModel01 = [{0}]", exModel01.ToNullString()));
                MessageBox.Show(string.Format("exModel02 = [{0}]", exModel02.ToNullString()));
                MessageBox.Show(string.Format("exModel03 = [{0}]", exModel03.ToNullString()));
                MessageBox.Show(string.Format("exModel04 = [{0}]", exModel04.ToNullString()));
                MessageBox.Show(string.Format("exModel05 = [{0}]", exModel05.ToNullString()));

                MessageBox.Show(string.Format("exInt01 = [{0}]", exInt01.ToNullString()));
                MessageBox.Show(string.Format("exInt02 = [{0}]", exInt02.ToNullString()));
                MessageBox.Show(string.Format("exInt03 = [{0}]", exInt03.ToNullString()));
                MessageBox.Show(string.Format("exInt04 = [{0}]", exInt04.ToNullString()));
                MessageBox.Show(string.Format("exInt05 = [{0}]", exInt05.ToNullString()));

                MessageBox.Show(string.Format("exInt04.Where(i => i > 5) = [{0}]", exInt04.Where(i => i > 5).ToNullString()));
                MessageBox.Show(string.Format("exInt04.Select((value, index) => new {{}}) = [{0}]", exInt04.Select((value, index) => new { Index = index, Value = value }).ToNullString()));
            }
            catch(Exception ex)
            {
                mainException = ex;

                throw;
            }
            finally
            {
                MessageBox.Show(string.Format("Main Exception=[{0}]", mainException.ToNullString()), string.Format("::: {0} Exception...", this.GetType().Name), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
