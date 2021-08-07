using GuestRelationsHelper.Data.Dto;
using GuestRelationsHelper.Data.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GuestRelationsHelper.Data
{
    public class DataInitializer
    {
        public static async Task SeedVillas(GRHelperDbContext context)
        {
            if (!context.Villas.Any())
            {
                //TODO - make relative path
                string villasJson = File.ReadAllText(@"C:\Users\Marina\source\repos\ASP.NET Core Web Project\Guest-Relations-Helper\GuestRelationsHelper\Data\SeedData\" + "VillasSeedData.json");
                List<Villa> villas = JsonConvert.DeserializeObject<List<Villa>>(villasJson);
                await context.AddRangeAsync(villas);
                await context.SaveChangesAsync();
            }
        }
        public static async Task SeedCategories(GRHelperDbContext context)
        {
            if (!context.MainServiceCategories.Any())
            {
                //TODO - make relative path
                string categoriesJson = File.ReadAllText(@"C:\Users\Marina\source\repos\ASP.NET Core Web Project\Guest-Relations-Helper\GuestRelationsHelper\Data\SeedData\" + "MainCategoriesSeedData.json");
                List<MainServiceCategory> mainCategories = JsonConvert.DeserializeObject<List<MainServiceCategory>>(categoriesJson);
                await context.AddRangeAsync(mainCategories);
                await context.SaveChangesAsync();
            }
        }
        public static async Task SeedSubCategories(GRHelperDbContext context)
        {
            if (!context.SubCategories.Any())
            {
                //TODO - make relative path
                string subCategoriesJson = File.ReadAllText(@"C:\Users\Marina\source\repos\ASP.NET Core Web Project\Guest-Relations-Helper\GuestRelationsHelper\Data\SeedData\" + "SubCategoriesSeedData.json");
                List<SubCategory> subCategories = JsonConvert.DeserializeObject<List<SubCategoryDto>>(subCategoriesJson)
                    .Select(x => new SubCategory
                    {
                        Name = x.Name,
                        MainServiceCategory = context.MainServiceCategories.FirstOrDefault(c => c.Name == x.MainCategory)
                    })
                    .ToList();
                await context.AddRangeAsync(subCategories);
                await context.SaveChangesAsync();
            }
        }
        public static async Task SeedServices(GRHelperDbContext context)
        {
            if (!context.HotelServices.Any())
            {
                //TODO - make relative path
                string servicesJson = File.ReadAllText(@"C:\Users\Marina\source\repos\ASP.NET Core Web Project\Guest-Relations-Helper\GuestRelationsHelper\Data\SeedData\" + "ServicesSeedData.json");
                List<HotelService> hotelServices = JsonConvert.DeserializeObject<List<HotelServiceDto>>(servicesJson).Select(x => new HotelService
                {
                    Name = x.Name,
                    SubCategory = context.SubCategories.FirstOrDefault(c => c.Name == x.SubCategory),
                    Price = x.Price
                }).ToList();
                await context.AddRangeAsync(hotelServices);
                await context.SaveChangesAsync();
            }
        }
    }
}
