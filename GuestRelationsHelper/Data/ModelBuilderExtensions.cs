using GuestRelationsHelper.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GuestRelationsHelper.Data
{
    public static class ModelBuilderExtensions
    {
        public static void SeedVillas(this ModelBuilder builder)
        {
            builder.Entity<Villa>().HasData(
                new Villa
                {
                    Id = 0,
                    VillaNumber = "R1"
                },
                new Villa
                {
                    Id = 1,
                    VillaNumber = "R2"
                },
                new Villa
                {
                    Id = 2,
                    VillaNumber = "R3"
                },
                new Villa
                {
                    Id = 2,
                    VillaNumber = "R3"
                },
                new Villa
                {
                    Id = 2,
                    VillaNumber = "R3"
                },
                new Villa
                {
                    Id = 2,
                    VillaNumber = "R3"
                },
                new Villa
                {
                    Id = 2,
                    VillaNumber = "R3"
                },
                new Villa
                {
                    Id = 2,
                    VillaNumber = "R3"
                },
                new Villa
                {
                    Id = 2,
                    VillaNumber = "R3"
                },
                new Villa
                {
                    Id = 2,
                    VillaNumber = "R3"
                }
                );
        }
    }
}
