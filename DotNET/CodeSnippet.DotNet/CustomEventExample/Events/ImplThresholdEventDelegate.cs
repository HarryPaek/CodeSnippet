using System;

namespace CustomEventSample.Events
{
    public class ImplThresholdEventDelegate<T> : IThresholdEventDelegate<T>
    {
        public event EventHandler<T> EventDelegate;

        public void Handle(object sender, T e)
        {
            EventHandler<T> handler = EventDelegate;

            if (handler != null)
                handler(sender, e);
        }
    }
}
