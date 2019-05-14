using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fit4TheFloor.Models.Interfaces
{
    public interface IBlogPostManager
    {
        Task<BlogPost> GetBlogPostAsync(int id);
        Task<List<BlogPost>> GetAllBlogPostsAsync();
        Task<BlogPost> CreateBlogPostAsync(BlogPost item);
        Task<BlogPost> UpdateBlogPostAsync(BlogPost item);
        Task<bool> DeleteBlogPostAsync(int id);
    }
}
