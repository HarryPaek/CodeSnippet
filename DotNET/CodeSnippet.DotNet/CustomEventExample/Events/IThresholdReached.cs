using ConsoleApplication1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEventSample.Events
{
    public interface IThresholdReached
    {
        event EventHandler<ThresholdReachedEventArgs> ThresholdReached;

        void Handle(object sender, ThresholdReachedEventArgs e);
    }
}
