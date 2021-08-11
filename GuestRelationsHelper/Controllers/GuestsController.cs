using GuestRelationsHelper.Models.Guests;
using GuestRelationsHelper.Services.Guests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuestRelationsHelper.Controllers
{
    public class GuestsController : Controller
    {
        private readonly IGuestService guests;

        public GuestsController(IGuestService guests)
        {
            this.guests = guests;
        }

        [Authorize]
        public IActionResult Register(string userId)
        {
            return View(new RegisterGuestViewModel());
        }
    }
}
