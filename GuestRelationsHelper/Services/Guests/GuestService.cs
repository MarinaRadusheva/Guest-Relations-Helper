using GuestRelationsHelper.Data;
using GuestRelationsHelper.Data.Models;
using GuestRelationsHelper.Services.Reservations;
using Microsoft.AspNetCore.Identity;
using System.Linq;

using static GuestRelationsHelper.WebConstants;

namespace GuestRelationsHelper.Services.Guests
{
    public class GuestService : IGuestService
    {
        private readonly GRHelperDbContext data;
        private readonly IReservationService reservations;
        private readonly UserManager<IdentityUser> userManager;

        public GuestService(GRHelperDbContext data, IReservationService reservations, UserManager<IdentityUser> userManager)
        {
            this.data = data;
            this.reservations = reservations;
            this.userManager = userManager;
        }

        public string AddGuest(string userId, string lastName, string phoneNumber, string password)
        {
            var reservationId = this.reservations.GetByPassword(password);
            if (reservationId==null)
            {
                return string.Empty;
            }
            var guest = new Guest
            {
                LastName = lastName,
                PnoneNumber = phoneNumber,
                ReservationId = (int)reservationId,
                UserId = userId
            };
            this.data.Guests.Add(guest);
            this.data.SaveChanges();
            var user = this.data.Users.Find(userId);
            this.userManager.AddToRoleAsync(user, GuestRoleName).GetAwaiter().GetResult();
            return guest.Id;

        }

        public string GetGuestByUserId(string userId)
        {
            if (!this.IsGuest(userId))
            {
                return string.Empty;
            }
            var guestId = this.data.Guests.Where(x => x.UserId == userId).Select(x => x.Id).FirstOrDefault();
            return guestId;
        }

        public int GetReservationId(string guestId)
        {
            return this.data.Guests.Where(x => x.Id == guestId).Select(x => x.ReservationId).FirstOrDefault();
        }

        public bool IsGuest(string Id)
        {
            var guest = this.data.Guests.Where(x => x.UserId == Id).FirstOrDefault();
            if (guest==null)
            {
                return false;
            }
            return true;
        }
    }
}
