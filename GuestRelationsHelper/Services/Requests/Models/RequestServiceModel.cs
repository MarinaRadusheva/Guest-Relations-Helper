using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuestRelationsHelper.Services.Requests.Models
{
    public class RequestServiceModel : IRequestModel
    {
        public int Id { get; init; }

        [Required]
        public string VillaNumber { get; init; }

        [Required]
        public string ServiceName { get; init; }
        [DataType(DataType.Date)]
        public DateTime? Date { get; init; }

        [DataType(DataType.Time)]
        public DateTime Time { get; init; }

        [Required]
        public string Status { get; init; }

    }
}
