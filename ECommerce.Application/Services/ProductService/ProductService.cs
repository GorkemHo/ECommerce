using AutoMapper;
using ECommerce.Application.Models.DTOs.ProductDTOs;
using ECommerce.Application.Models.VMs.CategoryVMs;
using ECommerce.Application.Models.VMs.ProductVMs;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using ECommerce.Domain.Repositories;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace ECommerce.Application.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
        private readonly ICategoryRepo _categoryRepo;
        private readonly IOrderRepo _orderRepo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepo productRepo, ICategoryRepo categoryRepo, IOrderRepo orderRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
            _orderRepo = orderRepo;
            _mapper = mapper;
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
                   select: x => new Category
                   {
                       Id = x.Id,
                       Name = x.Name
                   },
                   where: x => x.Status != Status.Passive),
                

            };

            return model;
        }

        public async Task<UpdateProductDto> GetById(int id)
        {
            var product = await _productRepo.GetFilteredFirstOrDefault(select: x => _mapper.Map<UpdateProductDto>(x),
                                                              where: x => x.Id == id && x.Status.Equals(Status.Active));
            return product;
        }

        public async Task<List<ProductVm>> GetProducts()
        {
            var products = await _productRepo.GetFilteredList(select: x => _mapper.Map<ProductVm>(x),
                                                     where: x => x.Status.Equals(Status.Active));
                                                     

            return products;
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
