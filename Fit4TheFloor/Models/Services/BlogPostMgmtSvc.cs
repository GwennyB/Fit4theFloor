using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fit4TheFloor.Data;
using Fit4TheFloor.Models.Interfaces;

namespace Fit4TheFloor.Models.Services
{
    public class BlogPostMgmtSvc : IBlogPostManager
    {
        private BlogPostDbContext _context { get; }

        public BlogPostMgmtSvc(BlogPostDbContext context)
        {
            _context = context;
        }

    }
}
