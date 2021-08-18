using System.ComponentModel.DataAnnotations;

using static GuestRelationsHelper.Data.DataConstants;

namespace GuestRelationsHelper.Models.Guests
{
    public class RegisterGuestViewModel
    {

        [Required]
        [MaxLength(LastNameMaxLength)]
        [MinLength(LastNameMinLength)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(PhoneMaxLength)]
        [MinLength(PhoneMinLength)]
        public string PnoneNumber { get; set; }
        [Required]
        [StringLength(ReservationPasswordLength, MinimumLength = ReservationPasswordLength)]
        public string Password { get; set; }

    }
}
