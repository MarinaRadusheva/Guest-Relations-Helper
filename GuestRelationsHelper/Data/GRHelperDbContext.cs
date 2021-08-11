using GuestRelationsHelper.Data.Models;
using Microsoft.AspNetCore.Identity;
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

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<GuestRequest> GuestRequests { get; set; }
        public DbSet<HotelService> HotelServices { get; set; }
        public DbSet<MainServiceCategory> MainServiceCategories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Villa> Villas { get; set; }
        public DbSet<Guest> Guests { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Guest>()
            //    .HasOne<IdentityUser>()
            //    .WithOne()
            //    .HasForeignKey<Guest>(x => x.UserId)
            //    .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Reservation>().HasOne(x=>x.Guest).WithOne(x => x.Reservation).HasForeignKey<Guest>(x => x.ReservationId).OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
