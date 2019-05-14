using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fit4TheFloor.Data;
using Fit4TheFloor.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fit4TheFloor.Models.Services
{
    public class CartMgmtSvc : ICartManager
    {
        private SalesDbContext _context { get; }

        public CartMgmtSvc(SalesDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Finds and returns specified user's open cart
        /// </summary>
        /// <param name="email"> email of cart owner </param>
        /// <returns> user's cart (or null if none exists) </returns>
        public async Task<Cart> GetCartAsync(string email)
        {
            return await _context.Carts.FirstOrDefaultAsync(c => c.BuyerEmail == email && c.Closed == null);
        }

        /// <summary>
        /// Returns an unsorted list of all carts in the Carts table
        /// </summary>
        /// <returns> list of all carts </returns>
        public async Task<List<Cart>> GetAllCartsAsync()
        {
            return await _context.Carts.ToListAsync<Cart>();
        }

        /// <summary>
        /// Creates a new cart if an open cart doesn't already exist for selected user
        /// </summary>
        /// <param name="item"> Cart object to add to Carts table </param>
        /// <returns> Cart object added to Carts table </returns>
        public async Task<Cart> CreateCartAsync(Cart item)
        {
            var query = await GetCartAsync(item.BuyerEmail);
            if (query != null)
            {
                return query;
            }
            await _context.Carts.AddAsync(item);
            await _context.SaveChangesAsync();
            return await GetCartAsync(item.BuyerEmail);
        }

        /// <summary>
        /// Updates an existing cart if it exists in the Carts table
        /// </summary>
        /// <param name="item"> Cart object to update </param>
        /// <returns> updated Cart object from Carts table </returns>
        public async Task<Cart> UpdateCartAsync(Cart item)
        {
            _context.Carts.Update(item);
            await _context.SaveChangesAsync();
            return await _context.Carts.FindAsync(item.ID);
        }

        /// <summary>
        /// Deletes an existing open cart if it exists in the Carts table
        /// </summary>
        /// <param name="email"> email of user whose open cart to delete </param>
        /// <returns> delete success status (boolean) </returns>
        public async Task<bool> DeleteCartAsync(string email)
        {
            var query = await GetCartAsync(email);
            if (query == null)
            {
                return false;
            }
            _context.Carts.Remove(query);
            await _context.SaveChangesAsync();
            query = await GetCartAsync(email);
            return (query == null);
        }
    }
}
