using ECommerce.Domain.Entities;
using ECommerce.Domain.Repositories;
using ECommerce.Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories
{
    public class CartRepo : ICartRepo
    {

        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartRepo(AppDbContext db, IHttpContextAccessor httpContextAccessor,
            UserManager<AppUser> userManager)
        {
            _db = db;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<int> AddItem(int productId, int quantity)
        {
            string userId = GetUserId();
            using var transaction = _db.Database.BeginTransaction();
            try
            {
                if (string.IsNullOrEmpty(userId))
                    throw new Exception("user is not logged-in");
                var cart = await GetCart(userId);
                if (cart is null)
                {
                    cart = new Cart()
                    {
                        UserId = userId,
                        CreateDate = DateTime.Now
                    };

                    _db.Carts.Add(cart);
                }
                _db.SaveChanges();
                // cart detail section
                var cartItem = _db.CartItems
                                  .FirstOrDefault(a => a.ShoppingCartId == cart.Id && a.ProductId == productId);
                if (cartItem is not null)
                {
                    cartItem.Quantity += quantity;
                    //cart.UpdateDate = DateTime.Now;
                }
                else
                {
                    var product = _db.Products.Find(productId);
                    cartItem = new CartItem()
                    {
                        ProductId = productId,
                        ShoppingCartId = cart.Id,
                        Quantity = quantity,
                        UnitPrice = product.Price  // it is a new line after update
                    };

                    _db.CartItems.Add(cartItem);
                }
                _db.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
            }
            var cartItemCount = await GetCartItemCount(userId);
            return cartItemCount;
        }


        public async Task<int> RemoveItem(int productId)
        {
            //using var transaction = _db.Database.BeginTransaction();
            string userId = GetUserId();
            try
            {
                if (string.IsNullOrEmpty(userId))
                    throw new Exception("user is not logged-in");
                var cart = await GetCart(userId);
                if (cart is null)
                    throw new Exception("Invalid cart");
                // cart detail section
                var cartItem = _db.CartItems
                                  .FirstOrDefault(a => a.ShoppingCartId == cart.Id && a.ProductId == productId);
                if (cartItem is null)
                    throw new Exception("Not items in cart");
                else if (cartItem.Quantity == 1)
                    _db.CartItems.Remove(cartItem);
                else
                {
                    cartItem.Quantity = cartItem.Quantity - 1;
                    cart.UpdateDate = DateTime.Now;
                }
                _db.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            var cartItemCount = await GetCartItemCount(userId);
            return cartItemCount;
        }

       

        public async Task<Cart?> GetUserCart()
        {
            var userId = GetUserId();
            if (userId == null)
                throw new Exception("Invalid userid");

            var shoppingCart = await _db.Carts
                .Include(a => a.CartItems)
                .ThenInclude(a => a.Product)
                .ThenInclude(a => a.Category)
                .Where(a => a.UserId == userId)
                .FirstOrDefaultAsync();

            return shoppingCart;
        }



        public async Task<Cart> GetCart(string userId)
        {
            var cart = await _db.Carts.FirstOrDefaultAsync(x => x.UserId == userId);
            return cart;
        }

        public async Task<int> GetCartItemCount(string userId = "")
        {
            if (string.IsNullOrEmpty(userId)) // updated line
            {
                userId = GetUserId();
            }
            var data = await (from cart in _db.Carts
                              join cartDetail in _db.CartItems
                              on cart.Id equals cartDetail.Id
                              where cart.UserId == userId // updated line
                              select new { cartDetail.Id }
                        ).ToListAsync();
            return data.Count;
        }

        
        private string GetUserId()
        {
            var principal = _httpContextAccessor.HttpContext.User;
            string userId = _userManager.GetUserId(principal);
            return userId;
        }

        public async Task ClearCart()
        {
            var userId = GetUserId();
            if (userId == null)
                throw new Exception("Invalid userid");

            try
            {
                if (string.IsNullOrEmpty(userId))
                    throw new Exception("user is not logged-in");
                var cart = await GetCart(userId);
                if (cart is null)
                    throw new Exception("Invalid cart");

                if (cart.CartItems != null)
                    cart.CartItems.Clear();

                _db.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task CreateCart(string userId)
        {
            
            using var transaction = _db.Database.BeginTransaction();
            try
            {
                if (string.IsNullOrEmpty(userId))
                    throw new Exception("user is not logged-in");
                var cart = await GetCart(userId);
                if (cart is null)
                {
                    cart = new Cart()
                    {
                        UserId = userId,
                        CreateDate = DateTime.Now
                    };

                    _db.Carts.Add(cart);
                }
                _db.SaveChanges();
                
            }
            catch (Exception ex)
            {
            }
            
        }
    }
}
