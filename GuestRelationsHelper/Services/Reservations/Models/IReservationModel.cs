using System;

namespace GuestRelationsHelper.Services.Reservations.Models
{
    public interface IReservationModel
    {
        public int Id { get;}
        public string Villa { get;}
        public DateTime CheckIn { get;}
    }
}
