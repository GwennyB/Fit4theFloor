using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fit4TheFloor.Data;
using Fit4TheFloor.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fit4TheFloor.Models.Services
{
    public class WeighInMgmtSvc : IWeighInManager
    {
        private StatsDbContext _context { get; }

        public WeighInMgmtSvc(StatsDbContext context)
        {
            _context = context;
        }



        /// <summary>
        /// Finds and returns a WeighIn by ID
        /// </summary>
        /// <param name="id"> ID of WeighIn object to return </param>
        /// <returns> specified WeighIn (or null if none exists) </returns>
        public async Task<WeighIn> GetWeighInAsync(int id)
        {
            return await _context.WeighIns.FindAsync(id);
        }

        /// <summary>
        /// Returns an unsorted list of all WeighIn objects in the WeighIns table
        /// </summary>
        /// <returns> list of all WeighIn objects </returns>
        public async Task<List<WeighIn>> GetAllWeighInsAsync()
        {
            return await _context.WeighIns.ToListAsync<WeighIn>();
        }

        /// <summary>
        /// Returns an unsorted list of all WeighIn objects for specified user in the WeighIns table
        /// </summary>
        /// <returns> list of all specified user's WeighIn objects </returns>
        public async Task<List<WeighIn>> GetAllWeighInsAsync(string email)
        {
            return await _context.WeighIns.Where(w => w.UserEmail == email).ToListAsync<WeighIn>();
        }

        /// <summary>
        /// Creates a new Product WeighIn if a WeighIn object for same user and date doesn't already exist in the WeighIns table
        /// </summary>
        /// <param name="item"> WeighIn object to add to WeighIn table </param>
        /// <returns> WeighIn object added to WeighIns table </returns>
        public async Task<WeighIn> CreateWeighInAsync(WeighIn item)
        {
            var query = await _context.WeighIns.FirstOrDefaultAsync(w => w.UserEmail == item.UserEmail && w.Date == item.Date);
            if (query == null)
            {
                await _context.WeighIns.AddAsync(item);
                await _context.SaveChangesAsync();
            }
            return await _context.WeighIns.FirstOrDefaultAsync(w => w.UserEmail == item.UserEmail && w.Date == item.Date);
        }

        /// <summary>
        /// Updates an existing WeighIn if it exists in the WeighIns table
        /// </summary>
        /// <param name="item"> WeighIn object to update </param>
        /// <returns> updated WeighIn object from WeighIns table </returns>
        public async Task<WeighIn> UpdateWeighInAsync(WeighIn item)
        {
            _context.WeighIns.Update(item);
            // TODO: If errors on Update, then see ProductMgmtSvc->UpdateProductAsync() for refactor

            await _context.SaveChangesAsync();
            return await _context.WeighIns.FindAsync(item.ID);
        }

        /// <summary>
        /// Deletes an existing WeighIn if it exists in the WeighIn table
        /// </summary>
        /// <param name="id"> ID of WeighIn object to delete </param>
        /// <returns> delete success status (boolean) </returns>
        public async Task<bool> DeleteWeighInAsync(int id)
        {
            var query = await _context.WeighIns.FindAsync(id);
            if (query == null)
            {
                return false;
            }
            _context.WeighIns.Remove(query);
            await _context.SaveChangesAsync();
            query = await _context.WeighIns.FindAsync(id);
            return (query == null);
        }
    }
}
