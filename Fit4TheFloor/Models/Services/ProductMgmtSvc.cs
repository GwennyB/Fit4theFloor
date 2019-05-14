using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fit4TheFloor.Data;
using Fit4TheFloor.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fit4TheFloor.Models.Services
{
    public class ProductMgmtSvc : IProductManager
    {
        private SalesDbContext _context { get; }

        public ProductMgmtSvc(SalesDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Finds and returns a Product by ID
        /// </summary>
        /// <param name="id"> ID of Product object to return </param>
        /// <returns> specified Product (or null if none exists) </returns>
        public async Task<Product> GetProductAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        /// <summary>
        /// Returns an unsorted list of all (Active) Product objects in the Products table
        /// </summary>
        /// <returns> list of all (Active) Product objects </returns>
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.Where(p => p.Active == true).ToListAsync<Product>();
        }

        /// <summary>
        /// Creates a new Product object if an identical object doesn't already exist in the Products table
        /// </summary>
        /// <param name="item"> Product object to add to Products table </param>
        /// <returns> Product object added to Products table </returns>
        public async Task<Product> CreateProductAsync(Product item)
        {
            var query = await _context.Products.FirstOrDefaultAsync(p => p.Description == item.Description && p.ImageURL == item.ImageURL && p.Price == item.Price && p.Colors == item.Colors && p.Sizes == item.Sizes && p.Active == true);
            if (query == null)
            {
                await _context.Products.AddAsync(item);
                await _context.SaveChangesAsync();
            }
            return await _context.Products.FirstOrDefaultAsync(p => p.Description == item.Description && p.ImageURL == item.ImageURL && p.Price == item.Price && p.Colors == item.Colors && p.Sizes == item.Sizes);
        }

        /// <summary>
        /// Updates an existing Product if it exists in the Products table
        /// </summary>
        /// <param name="item"> Product object to update </param>
        /// <returns> updated Product object from Products table </returns>
        public async Task<Product> UpdateProductAsync(Product item)
        {
            _context.Products.Update(item);
            // TODO: If errors on Update, then replace above line with below code to resolve
            //int id = item.ID;
            //item.ID = -1;
            //var query = await _context.Products.FindAsync(id);
            //if (query == null)
            //{
            //    return await CreateProductAsync(item);
            //}
            //query.Description = item.Description;
            //query.Price = item.Price;
            //query.ImageURL = item.ImageURL;
            //query.Colors = item.Colors;
            //query.Sizes = item.Sizes;
            //_context.Products.Update(query);

            await _context.SaveChangesAsync();
            return await _context.Products.FindAsync(item.ID);
        }

        /// <summary>
        /// Toggles the 'Active' property of an existing Product if it exists in the Products table
        /// NOTE: Does not actually 'delete' Product items because closed carts (ie - sales history) may reference those Product objects.
        /// </summary>
        /// <param name="id"> ID of Product object to deactivate </param>
        /// <returns> deactivate success status (boolean) </returns>
        public async Task<bool> DeleteProductAsync(int id)
        {
            var query = await _context.Products.FindAsync(id);
            if (query == null)
            {
                return false;
            }

            query.Active = false;
            _context.Products.Update(query);
            await _context.SaveChangesAsync();
            query = await _context.Products.FindAsync(id);
            return (query.Active == false);
        }
    }
}
