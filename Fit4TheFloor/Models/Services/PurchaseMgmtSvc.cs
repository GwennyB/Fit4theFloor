using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fit4TheFloor.Data;
using Fit4TheFloor.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fit4TheFloor.Models.Services
{
    public class PurchaseMgmtSvc : IPurchaseManager
    {
        private SalesDbContext _context { get; }

        public PurchaseMgmtSvc(SalesDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Finds and returns a Purchase by ID
        /// </summary>
        /// <param name="id"> ID of Purchase object to return </param>
        /// <returns> specified Purchase (or null if none exists) </returns>
        public async Task<Purchase> GetPurchaseAsync(int id)
        {
            return await _context.Purchases.FindAsync(id);
        }

        /// <summary>
        /// Finds and returns a Purchase by CartID and ProductID
        /// </summary>
        /// <param name="cartID"> ID of Cart associated with Purchase object to return </param>
        /// <param name="productID"> ID of Product associated with Purchase object to return </param>
        /// <returns> specified Purchase (or null if none exists) </returns>
        public async Task<Purchase> GetPurchaseAsync(int cartID, int productID)
        {
            return await _context.Purchases.FirstOrDefaultAsync(p => p.CartID == cartID && p.ProductID == productID);
        }

        /// <summary>
        /// Returns an unsorted list of all Purchase objects associated with the specified Cart
        /// </summary>
        /// <param name="cartID"> ID of Cart to search for Purchase objects </param>
        /// <returns> list of all Purchase objects in specified Cart </returns>
        public async Task<List<Purchase>> GetAllPurchasesByCartAsync(int cartID)
        {
            return await _context.Purchases.Where(p => p.CartID == cartID).ToListAsync<Purchase>();
        }

        /// <summary>
        /// Returns an unsorted list of all Purchase objects associated with the specified Cart
        /// </summary>
        /// <param name="productID"> ID of Product to search for Purchase objects </param>
        /// <returns> list of all Purchase objects in specified Cart </returns>
        public async Task<List<Purchase>> GetAllClosedPurchasesByProductAsync(int productID)
        {
            return await _context.Purchases.Where(p => p.ProductID == productID && p.Closed != null).ToListAsync<Purchase>();
        }

        /// <summary>
        /// Creates a new Purchase object if an identical object doesn't already exist in the Purchases table
        /// If object exists, increments its Qty property
        /// </summary>
        /// <param name="item"> Purchase object to add to Purchases table </param>
        /// <returns> Purchase object added to Purchases table (or updated Qty) </returns>
        public async Task<Purchase> CreatePurchaseAsync(Purchase item)
        {
            var query = await _context.Purchases.FirstOrDefaultAsync(p => p.CartID == item.CartID && p.ProductID == item.ProductID && p.Size == item.Size && p.Color == item.Color && p.PrintID == item.PrintID && p.PrintColor == item.PrintColor);
            if (query == null)
            {
                await _context.Purchases.AddAsync(item);
                await _context.SaveChangesAsync();
            }
            // if identical Purchase object exists, add to quantity
            query.Qty++;
            return await UpdatePurchaseAsync(query);
        }

        /// <summary>
        /// Updates an existing Purchase if it exists in the Purchases table
        /// </summary>
        /// <param name="item"> Purchase object to update </param>
        /// <returns> updated Purchase object from Purchases table </returns>
        public async Task<Purchase> UpdatePurchaseAsync(Purchase item)
        {
            _context.Purchases.Update(item);
            // TODO: If errors on Update, then see ProductMgmtSvc->UpdateProductAsync() for refactor

            await _context.SaveChangesAsync();
            return await _context.Purchases.FindAsync(item.ID);
        }

        /// <summary>
        /// Deletes specified Purchase object if it exists and isn't 'Closed'
        /// NOTE: 'Closed' represents a completed purchase. Retain record.
        /// </summary>
        /// <param name="id"> ID of Purchase object to deactivate </param>
        /// <returns> delete success status (boolean) </returns>
        public async Task<bool> DeletePurchaseAsync(int id)
        {
            var query = await _context.Purchases.FindAsync(id);
            if (query == null || query.Closed != null)
            {
                return false;
            }

            _context.Purchases.Remove(query);
            await _context.SaveChangesAsync();
            query = await _context.Purchases.FindAsync(id);
            return (query == null);
        }
    }
}

