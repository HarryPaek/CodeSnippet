using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling.Models
{
    public class ModelA
    {
        public ModelA()
        {
            this.Name = string.Empty;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
