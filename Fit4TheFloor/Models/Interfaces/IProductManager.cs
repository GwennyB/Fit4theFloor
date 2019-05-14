using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fit4TheFloor.Models.Interfaces
{
    interface IProductManager
    {
        Task<Product> GetProductAsync(int id);
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> CreateProductAsync(Product item);
        Task<Product> UpdateProductAsync(Product item);
        Task<bool> DeleteProductAsync(int id);

    }
}
