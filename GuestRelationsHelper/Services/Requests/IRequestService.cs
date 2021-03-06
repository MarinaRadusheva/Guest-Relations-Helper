using GuestRelationsHelper.Services.Requests.Models;
using System;
using System.Collections.Generic;

namespace GuestRelationsHelper.Services.Requests
{
    public interface IRequestService
    {
        IEnumerable<RequestServiceModel> All();
        IEnumerable<RequestServiceModel> All(int id);
        IEnumerable<RequestServiceModel> Archived();
        int Add(int reservationId, int serviceId, DateTime date, DateTime time, int guestsCount, bool isDaily, string paymentType);
        bool Cancel(int id);
        bool ChangeStatus(int id);
        int PendingRequests();

    }
}
