using AutoMapper;
using ECommerce.Application.Models.DTOs.CategortyDto;

using ECommerce.Application.Models.VMs.CategoryVMs;
using ECommerce.Application.Models.VMs.ProductVMs;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using ECommerce.Domain.Repositories;
using ECommerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace ECommerce.Application.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepo _categoryRepo;
        public CategoryService(IMapper mapper, ICategoryRepo categoryRepo)
        {
            _mapper = mapper;
            _categoryRepo = categoryRepo;
        }

        public async Task Create(CreateCategoryDto model)
        {
            var category = _mapper.Map<Category>(model);

            if (category.UploadPath is not null)
            {
                using var image = Image.Load(model.UploadPath.OpenReadStream());
                image.Mutate(x => x.Resize(600, 560));
                Guid guid = Guid.NewGuid();
                image.Save($"wwwroot/images/{guid}.jpg");
                category.ImagePath = $"/images/{guid}.jpg";

                await _categoryRepo.CreateAsync(category);
            }
            else
            {
                category.ImagePath = $"/image/default.jpg";
                await _categoryRepo.CreateAsync(category);
            }
        }

        public async Task Delete(int id)
        {
            var category = await _categoryRepo.GetDefault(c => c.Id.Equals(id));

            if (category is not null)
            {
                category.DeleteDate = DateTime.Now;
                category.Status = Status.Passive;
                await _categoryRepo.DeleteAsync(category);
            }
        }

        public async Task<List<CategoryVm>> GetCategories()
        {
            var categories = await _categoryRepo.GetFilteredList(select: x => _mapper.Map<CategoryVm>(x),
                where: x => !x.Status.Equals(Status.Passive),
                orderby: x => x.OrderBy(x => x.Name));
            return categories;
        }

        public async Task<List<CategoryVm>> GetCategoriesWithProducts()
        {
            var categories = await _categoryRepo.GetFilteredList(
       select: x => new CategoryVm
       {
           Id = x.Id,
           Name = x.Name,
           Description = x.Description,
           Products = x.Products.Select(p => new Product
           {
               Id = p.Id,
               Name = p.Name,
               Color = p.Color,
               Price = p.Price,
               Quantity = p.Quantity,
               Description = p.Description
           }).ToList(),
       },
       where: x => x.Status != Status.Passive,
       include: x => x.Include(x => x.Products));

            return categories;
        }

        public async Task<UpdateCategoryDto> GetCategoryById(int id)
        {
            var category = await _categoryRepo.GetFilteredFirstOrDefault(select: x => _mapper.Map<UpdateCategoryDto>(x),
                                                              where: x => x.Id == id);
            return category;
        }

        public async Task Update(UpdateCategoryDto model)
        {
            var category = _mapper.Map<Category>(model);

            if (category.UploadPath is not null)
            {
                using var image = Image.Load(model.UploadPath.OpenReadStream());
                image.Mutate(x => x.Resize(600, 560));
                Guid guid = Guid.NewGuid();
                image.Save($"wwwroot/images/{guid}.jpg");
                category.ImagePath = $"/images/{guid}.jpg";

                await _categoryRepo.UpdateAsync(category);
            }
            else
            {
                category.ImagePath = $"/image/default.jpg";
                await _categoryRepo.UpdateAsync(category);
            }
        }


    }
}
