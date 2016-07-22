using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrapTwoInterfaceEvents.Abstracts;
using WrapTwoInterfaceEvents.Impl;

namespace WrapTwoInterfaceEvents.SubscriberExamples
{
    class SubscriberTwo
    {
        public SubscriberTwo(Shape shape)
        {
            IShape d = (IShape)shape;
            d.OnDraw += new EventHandler(d_OnDraw);
        }

        void d_OnDraw(object sender, EventArgs e)
        {
            Console.WriteLine("SubscriberTwo receives the IShape event.");
        }
    }
}
