using System;
using System.ComponentModel.DataAnnotations;

namespace GuestRelationsHelper.Services.Reservations.Models
{
    public class ReservationSeviceModel : IReservationModel
    {
        public int Id { get; set; }

        public string Villa { get; set; }

        [DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }
        [DataType(DataType.Date)]
        public DateTime CheckOut { get; set; }
        public int GuestsCount { get; set; }

        public int RequestsCount { get; set; }
    }
}
