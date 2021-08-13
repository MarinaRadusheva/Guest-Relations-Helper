using GuestRelationsHelper.Data.Models;
using GuestRelationsHelper.Infrastructure;
using GuestRelationsHelper.Services.Guests;
using GuestRelationsHelper.Services.HotelServices;
using GuestRelationsHelper.Services.Requests;
using GuestRelationsHelper.Services.Requests.Models;
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
        private readonly IHotelServiceService hotelServices;

        public RequestsController(IRequestService requests, IReservationService reservations, IGuestService guests, IHotelServiceService hotelServices)
        {
            this.requests = requests;
            this.reservations = reservations;
            this.guests = guests;
            this.hotelServices = hotelServices;
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

        [Authorize(Roles = GuestRoleName)]
        public IActionResult Add(int Id)
        {
            var serviceName = this.hotelServices.GetNameById(Id);
            var userId = this.User.Id();
            var guestId = this.guests.GetGuestByUserId(userId);
            var reservationId = this.guests.GetReservationId(guestId);
            var villaNumber = this.reservations.GetVilla(reservationId);
            var request = new AddRequestServiceModel
            {
                ServiceId=Id,
                ServiceName = serviceName,
                Status = RequestStatus.Waiting.ToString(),
                VillaNumber = villaNumber
            };

            return View(request);
        }
    }
}
