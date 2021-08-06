using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestRelationsHelper.Data.Models
{
    public enum RequestStatus
    {
        Waiting = 0,
        InProgress = 1,
        Done = 2,
        Cancelled = 3,

    }
}
