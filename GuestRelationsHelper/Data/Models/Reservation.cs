using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuestRelationsHelper.Data.Models
{
    public class Reservation
    {
        public int Id { get; init; }
        
        [Required]
        public string Username { get; init; }

        public Villa Villa { get; init; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public ICollection<GuestRequest> GuestRequests { get; set; }
    }
}
