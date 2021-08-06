using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using static GuestRelationsHelper.Data.HelperMethods;
using static GuestRelationsHelper.Data.DataConstants;

namespace GuestRelationsHelper.Data.Models
{
    public class Reservation
    {
        public int Id { get; init; }

        public int VillaId { get; set; }

        public virtual Villa Villa { get; set; }

        public int GuestsCount { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }
        
        [Required]
        public string Password { get; init; } = GenerateReservationPassword(ReservationPasswordLength);

        public string UserId { get; set; }

        public virtual IdentityUser User { get; set; }

        public ICollection<GuestRequest> GuestRequests { get; set; } = new List<GuestRequest>();
    }
}
