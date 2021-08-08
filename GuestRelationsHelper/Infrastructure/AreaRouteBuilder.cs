using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace GuestRelationsHelper.Infrastructure
{
    public static class AreaRouteBuilder
    {
        public static void MapDefaultAreaRoute(this IEndpointRouteBuilder endpoints)
            => endpoints.MapControllerRoute(
                name: "Areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    }
}
