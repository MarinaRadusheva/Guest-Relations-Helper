using GuestRelationsHelper.Services.Requests;
using Microsoft.AspNetCore.Mvc;

namespace GuestRelationsHelper.Areas.Admin.Controllers
{
    public class RequestsController : AdminController
    {
        private readonly IRequestService requests;

        public RequestsController(IRequestService requests)
        {
            this.requests = requests;
        }

        public IActionResult All()
        {
            var allRequests = this.requests.All();
            return this.View(allRequests);
        }
    }
}
