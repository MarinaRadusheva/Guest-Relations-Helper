using GuestRelationsHelper.Services.Reservations.Models;
using System;
using System.Collections.Generic;

namespace GuestRelationsHelper.Services.Reservations
{
    public interface IReservationService
    {
        IEnumerable<ReservationSeviceModel> All();
        IEnumerable<VillaServiceModel> AllVillas();
        int Add(DateTime checkIn, DateTime checkOut, int guestCount, int villaId);
        string GetPassword(int reservationId);
    }
}
