using GuestRelationsHelper.Data;
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
                    RequestsCount = x.GuestRequests.Count()
                })
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
    }
}
