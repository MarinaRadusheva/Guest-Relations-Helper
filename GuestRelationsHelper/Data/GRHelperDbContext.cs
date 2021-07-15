using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GuestRelationsHelper.Data
{
    public class GRHelperDbContext : IdentityDbContext
    {
        public GRHelperDbContext(DbContextOptions<GRHelperDbContext> options)
            : base(options)
        {
        }
    }
}
