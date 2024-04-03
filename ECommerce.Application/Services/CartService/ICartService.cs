using ECommerce.Application.Models.VMs.CartVMs;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.CartService
{
    public interface ICartService
    {
        Task CreateCart(string userId);
        Task<List<CartVM>> GetCartByUserId(string userId);
        Task AddToCart(string userId, int productId, int quantity);
        Task DeleteFromCart(string userId, int productId);
        Task DeleteProductFromCart(string userId, int productId);
        Task AddProductFromCart(string userId, int productId);
    }
}
