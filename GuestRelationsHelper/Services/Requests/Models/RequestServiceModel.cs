using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestRelationsHelper.Services.Requests.Models
{
    public class RequestServiceModel : IRequestModel
    {
        public int Id { get; init; }
        public string VillaNumber { get; init; }

        public string ServiceName { get; init; }

        public DateTime? Date { get; init; }

        public DateTime Time { get; init; }

        public string Status { get; init; }

    }
}
