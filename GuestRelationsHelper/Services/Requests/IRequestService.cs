using GuestRelationsHelper.Services.Requests.Models;
using System;
using System.Collections.Generic;

namespace GuestRelationsHelper.Services.Requests
{
    public interface IRequestService
    {
        IEnumerable<RequestServiceModel> All();
        IEnumerable<RequestServiceModel> All(int id);
        int Add(int reservationId, DateTime? date, DateTime time, int guestsCount, string ServiceName, string status);
    }
}
