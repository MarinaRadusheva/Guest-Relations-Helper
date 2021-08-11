namespace GuestRelationsHelper.Services.Guests
{
    interface IGuestService
    {

        bool IsGuest(string Id);
        string AddGuest(string userId, string lastName, string phoneNumber, string password);
    }
}
