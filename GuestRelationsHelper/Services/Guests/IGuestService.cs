namespace GuestRelationsHelper.Services.Guests
{
    public interface IGuestService
    {

        bool IsGuest(string Id);
        string AddGuest(string userId, string lastName, string phoneNumber, string password);
        string GetGuestByUserId(string userId);
        int GetReservationId(string guestId);
    }
}
