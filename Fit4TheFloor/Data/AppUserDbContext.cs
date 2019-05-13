using Fit4TheFloor.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fit4TheFloor.Data
{
    // This class reflects the database context for the 'AppUser' database. It is derived from the Microsoft Identity library for authentication, and build relies on Entity Framework Core (ORM).
    public class AppUserDbContext : IdentityDbContext<AppUser>
    {
        public AppUserDbContext(DbContextOptions<AppUserDbContext> options) : base(options)
        {

        }



    }
}
