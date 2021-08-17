using GuestRelationsHelper.Services.HotelServices.Models;
using System.Collections.Generic;

namespace GuestRelationsHelper.Services.HotelServices
{
    public interface IHotelServiceService
    {
        IEnumerable<SubCategoryServiceModel> GetSubCategoriesWithServices(int categoryId);
        string GetNameById(int id);
        bool HasPrice(int id);
    }
}
