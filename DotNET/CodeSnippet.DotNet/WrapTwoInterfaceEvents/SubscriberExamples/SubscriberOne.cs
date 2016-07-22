using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrapTwoInterfaceEvents.Abstracts;
using WrapTwoInterfaceEvents.Impl;

namespace WrapTwoInterfaceEvents.SubscriberExamples
{
    public class SubscriberOne
    {
        // References the shape object as an IDrawingObject
        public SubscriberOne(Shape shape)
        {
            IDrawingObject d = (IDrawingObject)shape;
            d.OnDraw += new EventHandler(d_OnDraw);
        }

        void d_OnDraw(object sender, EventArgs e)
        {
            Console.WriteLine("SubscriberOne receives the IDrawingObject event.");
        }
    }
}
