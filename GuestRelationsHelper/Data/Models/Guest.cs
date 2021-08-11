using System;
using System.ComponentModel.DataAnnotations;

using static GuestRelationsHelper.Data.DataConstants;

namespace GuestRelationsHelper.Data.Models
{
    public class Guest
    {
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(PhoneMaxLength)]
        public string PnoneNumber { get; set; }
        public int ReservationId { get; init; }
        public virtual Reservation Reservation { get; init; }
        [Required]
        public string UserId { get; init; }
    }
}
