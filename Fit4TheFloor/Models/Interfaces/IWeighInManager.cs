using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fit4TheFloor.Models.Interfaces
{
    public interface IWeighInManager
    {
        Task<WeighIn> GetWeighInAsync(int id);
        Task<List<WeighIn>> GetAllWeighInsAsync();
        Task<List<WeighIn>> GetAllWeighInsAsync(string email);
        Task<WeighIn> CreateWeighInAsync(WeighIn item);
        Task<WeighIn> UpdateWeighInAsync(WeighIn item);
        Task<bool> DeleteWeighInAsync(int id);
    }
}
