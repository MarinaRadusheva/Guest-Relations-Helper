using GuestRelationsHelper.Areas.Admin.Models;
using GuestRelationsHelper.Services.Reservations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

using static GuestRelationsHelper.WebConstants;

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

        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult Add()
        {
            return this.View(new ReservationFormModel
            {
                CheckIn=DateTime.UtcNow.Date,
                CheckOut=DateTime.UtcNow.AddDays(1).Date,
                Villas = this.reservations.AllVillas()
            }) ;
        }

        
        [HttpPost]
        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult Add(ReservationFormModel reservation)
        {
            if (!ModelState.IsValid)
            {
                reservation.Villas = this.reservations.AllVillas();
                return View(reservation);
            }

            var reservationId = this.reservations.Add(
                reservation.CheckIn, 
                reservation.CheckOut, 
                reservation.GuestsCount, 
                reservation.VillaId);

            string password = this.reservations.GetPassword(reservationId);

            TempData[GlobalMessageKey] = $"The reservation was added. Password is {password}";

            return RedirectToAction(nameof(All));
        }
        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult Edit(int id)
        {
            var reservation = this.reservations.GetReservation(id);
            var reservationFormModel = new ReservationFormModel
            {
                CheckIn = reservation.CheckIn,
                CheckOut = reservation.CheckOut,
                Villa = reservation.Villa,
                GuestsCount = reservation.GuestsCount,

            };
            reservationFormModel.Villas = this.reservations.AllVillas();
            return View(reservationFormModel);
        }

        [HttpPost]
        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult Edit(int id, ReservationFormModel reservation)
        {
            if (!ModelState.IsValid)
            {
                reservation.Villas = this.reservations.AllVillas();
                return View(reservation);
            }
            var edited = this.reservations.Edited(id, reservation.CheckIn, reservation.CheckOut, reservation.GuestsCount, reservation.VillaId);
            if (!edited)
            {
                return BadRequest();
            }
            TempData[GlobalMessageKey] = "Changes to the reservation have been applied";
            return RedirectToAction(nameof(All));
        }
    }
}
