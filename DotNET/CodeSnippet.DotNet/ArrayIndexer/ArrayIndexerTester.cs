using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayIndexer
{
    public class ArrayIndexerTester
    {
        private readonly int[,] _table;

        public ArrayIndexerTester() : this(5, 5)
        {
        }

        public ArrayIndexerTester(int sizeX, int sizeY)
        {
            _table = new int[5, 5];
        }

        public int this[int idxX, int idxY]
        {
            get
            {
                return _table[idxX, idxY];
            }
            set
            {
                _table[idxX, idxY] = value;
            }
        }

        // public int this[int idxX, int idxY] => _table[idxX, idxY];  /* C# 6.0 Only? */
    }
}
