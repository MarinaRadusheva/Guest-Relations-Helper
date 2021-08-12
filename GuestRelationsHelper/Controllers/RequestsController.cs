using GuestRelationsHelper.Infrastructure;
using GuestRelationsHelper.Services.Guests;
using GuestRelationsHelper.Services.Requests;
using GuestRelationsHelper.Services.Reservations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static GuestRelationsHelper.WebConstants;

namespace GuestRelationsHelper.Controllers
{
    public class RequestsController : Controller
    {
        private readonly IRequestService requests;
        private readonly IReservationService reservations;
        private readonly IGuestService guests;

        public RequestsController(IRequestService requests, IReservationService reservations, IGuestService guests)
        {
            this.requests = requests;
            this.reservations = reservations;
            this.guests = guests;
        }

        [Authorize(Roles = GuestRoleName)]
        public IActionResult All()
        {
            var userId = this.User.Id();
            var guestId = this.guests.GetGuestByUserId(userId);
            var reservationId = this.guests.GetReservationId(guestId);
            var requests = this.requests.All(reservationId);

            return View(requests);
        }
    }
}
