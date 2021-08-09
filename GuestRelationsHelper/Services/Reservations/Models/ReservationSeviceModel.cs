using System;

namespace GuestRelationsHelper.Services.Reservations.Models
{
    public class ReservationSeviceModel : IReservationModel
    {
        public int Id { get; set; }

        public string Villa { get; set; }

        public DateTime CheckIn { get; set; }

        public int RequestsCount { get; set; }
    }
}
