using GuestRelationsHelper.Services.Reservations.Models;
using System.Collections.Generic;

namespace GuestRelationsHelper.Services.Reservations
{
    public interface IReservationService
    {
        IEnumerable<ReservationSeviceModel> All();
        IEnumerable<VillaServiceModel> AllVillas();
    }
}
