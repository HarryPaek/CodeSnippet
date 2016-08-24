using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XElementExample
{
    public class ActivityUser
    {
        public string Key { get; set; }
        public string Table { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return string.Format("[Name={0}, Key={1}, Table={2}, Title={3}]", Name, Key, Table, Title);
        }
    }
}
