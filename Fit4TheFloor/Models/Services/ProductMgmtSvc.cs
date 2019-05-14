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

        public async Task<Product> GetProductAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync<Product>();
        }

        public async Task<Product> CreateProductAsync(Product item)
        {
            var query = await _context.Products.FirstOrDefaultAsync(p => p.Description == item.Description && p.ImageURL == item.ImageURL && p.Price == item.Price && p.Colors == item.Colors && p.Sizes == item.Sizes);
            if (query == null)
            {
                await _context.Products.AddAsync(item);
                await _context.SaveChangesAsync();
            }
            return await _context.Products.FirstOrDefaultAsync(p => p.Description == item.Description && p.ImageURL == item.ImageURL && p.Price == item.Price && p.Colors == item.Colors && p.Sizes == item.Sizes);
        }

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

        public async Task<bool> DeleteProductAsync(int id)
        {
            var query = await _context.Products.FindAsync(id);
            if (query == null)
            {
                return false;
            }
            _context.Products.Remove(query);
            await _context.SaveChangesAsync();
            query = await _context.Products.FindAsync(id);
            return (query == null);
        }
    }
}
