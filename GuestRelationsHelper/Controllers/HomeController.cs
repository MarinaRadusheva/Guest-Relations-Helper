using GuestRelationsHelper.Models;
using GuestRelationsHelper.Services.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GuestRelationsHelper.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRequestService requests;

        public HomeController(IRequestService requests)
        {
            this.requests = requests;
        }

        public IActionResult Index()
        {
            var pendingRequests = this.requests.PendingRequests();
            ViewBag.PendingRequests = pendingRequests;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
