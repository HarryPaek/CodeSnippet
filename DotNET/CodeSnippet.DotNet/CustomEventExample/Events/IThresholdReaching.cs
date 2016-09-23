using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEventSample.Events
{
    public interface IThresholdReaching
    {
        event EventHandler<ThresholdReachingEventArgs> ThresholdReaching;

        void Handle(object sender, ThresholdReachingEventArgs e);
    }
}
