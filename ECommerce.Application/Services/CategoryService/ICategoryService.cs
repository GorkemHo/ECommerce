using ECommerce.Application.Models.DTOs.CategortyDto;
using ECommerce.Application.Models.DTOs.ProductDTOs;
using ECommerce.Application.Models.VMs.CategoryVMs;

namespace ECommerce.Application.Services.CategoryService
{
    public interface ICategoryService
    {
        Task Create(CreateCategoryDto model);
        Task Update(UpdateCategoryDto model);
        Task Delete(int id);
        Task<List<CategoryVm>> GetCategories();
        Task<UpdateCategoryDto> GetCategoryById(int id);

        Task<List<CategoryVm>> GetCategoriesWithProducts(); //???
    }
}
