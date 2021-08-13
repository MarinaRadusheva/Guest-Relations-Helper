using GuestRelationsHelper.Data;
using GuestRelationsHelper.Data.Models;
using GuestRelationsHelper.Services.Requests.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuestRelationsHelper.Services.Requests
{
    public class RequestService : IRequestService
    {
        private readonly GRHelperDbContext data;
        public RequestService(GRHelperDbContext data)
        {
            this.data = data;
        }

        public int Add(int reservationId, DateTime? date, DateTime time, int guestsCount, string ServiceName, string status)
        {
            var request = new GuestRequest
            {
                ReservationId = reservationId,
                HotelService = this.data.HotelServices.Where(x => x.Name == ServiceName).FirstOrDefault(),
                Date = date,
                Time = time,
                GuestCount = guestsCount,
                RequestStatus = Enum.Parse<RequestStatus>(status),
                PaymentType = PaymentType.NotApplicable
            };

            this.data.GuestRequests.Add(request);
            this.data.SaveChanges();

            return request.Id;
        }

        public IEnumerable<RequestServiceModel> All()
        {
            var requests = this.data.GuestRequests
                .Where(x => x.Date > DateTime.UtcNow.AddDays(-1))
                .Select(x => new RequestServiceModel
                {
                    Id = x.Id,
                    ServiceName = x.HotelService.Name,
                    VillaNumber = x.Reservation.Villa.VillaNumber,
                    Date = x.Date,
                    Time = x.Time,
                    Status = x.RequestStatus.ToString()
                }).ToList();
            return requests;
        }

        public IEnumerable<RequestServiceModel> All(int id)
        {
            var requests = this.data.GuestRequests
                .Where(x => x.ReservationId == id)
                .Select(x => new RequestServiceModel
                {
                    Id = x.Id,
                    ServiceName = x.HotelService.Name,
                    VillaNumber = x.Reservation.Villa.VillaNumber,
                    Date = x.Date,
                    Time = x.Time,
                    Status = x.RequestStatus.ToString()
                })
                .ToList();
            return requests;
        }
    }
}
