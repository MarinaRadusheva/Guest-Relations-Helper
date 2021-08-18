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

        public int Add(int reservationId, int serviceId, DateTime date, DateTime time, int guestsCount, bool isDaily, string paymentType)
        {
            var paymentNotApplicable = paymentType == null;
            var request = new GuestRequest
            {
                ReservationId = reservationId,
                HotelServiceId = serviceId,
                Date = date,
                IsDaily = isDaily,
                Time = time,
                GuestCount = guestsCount,
                RequestStatus = RequestStatus.Waiting,
                PaymentType = paymentNotApplicable ? null : (PaymentType)Enum.Parse(typeof(PaymentType), paymentType)
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
                    IsDaily=x.IsDaily,
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
                    IsDaily=x.IsDaily,
                    Time = x.Time,
                    Status = x.RequestStatus.ToString()
                })
                .ToList();
            return requests;
        }

        public bool ChangeStatus(int id)
        {
            var requestToChange = this.data.GuestRequests.Find(id);
            if (requestToChange.RequestStatus==RequestStatus.Cancelled)
            {
                return false;                
            }
            requestToChange.RequestStatus = RequestStatus.Cancelled;
            this.data.SaveChanges();
            return true;
        }
    }
}
