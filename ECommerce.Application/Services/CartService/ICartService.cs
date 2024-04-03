using ECommerce.Application.Models.VMs.CartVMs;
using ECommerce.Application.Models.VMs.ProductVMs;
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
        Task<Cart> GetCart(string userId);
        Task AddToCart(string userId, List<CartItemVm> cartItems);
        Task ClearToCart(string userId);
        Task<CartItemVm> CreateCartItem(ProductVm productVm, int Quantity);
        Task DeleteFromCart(string userId, CartItemVm cartItem);
        Task<List<CartItemVm>> GetCartItemsByUserId(string userId);
    }
}
