using GuestRelationsHelper.Services.HotelServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static GuestRelationsHelper.WebConstants;

namespace GuestRelationsHelper.Controllers
{
    [Authorize(Roles = GuestRoleName)]
    public class HotelServicesController : Controller
    {
        private readonly IHotelServiceService hotelServices;

        public HotelServicesController(IHotelServiceService hotelServices)
        {
            this.hotelServices = hotelServices;
        }

        public IActionResult Dining(int id)
        {
            var subcategories = this.hotelServices.GetSubCategoriesWithServices(id);
            return View(subcategories);
        }
        public IActionResult Transport(int id)
        {
            var subcategories = this.hotelServices.GetSubCategoriesWithServices(id);
            return View(subcategories);
        }
        public IActionResult Cleaning(int id)
        {
            var subcategories = this.hotelServices.GetSubCategoriesWithServices(id);
            return View(subcategories);
        }
    }
}
