using AutoMapper;
using ECommerce.Application.Models.VMs.CartVMs;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ICartRepo _cartRepo;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public CartService(ICartRepo cartRepo, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _cartRepo = cartRepo;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task AddProductFromCart(string userId, int productId)
        {
            var cart = await _cartRepo.GetDefault(c => c.UserId == userId);
            var cartItem = cart.CartItems.FirstOrDefault(item => item.ProductId == productId);
            cart.CartItems.Add(cartItem);

            await _cartRepo.UpdateAsync(cart);
        }

        public async Task AddToCart(string userId, int productId, int quantity)
        {
            var cartVmList = await GetCartByUserId(userId);

            if (cartVmList != null && cartVmList.Count > 0)
            {
                var cartVm = cartVmList[0];
                var cart = new Cart
                {
                    Id = cartVm.Id,
                    UserId = cartVm.UserId,
                    CartItems = cartVm.CartItems.Select(ci => new CartItem
                    {
                        Id = ci.Id,
                        ProductId = ci.ProductId,
                        Quantity = ci.Quantity,
                        CartId = ci.CartId
                    }).ToList()
                };

                var index = cart.CartItems.FindIndex(i => i.ProductId == productId);
                if (index < 0)
                {
                    cart.CartItems.Add(new CartItem()
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        CartId = cart.Id
                    });
                }
                else
                {
                    cart.CartItems[index].Quantity += quantity;
                }

                await _cartRepo.UpdateAsync(cart);
            }
        }

        public async Task CreateCart(string userId)
        {
            var existingCart = _cartRepo.GetDefault(u => u.UserId == userId);

            if (existingCart != null)
            {
                await _cartRepo.CreateAsync(new Cart() { UserId = userId });
            }
        }

        public async Task DeleteFromCart(string userId, int productId)
        {
            var cart = await _cartRepo.GetDefault(c => c.UserId == userId);

            var cartItem = cart.CartItems.Where(item => item.ProductId == productId).ToList();

            foreach (var item in cartItem)
            {
                cart.CartItems.Remove(item);
            }
            await _cartRepo.UpdateAsync(cart);
        }

        public async Task DeleteProductFromCart(string userId, int productId)
        {
            var cart = await _cartRepo.GetDefault(c => c.UserId == userId);
            var cartItem = cart.CartItems.FirstOrDefault(item => item.ProductId == productId);
            cart.CartItems.Remove(cartItem);

            await _cartRepo.UpdateAsync(cart);
        }

        public async Task<List<CartVM>> GetCartByUserId(string userId)
        {
            var cart = await _cartRepo.GetDefault(c => c.UserId == userId);

            return new List<CartVM>
            {
                new CartVM
                {   
                    CartItems = cart.CartItems
                }
            };
        }
    }
}
