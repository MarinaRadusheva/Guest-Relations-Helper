using System.ComponentModel.DataAnnotations;

namespace GuestRelationsHelper.Data.Models
{
    public class HotelService
    {
        public int Id { get; init; }
        [Required]
        public string Name { get; init; }
        public decimal? Price { get; init; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }

    }
}
