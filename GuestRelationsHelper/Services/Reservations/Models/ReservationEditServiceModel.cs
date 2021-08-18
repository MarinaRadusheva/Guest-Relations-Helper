using System;
using System.ComponentModel.DataAnnotations;

using static GuestRelationsHelper.Data.DataConstants;

namespace GuestRelationsHelper.Services.Reservations.Models
{
    public class ReservationEditServiceModel : IReservationModel
    {
        public int Id { get; set; }

        public string Villa { get; set; }

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        [Range(GuestMinCount, GuestMaxCount)]
        public int GuestsCount { get; set; }

    }
}
