using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEventSample.Events
{
    public class ImplThresholdReaching : IThresholdReaching
    {
        public event EventHandler<ThresholdReachingEventArgs> ThresholdReaching;

        public void Handle(object sender, ThresholdReachingEventArgs e)
        {
            EventHandler<ThresholdReachingEventArgs> handler = ThresholdReaching;

            if (handler != null)
                handler(sender, e);
        }
    }
}
