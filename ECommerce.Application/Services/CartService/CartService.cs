using AutoMapper;
using ECommerce.Application.Models.VMs.CartVMs;
using ECommerce.Application.Models.VMs.ProductVMs;
using ECommerce.Application.Services.ProductService;
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
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly ICartItemRepo _cartItemRepo;


        public CartService(ICartRepo cartRepo, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IProductService productService, IMapper mapper, ICartItemRepo cartItemRepo)
        {
            _cartRepo = cartRepo;
            _signInManager = signInManager;
            _userManager = userManager;
            _productService = productService;
            _mapper = mapper;
            _cartItemRepo = cartItemRepo;
        }

        public async Task<Cart> GetCart(string userId)
        {
            var existingCart = await _cartRepo.GetDefault(u => u.UserId == userId);

            if (existingCart == null)
            {
                existingCart = new Cart { UserId = userId };
                await _cartRepo.CreateAsync(existingCart);
            }
            return existingCart;
        }


        public async Task AddToCart(string userId, CartItemVm cartItem)
        {
            var cart = await GetCart(userId);

            if (cartItem != null)
            {
               
                    // Kontrol edilecek ürünün daha önce sepete eklenip eklenmediğini bul
                    var existingCartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == cartItem.ProductId);

                    if (existingCartItem != null)
                    {
                        // Eğer aynı ürün daha önce eklenmişse quantity'yi artır
                        existingCartItem.Quantity += cartItem.Quantity;
                    }
                    else
                    {
                        // Eğer ürün daha önce eklenmemişse, sepete yeni ürün olarak ekle
                        cart.CartItems.Add(_mapper.Map<CartItem>(cartItem));
                    }
                _cartItemRepo.UpdateAsync(_mapper.Map<CartItem>(cartItem));  

                await _cartRepo.UpdateAsync(cart);
            }
        }        

        public async Task DeleteFromCart(string userId, CartItemVm cartItem)
        {
            var cart = await GetCart(userId);

            var existingCartItem = cart.CartItems.FirstOrDefault(ci => ci.Id == cartItem.Id);

            if (existingCartItem != null)
            {
                cart.CartItems.Remove(existingCartItem);
                await _cartRepo.UpdateAsync(cart);
            }
            else
            {
                // Hata durumu: Sepette böyle bir ürün bulunamadı
                throw new Exception("Bu ürün sepetinizde bulunamadı.");
            }

        }

        public async Task ClearToCart(string userId)
        {
            var cart = await GetCart(userId);
            cart.CartItems.Clear();
            await _cartRepo.UpdateAsync(cart);
        }

        public async Task<CartItemVm> CreateCartItem(int productId, int Quantity)
        {
            var ProductVm = await _productService.GetById(productId);              

            var cartItemVM = new CartItemVm
            {
                ProductId = ProductVm.Id,
                Quantity = Quantity,
                Price = ProductVm.Price,
                ProductName = ProductVm.Name,
                Product = ProductVm,
            };
            return cartItemVM;
        }

        public async Task<List<CartItemVm>> GetCartItemsByUserId(string userId)
        {
            var cart = await GetCart(userId);

            var cartItemsVm = cart.CartItems.Select(ci => new CartItemVm
            {
                Id = ci.Id,
                ProductId = ci.ProductId,
                Quantity = ci.Quantity,
                Price = ci.Price,
                ProductName = ci.Product?.Name, // Varsayılan olarak ProductName'i kullanılabilir.
                                                // İsterseniz ProductVm kullanarak diğer özellikleri de alabilirsiniz.
            }).ToList();

            return cartItemsVm;
        }

    }
}
