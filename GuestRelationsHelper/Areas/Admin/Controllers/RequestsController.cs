using GuestRelationsHelper.Services.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static GuestRelationsHelper.WebConstants;

namespace GuestRelationsHelper.Areas.Admin.Controllers
{
    public class RequestsController : AdminController
    {
        private readonly IRequestService requests;

        public RequestsController(IRequestService requests)
        {
            this.requests = requests;
        }

        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult All()
        {
            var allRequests = this.requests.All();
            return this.View(allRequests);
        }

        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult AllByReservation(int id)
        {
            var allRequests = this.requests.All(id);
            return this.View(allRequests);
        }

        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult Cancel(int Id)
        {
            this.requests.Cancel(Id);
            return RedirectToAction(nameof(All));
        }

        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult ChangeStatus(int Id)
        {
            this.requests.ChangeStatus(Id);
            return RedirectToAction(nameof(All));
        }
    }
}
