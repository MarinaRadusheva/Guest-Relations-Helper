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

        public bool Cancel(int id)
        {
            var requestToCancel = this.data.GuestRequests.Find(id);
            if (requestToCancel.RequestStatus==RequestStatus.Cancelled)
            {
                return false;
                
            }
            requestToCancel.RequestStatus = RequestStatus.Cancelled;
            this.data.SaveChanges();
            return true;
        }

        public bool ChangeStatus(int id)
        {
            var requestToChange = this.data.GuestRequests.Find(id);
            if (requestToChange.RequestStatus==RequestStatus.Waiting)
            {
                requestToChange.RequestStatus = RequestStatus.InProgress;
                this.data.SaveChanges();
                return true;
            }
            else if (requestToChange.RequestStatus==RequestStatus.InProgress)
            {
                requestToChange.RequestStatus = RequestStatus.Done;
                this.data.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public int PendingRequests()
        {
            return this.data.GuestRequests
                .Where(x => x.RequestStatus == RequestStatus.Waiting || x.RequestStatus == RequestStatus.InProgress)
                .Select(x => x)
                .Count();
        }
    }
}
