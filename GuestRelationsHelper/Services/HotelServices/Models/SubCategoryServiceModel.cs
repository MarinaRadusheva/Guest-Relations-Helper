using System.Collections.Generic;

namespace GuestRelationsHelper.Services.HotelServices.Models
{
    public class SubCategoryServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<HotelServiceModel> HotelServices { get; set; }
    }
}
