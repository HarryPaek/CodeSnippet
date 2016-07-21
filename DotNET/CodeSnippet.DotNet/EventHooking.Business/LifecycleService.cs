using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHooking.Business
{
    public class LifecycleService
    {
        public Status GetNextLifecycleStatus()
        {

            return Status.InWork;
        }
    }

    public enum Status
    {
        Planned,
        InWork,
        InReview,
        Approved,
        Obsoleted
    }
}
