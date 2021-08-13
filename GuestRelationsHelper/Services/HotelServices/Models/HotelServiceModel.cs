using System.ComponentModel.DataAnnotations;

namespace GuestRelationsHelper.Services.HotelServices.Models
{
    public class HotelServiceModel
    {
        public int Id { get; init; }
        [Required]
        public string Name { get; init; }
        public decimal? Price { get; init; }
        public int SubCategoryId { get; set; }
    }
}
