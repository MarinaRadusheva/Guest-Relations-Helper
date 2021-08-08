using GuestRelationsHelper.Services.Requests.Models;
using System.Collections.Generic;

namespace GuestRelationsHelper.Services.Requests
{
    public interface IRequestService
    {
        IEnumerable<RequestServiceModel> All();
    }
}
