using GuestRelationsHelper.Services.Guests;
using Microsoft.AspNetCore.Mvc;

namespace GuestRelationsHelper.Controllers
{
    public class GuestsController : Controller
    {
        private readonly GuestService guests;

        public GuestsController(GuestService guests)
        {
            this.guests = guests;
        }

        //public IActionResult Register()
        //{

        //}
    }
}
