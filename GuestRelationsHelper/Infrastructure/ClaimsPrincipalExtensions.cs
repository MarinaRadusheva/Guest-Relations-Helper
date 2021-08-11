using System.Security.Claims;

using static GuestRelationsHelper.WebConstants;

namespace GuestRelationsHelper.Infrastructure
{
    public static class ClaimsPrincipalExtensions
    {
        public static string Id(this ClaimsPrincipal user)
            => user.FindFirst(ClaimTypes.NameIdentifier).Value;
        public static bool IsAdmin(this ClaimsPrincipal user)
           => user.IsInRole(AdministratorRoleName);
        public static bool IsGuest(this ClaimsPrincipal user)
           => user.IsInRole(GuestRoleName);
    }
}
