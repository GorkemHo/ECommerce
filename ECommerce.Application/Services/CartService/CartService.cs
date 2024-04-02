using AutoMapper;
using ECommerce.Application.Models.VMs.CartVMs;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ICartService _cartService;

        public CartService(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task AddToCart(string userId, int productId, int quantity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFromCart(string userId, int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CartVM>> GetCartByUserId(string userId)
        {
            return await _cartService.GetCartByUserId(userId);
        }
    }
}
