using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Counter
    {
        private int threshold;
        private int total;

        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;

        public Counter(int threshold)
        {
            this.threshold = threshold;
        }

        public void Add(int x)
        {
            total += x;

            if(total >= threshold)
            {
                ThresholdReachedEventArgs args = new ThresholdReachedEventArgs {
                    Threshold = threshold,
                    TimeReached = DateTime.Now
                };

                OnThresholdReached(args);
            }
        }

        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            EventHandler<ThresholdReachedEventArgs> handler = ThresholdReached;

            if (handler != null)
                handler(this, e);
        }
    }
}
