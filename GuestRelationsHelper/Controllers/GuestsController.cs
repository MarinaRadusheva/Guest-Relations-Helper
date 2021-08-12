using GuestRelationsHelper.Infrastructure;
using GuestRelationsHelper.Models;
using GuestRelationsHelper.Models.Guests;
using GuestRelationsHelper.Services.Guests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static GuestRelationsHelper.WebConstants;

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
        public IActionResult Register()
        {
            if (this.User.IsAdmin() || this.User.IsGuest())
            {
                return BadRequest();
            }
            return View(new RegisterGuestViewModel());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Register(RegisterGuestViewModel guestModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(guestModel);
            }

            var userId = this.User.Id();
            var guestId = this.guests.AddGuest(this.User.Id(), guestModel.LastName, guestModel.PnoneNumber, guestModel.Password);
            if (guestId==string.Empty)
            {
                TempData[GlobalMessageKey] = $"Something went wrong. Please, enter your details again.";
                return RedirectToAction(nameof(Register));
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

    }
}
