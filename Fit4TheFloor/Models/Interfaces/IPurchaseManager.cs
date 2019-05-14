using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fit4TheFloor.Models.Interfaces
{
    interface IPurchaseManager
    {
        Task<Purchase> GetPurchaseAsync(int id);
        Task<Purchase> GetPurchaseAsync(int cartID, int productID);
        Task<List<Purchase>> GetAllPurchasesByCartAsync(int cartID);
        Task<List<Purchase>> GetAllClosedPurchasesByProductAsync(int productID);
        Task<Purchase> CreatePurchaseAsync(Purchase item);
        Task<Purchase> UpdatePurchaseAsync(Purchase item);
        Task<bool> DeletePurchaseAsync(int id);
    }
}
