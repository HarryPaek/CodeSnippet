using System.Collections.Generic;

namespace GenresPlaysExample
{
    public class CustomComparer: IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return string.Format("{0}{1}", x, y).CompareTo(string.Format("{0}{1}", y, x));
        }
    }
}
