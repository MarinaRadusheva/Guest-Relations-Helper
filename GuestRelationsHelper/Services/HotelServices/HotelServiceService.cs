using GuestRelationsHelper.Data;
using GuestRelationsHelper.Services.HotelServices.Models;
using System.Collections.Generic;
using System.Linq;

namespace GuestRelationsHelper.Services.HotelServices
{
    public class HotelServiceService : IHotelServiceService
    {
        private readonly GRHelperDbContext data;

        public HotelServiceService(GRHelperDbContext data)
        {
            this.data = data;
        }

        public string GetNameById(int id)
        {
            return this.data.HotelServices.Where(x => x.Id == id).Select(x => x.Name).FirstOrDefault();
        }

        public IEnumerable<SubCategoryServiceModel> GetSubCategoriesWithServices(int categoryId)
        {
            var subcategories = this.data.SubCategories.Where(x => x.MainServiceCategoryId == categoryId).Select(x => new SubCategoryServiceModel
            {
                Id = x.Id,
                Name = x.Name,
                HotelServices = x.HotelServices.Select(s => new HotelServiceModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Price = s.Price,
                })
                .OrderBy(s=>s.Name)
                .ToList()
            }).ToList();

            return subcategories;
        }
    }
}
