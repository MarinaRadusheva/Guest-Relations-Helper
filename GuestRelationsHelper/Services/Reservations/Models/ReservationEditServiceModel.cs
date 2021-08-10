using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestRelationsHelper.Services.Reservations.Models
{
    public class ReservationEditServiceModel : IReservationModel
    {
        public int Id { get; set; }

        public string Villa { get; set; }

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int GuestsCount { get; set; }

    }
}
