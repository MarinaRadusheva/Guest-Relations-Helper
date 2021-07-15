using System.ComponentModel.DataAnnotations;

using static GuestRelationsHelper.Data.DataConstants;

namespace GuestRelationsHelper.Data.Models
{
    public class Villa
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(VillaNumberMaxLength)]
        public string VillaNumber { get; init; }

        public int Bedrooms { get; init; }

        public ResortSection Section { get; init; }
    }
}
