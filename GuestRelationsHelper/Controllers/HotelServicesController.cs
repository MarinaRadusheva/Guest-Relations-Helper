using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static GuestRelationsHelper.WebConstants;

namespace GuestRelationsHelper.Controllers
{
    [Authorize(Roles = GuestRoleName)]
    public class HotelServicesController : Controller
    {
        public IActionResult Dining()
        {
            return View();
        }
        public IActionResult Transport()
        {
            return View();
        }
        public IActionResult Cleaning()
        {
            return View();
        }
    }
}
