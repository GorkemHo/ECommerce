using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Repositories
{
    public interface ICartRepo 
    {
        Task<int> AddItem(int bookId, int qty);
        Task<int> RemoveItem(int bookId);
        Task<Cart> GetUserCart();
        Task<int> GetCartItemCount(string userId = "");
        Task<Cart> GetCart(string userId);
        //Task<bool> DoCheckout();
    }
}
