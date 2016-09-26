using CustomEventSample.Events;
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

        public Counter(int threshold)
        {
            this.threshold = threshold;
        }


        #region Properties

        public IThresholdEventDelegate<ThresholdReachingEventArgs> ThresholdReachingEventHandler { get; set; }
        public IThresholdEventDelegate<ThresholdReachedEventArgs> ThresholdReachedEventHandler { get; set; }

        #endregion


        #region Public Methods

        public void Add(int x)
        {
            total += x;

            if(total >= threshold)
            {
                ThresholdReachingEventArgs reachingArgs = new ThresholdReachingEventArgs
                {
                    Threshold = threshold,
                    TimeReached = DateTime.Now
                };

                OnThresholdReaching(reachingArgs);

                if (reachingArgs.Cancel)  // if cancelled, return
                {
                    total -= x;           // rollback;
                    return;
                }

                ThresholdReachedEventArgs reachedArgs = new ThresholdReachedEventArgs {
                    Threshold = threshold,
                    TimeReached = DateTime.Now
                };

                OnThresholdReached(reachedArgs);
            }
        }

        #endregion


        #region Protected Methods

        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            if (ThresholdReachedEventHandler != null)
                ThresholdReachedEventHandler.Handle(this, e);
        }

        protected virtual void OnThresholdReaching(ThresholdReachingEventArgs e)
        {
            if (ThresholdReachingEventHandler != null)
                ThresholdReachingEventHandler.Handle(this, e);
        }

        #endregion

        #region Private Methods


        #endregion
    }
}
