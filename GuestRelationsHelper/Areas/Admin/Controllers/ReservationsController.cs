using GuestRelationsHelper.Areas.Admin.Models;
using GuestRelationsHelper.Services.Reservations;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GuestRelationsHelper.Areas.Admin.Controllers
{
    public class ReservationsController : AdminController
    {
        private readonly IReservationService reservations;

        public ReservationsController(IReservationService reservations)
        {
            this.reservations = reservations;
        }

        public IActionResult All()
        {
            var allReservations = reservations.All();
            return this.View(allReservations);
        }

        public IActionResult Add()
        {
            return this.View(new ReservationFormModel
            {
                CheckIn=DateTime.UtcNow.Date,
                CheckOut=DateTime.UtcNow.AddDays(1).Date,
                Villas = this.reservations.AllVillas()
            }) ;
        }
    }
}
