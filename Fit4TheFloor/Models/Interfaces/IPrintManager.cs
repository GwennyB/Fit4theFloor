using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fit4TheFloor.Models.Interfaces
{
    public interface IPrintManager
    {
        Task<Print> GetPrintAsync(int id);
        Task<List<Print>> GetAllPrintsAsync();
        Task<Print> CreatePrintAsync(Print item);
        Task<Print> UpdatePrintAsync(Print item);
        Task<bool> DeletePrintAsync(int id);
    }
}
