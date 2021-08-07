using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static GuestRelationsHelper.Data.DataConstants;

namespace GuestRelationsHelper.Data.Models
{
    public class SubCategory
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; init; }
        public int MainServiceCategoryId { get; init; }
        public MainServiceCategory MainServiceCategory { get; init; }
        public virtual ICollection<HotelService> HotelServices { get; set; }
    }
}
