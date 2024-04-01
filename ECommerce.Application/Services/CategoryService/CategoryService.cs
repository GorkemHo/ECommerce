using AutoMapper;
using ECommerce.Application.Models.DTOs.CategortyDto;
using ECommerce.Application.Models.VMs.CategoryVMs;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using ECommerce.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<List<CategoryVM>> GetCategories()
        {
            var categories = await _categoryRepo.GetFilteredList(select: x => _mapper.Map<CategoryVM>(x),
                where: x => !x.Status.Equals(Status.Passive),
                orderby: x => x.OrderBy(x => x.Name));
            return categories;
        }

        public async Task<List<CategoryVM>> GetCategoriesWithProducts()
        {
            var categories = await _categoryRepo.GetFilteredList(
                select: x => new CategoryVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                },
                where: x => x.Status != Status.Passive, 
                include : x => x.Include(x => x.Products)
                );
            return categories;
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
