using AutoMapper;
using ECommerce.Application.Models.DTOs.ProductDTOs;
using ECommerce.Application.Models.VMs.CategoryVMs;
using ECommerce.Application.Models.VMs.ProductVMs;
using ECommerce.Application.Services.CategoryService;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using ECommerce.Domain.Repositories;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.Drawing;

namespace ECommerce.Application.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
        private readonly ICategoryRepo _categoryRepo;
        private readonly ICategoryService _categoryService;
        private readonly IOrderRepo _orderRepo;
        private readonly IMapper _mapper;


        public ProductService(IProductRepo productRepo, ICategoryRepo categoryRepo, IOrderRepo orderRepo, IMapper mapper, ICategoryService categoryService)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
            _orderRepo = orderRepo;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public async Task Create(CreateProductDto model)
        {
            var product = _mapper.Map<Product>(model);

            if (product.UploadPath != null)
            {
                using var image = Image.Load(model.UploadPath.OpenReadStream());
                image.Mutate(x => x.Resize(600, 560));
                Guid guid = Guid.NewGuid();
                image.Save($"wwwroot/images/{guid}.jpg");
                product.ImagePath = $"/images/{guid}.jpg";

                await _productRepo.CreateAsync(product);
            }

            else
            {
                product.ImagePath = $"/image/defaultpost.png";
                await _productRepo.CreateAsync(product);
            }
        }

        public async Task Delete(int id)
        {
            var deletedProduct = await _productRepo.GetDefault(x => x.Id.Equals(id));

            if (deletedProduct is not null)
            {
                deletedProduct.DeleteDate = DateTime.Now;
                deletedProduct.Status = Status.Passive;
                await _productRepo.UpdateAsync(deletedProduct);
            }
        }

        public async Task<CreateProductDto> FillProduct()
        {
            CreateProductDto model = new CreateProductDto()
            {
                Categories = await _categoryRepo.GetFilteredList(
                   select: x => new CategoryVm
                   {
                       Id = x.Id,
                       Name = x.Name
                   },
                   where: x => x.Status != Status.Passive),
            };
            return model;
        }

        public async Task<ProductVm> GetById(int id)
        {
            var product = await _productRepo.GetFilteredFirstOrDefault(select: x => _mapper.Map<ProductVm>(x),
                                                              where: x => x.Id == id && !x.Status.Equals(Status.Passive));
            return product;
        }

        public async Task<List<ProductVm>> GetProducts()
        {
            var products = await _productRepo.GetFilteredList(select: x => new ProductVm
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Color = x.Color,
                ImagePath = x.ImagePath,
                Description = x.Description,
                CategoryId = x.CategoryId, 
                CategoryName = x.Category.Name
            },
    where: x => !x.Status.Equals(Status.Passive));
            return products;
        }

        public async Task<UpdateProductDto> GetUpdateProductDto(int id)
        {
            var product = await _productRepo.GetFilteredFirstOrDefault(select: x => _mapper.Map<UpdateProductDto>(x),
                                                              where: x => x.Id == id && !x.Status.Equals(Status.Passive));
            return product;
        }

        public async Task<List<ProductVm>> SearchProducts(string searchTerm = null, string color = null, decimal? minPrice = null, decimal? maxPrice = null, string CategoryName = null)
        {
            if (string.IsNullOrEmpty(CategoryName))
            {
                // Kategori adı belirtilmediyse, ürünleri filtrele
                var products = await _productRepo.GetFilteredList(select: x => _mapper.Map<ProductVm>(x),
                    where: x => (!x.Status.Equals(Status.Passive)) &&
                        (string.IsNullOrEmpty(searchTerm) || x.Name.Contains(searchTerm) || x.Description.Contains(searchTerm)) &&
                        (string.IsNullOrEmpty(color) || x.Color.Equals(color)) &&
                        (!minPrice.HasValue || x.Price >= minPrice) &&
                        (!maxPrice.HasValue || x.Price <= maxPrice));
                return products;
            }
            else
            {
                // Kategori adı belirtildiyse, kategoriye ait ürünleri filtrele
                var category = await _categoryService.GetCategoriesWithProducts();
                var model = category.FirstOrDefault(x => x.Name == CategoryName);

                if (model != null && model.Products.Count > 0)
                {
                    var products = await _productRepo.GetFilteredList(select: x => _mapper.Map<ProductVm>(x),
                    where: x => (!x.Status.Equals(Status.Passive)) &&
                        (string.IsNullOrEmpty(searchTerm) || x.Name.Contains(searchTerm) || x.Description.Contains(searchTerm)) &&
                        (string.IsNullOrEmpty(color) || x.Color.Equals(color)) &&
                        (!minPrice.HasValue || x.Price >= minPrice) &&
                        (!maxPrice.HasValue || x.Price <= maxPrice) &&
                        (x.Category.Name == CategoryName));                   
                    return products;
                }
                else
                {
                    return new List<ProductVm>(); // Kategoriye ait ürün bulunamadı
                }
            }
        }

        public async Task Update(UpdateProductDto model)
        {

            var product = _mapper.Map<Product>(model);

            if (product.UploadPath != null)
            {
                using var image = Image.Load(model.UploadPath.OpenReadStream());
                image.Mutate(x => x.Resize(600, 560));
                Guid guid = Guid.NewGuid();
                image.Save($"wwwroot/images/{guid}.jpg");
                product.ImagePath = $"/images/{guid}.jpg";

                await _productRepo.UpdateAsync(product);
            }
        }


    }
}
