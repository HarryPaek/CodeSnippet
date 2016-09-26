using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEventSample.Events
{
    public interface IThresholdEventDelegate<T>
    {
        event EventHandler<T> EventDelegate;

        void Handle(object sender, T e);
    }
}
