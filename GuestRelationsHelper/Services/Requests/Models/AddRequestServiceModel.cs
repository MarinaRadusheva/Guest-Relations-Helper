using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestRelationsHelper.Services.Requests.Models
{
    public class AddRequestServiceModel : RequestServiceModel
    {
        public int GuestsCount { get; set; }
        public int ServiceId { get; init; }
    }
}
