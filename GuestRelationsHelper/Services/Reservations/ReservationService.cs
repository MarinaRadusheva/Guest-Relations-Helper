using GuestRelationsHelper.Data;
using GuestRelationsHelper.Data.Models;
using GuestRelationsHelper.Services.Reservations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestRelationsHelper.Services.Reservations
{
    public class ReservationService : IReservationService
    {
        private readonly GRHelperDbContext data;

        public ReservationService(GRHelperDbContext data)
        {
            this.data = data;
        }

        public IEnumerable<ReservationSeviceModel> All()
        {
            var allReservations = this.data.Reservations
                .Select(x => new ReservationSeviceModel
                {
                    Id = x.Id,
                    Villa = x.Villa.VillaNumber,
                    CheckIn = x.CheckIn,
                    CheckOut=x.CheckOut,
                    GuestsCount=x.GuestsCount,
                    RequestsCount = x.GuestRequests.Count()
                })
                .OrderBy(x=>x.CheckIn)
                .ToList();
            return allReservations;
        }
        public IEnumerable<VillaServiceModel> AllVillas()
        {
            return this.data.Villas
                .Select(x => new VillaServiceModel
                {
                    Id = x.Id,
                    VillaNumber = x.VillaNumber
                })
                .OrderBy(x=>x.VillaNumber.Substring(0,1))
                .ToList();
        }

        public int Add(DateTime checkIn, DateTime checkOut, int guestCount, int villaId)
        {
            var newReservation = new Reservation
            {
                CheckIn = checkIn,
                CheckOut = checkOut,
                GuestsCount = guestCount,
                VillaId = villaId,

            };

            this.data.Reservations.Add(newReservation);
            this.data.SaveChanges();

            return newReservation.Id;
        }

        public string GetPassword(int reservationId)
        {
            var reservation = this.data.Reservations.Find(reservationId);
            return reservation.Password;
        }
        public int? GetByPassword(string password)
        {
            var passwordExists = this.data.Reservations.Any(x => x.Password == password);
            if (!passwordExists)
            {
                return null;
            }
            var reservationId = this.data.Reservations
                .Where(x => x.Password == password)
                .Select(x=>x.Id)
                .FirstOrDefault();
            return reservationId;
        }

        public ReservationEditServiceModel GetReservation(int id)
        {
            var reservation = this.data.Reservations.Where(x => x.Id == id).Select(x => new ReservationEditServiceModel
            {
                Id = x.Id,
                CheckIn = x.CheckIn,
                CheckOut = x.CheckOut,
                Villa = x.Villa.VillaNumber,
                GuestsCount = x.GuestsCount,
            }).FirstOrDefault();
            return reservation;
        }

        public bool Edited (int id, DateTime checkIn, DateTime checkOut, int guestsCount, int villaId)
        {
            var reservation = this.data.Reservations.Find(id);
            if (reservation==null)
            {
                return false;
            }
            reservation.CheckIn = checkIn;
            reservation.CheckOut = checkOut;
            reservation.GuestsCount = guestsCount;
            reservation.VillaId = villaId;

            this.data.SaveChanges();
            return true;
        }

        public string GetVilla(int reservationId)
        {
            return this.data.Reservations.Where(x => x.Id == reservationId).Select(x => x.Villa.VillaNumber).FirstOrDefault();
        }
    }
}
