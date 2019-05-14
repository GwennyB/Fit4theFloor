using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fit4TheFloor.Data;
using Fit4TheFloor.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fit4TheFloor.Models.Services
{
    public class PrintMgmtSvc : IPrintManager
    {
        private SalesDbContext _context { get; }

        public PrintMgmtSvc(SalesDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Finds and returns a Print by ID
        /// </summary>
        /// <param name="id"> ID of Print object to return </param>
        /// <returns> specified Print (or null if none exists) </returns>
        public async Task<Print> GetPrintAsync(int id)
        {
            return await _context.Prints.FindAsync(id);
        }

        /// <summary>
        /// Returns an unsorted list of all (Active) Print objects in the Prints table
        /// </summary>
        /// <returns> list of all (Active) Print objects </returns>
        public async Task<List<Print>> GetAllPrintsAsync()
        {
            return await _context.Prints.Where(p => p.Active == true).ToListAsync<Print>();
        }

        /// <summary>
        /// Creates a new Print object if an identical object doesn't already exist in the Prints table
        /// </summary>
        /// <param name="item"> Print object to add to Prints table </param>
        /// <returns> Print object added to Prints table </returns>
        public async Task<Print> CreatePrintAsync(Print item)
        {
            var query = await _context.Prints.FirstOrDefaultAsync(p => p.Description == item.Description && p.ImageURL == item.ImageURL && p.Active == true);
            if (query == null)
            {
                await _context.Prints.AddAsync(item);
                await _context.SaveChangesAsync();
            }
            return await _context.Prints.FirstOrDefaultAsync(p => p.Description == item.Description && p.ImageURL == item.ImageURL && p.Active == true);
        }

        /// <summary>
        /// Updates an existing Print if it exists in the Prints table
        /// </summary>
        /// <param name="item"> Print object to update </param>
        /// <returns> updated Print object from Prints table </returns>
        public async Task<Print> UpdatePrintAsync(Print item)
        {
            _context.Prints.Update(item);
            // TODO: If errors on Update, then see ProductMgmtSvc->UpdateProductAsync() for refactor

            await _context.SaveChangesAsync();
            return await _context.Prints.FindAsync(item.ID);
        }

        /// <summary>
        /// Toggles the 'Active' property of an existing Print if it exists in the Prints table
        /// NOTE: Does not actually 'delete' Print items because closed carts (ie - sales history) may reference those Print objects.
        /// </summary>
        /// <param name="id"> ID of Print object to deactivate </param>
        /// <returns> deactivate success status (boolean) </returns>
        public async Task<bool> DeletePrintAsync(int id)
        {
            var query = await _context.Prints.FindAsync(id);
            if (query == null)
            {
                return false;
            }

            query.Active = false;
            _context.Prints.Update(query);
            await _context.SaveChangesAsync();
            query = await _context.Prints.FindAsync(id);
            return (query.Active == false);
        }
    }
}
