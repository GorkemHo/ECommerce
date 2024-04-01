using ECommerce.Application.Models.DTOs.CategortyDto;
using ECommerce.Application.Models.VMs.CategoryVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.CategoryService
{
    public interface ICategoryService
    {
        Task Create(CreateCategoryDto model);
        Task Update(UpdateCategoryDto model);
        Task Delete(int id);
        Task<List<CategoryVM>> GetCategories();
        Task<List<CategoryVM>> GetCategoriesWithProducts(); //???
    }
}
