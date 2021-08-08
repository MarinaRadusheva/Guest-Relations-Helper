using GuestRelationsHelper.Data;
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
        public IEnumerable<RequestServiceModel> All()
        {
            var requests = this.data.GuestRequests
                .Where(x => x.Date > DateTime.UtcNow.AddDays(-1))
                .Select(x => new RequestServiceModel
                {
                    Id=x.Id,
                    ServiceName = x.HotelService.Name,
                    VillaNumber = x.Reservation.Villa.VillaNumber,
                    Date = x.Date,
                    Time = x.Time,
                    Status = x.RequestStatus.ToString()
                }).ToList();
            return requests;
        }
    }
}
