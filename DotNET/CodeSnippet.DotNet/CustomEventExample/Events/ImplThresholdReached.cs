using ConsoleApplication1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEventSample.Events
{
    public class ImplThresholdReached : IThresholdReached
    {
        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;

        public void Handle(object sender, ThresholdReachedEventArgs e)
        {
            EventHandler<ThresholdReachedEventArgs> handler = ThresholdReached;

            if (handler != null)
                handler(sender, e);
        }
    }
}
