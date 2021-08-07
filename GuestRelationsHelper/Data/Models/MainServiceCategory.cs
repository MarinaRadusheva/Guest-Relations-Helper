using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static GuestRelationsHelper.Data.DataConstants;

namespace GuestRelationsHelper.Data.Models
{
    public class MainServiceCategory
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; init; }
        public ICollection<SubCategory> SubCategories { get; set; }
    }
}
