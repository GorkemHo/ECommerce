using ECommerce.Application.Models.DTOs.ProductDTOs;
using ECommerce.Application.Models.VMs.ProductVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.ProductService
{
    public interface IProductService
    {
        Task Create(CreateProductDto model);
        Task Update(UpdateProductDto model);
        Task Delete(int id);
        Task<List<ProductVm>> GetProducts();
        Task<ProductVm> GetById(int id);
        Task<CreateProductDto> FillProduct();
    }
}
