using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fit4TheFloor.Models.Interfaces
{
    interface ICartManager
    {
        Task<Cart> GetCartAsync(string email);
        Task<List<Cart>> GetAllCartsAsync();
        Task<Cart> CreateCartAsync(Cart item);
        Task<Cart> UpdateCartAsync(Cart item);
        Task<bool> DeleteCartAsync(string email);
    }
}
