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

        public async Task<BlogPost> GetBlogPostAsync(int id)
        {
            return await _context.BlogPosts.FindAsync(id);
        }

        public async Task<List<BlogPost>> GetAllBlogPostsAsync()
        {
            return await _context.BlogPosts.ToListAsync<BlogPost>();
        }

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

        public async Task<BlogPost> UpdateBlogPostAsync(BlogPost item)
        {
            _context.BlogPosts.Update(item);
            // TODO: If errors on Update, then see ProductMgmtSvc->UpdateProductAsync() for refactor

            await _context.SaveChangesAsync();
            return await _context.BlogPosts.FindAsync(item.ID);
        }

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
