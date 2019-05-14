using System.Collections.Generic;
using System.Threading.Tasks;
using Fit4TheFloor.Data;
using Fit4TheFloor.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Fit4TheFloor.Models.Services
{
    public class BlogPostMgmtSvc : IBlogPostManager
    {
        private BlogPostDbContext _context { get; }

        public BlogPostMgmtSvc(BlogPostDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Finds and returns a BlogPost by ID
        /// </summary>
        /// <param name="id"> ID of BlogPost object to return </param>
        /// <returns> specified BlogPost (or null if none exists) </returns>
        public async Task<BlogPost> GetBlogPostAsync(int id)
        {
            return await _context.BlogPosts.FindAsync(id);
        }

        /// <summary>
        /// Returns an unsorted list of all BlogPost objects in the BlogPosts table
        /// </summary>
        /// <returns> list of all BlogPost objects </returns>
        public async Task<List<BlogPost>> GetAllBlogPostsAsync()
        {
            return await _context.BlogPosts.ToListAsync<BlogPost>();
        }

        /// <summary>
        /// Creates a new Product BlogPost if an identical object doesn't already exist in the BlogPosts table
        /// </summary>
        /// <param name="item"> BlogPost object to add to BlogPost table </param>
        /// <returns> BlogPost object added to BlogPosts table </returns>
        public async Task<BlogPost> CreateBlogPostAsync(BlogPost item)
        {
            var query = await _context.BlogPosts.FirstOrDefaultAsync(p => p.Category == item.Category && p.Date == item.Date && p.Images == item.Images && p.Videos == item.Videos && p.Discussion == item.Discussion);
            if (query == null)
            {
                await _context.BlogPosts.AddAsync(item);
                await _context.SaveChangesAsync();
            }
            return await _context.BlogPosts.FirstOrDefaultAsync(p => p.Category == item.Category && p.Date == item.Date && p.Images == item.Images && p.Videos == item.Videos && p.Discussion == item.Discussion);
        }

        /// <summary>
        /// Updates an existing BlogPost if it exists in the BlogPosts table
        /// </summary>
        /// <param name="item"> BlogPost object to update </param>
        /// <returns> updated BlogPost object from BlogPosts table </returns>
        public async Task<BlogPost> UpdateBlogPostAsync(BlogPost item)
        {
            _context.BlogPosts.Update(item);
            // TODO: If errors on Update, then see ProductMgmtSvc->UpdateProductAsync() for refactor

            await _context.SaveChangesAsync();
            return await _context.BlogPosts.FindAsync(item.ID);
        }

        /// <summary>
        /// Deletes an existing BlogPost if it exists in the BlogPost table
        /// </summary>
        /// <param name="id"> ID of BlogPost object to delete </param>
        /// <returns> delete success status (boolean) </returns>
        public async Task<bool> DeleteBlogPostAsync(int id)
        {
            var query = await _context.BlogPosts.FindAsync(id);
            if (query == null)
            {
                return false;
            }
            _context.BlogPosts.Remove(query);
            await _context.SaveChangesAsync();
            query = await _context.BlogPosts.FindAsync(id);
            return (query == null);
        }
    }
}
