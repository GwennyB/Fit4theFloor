using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Fit4TheFloor.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fit4TheFloor.Models
{
    public class RoleInitializer
    {
        private static readonly List<IdentityRole> Roles = new List<IdentityRole>()
        {
            new IdentityRole{Name = AppRoles.Customer, NormalizedName = AppRoles.Customer.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString()},
            new IdentityRole{Name = AppRoles.Admin, NormalizedName = AppRoles.Admin.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString()}
        };

        public static void SeedData(IServiceProvider servProv)
        {
            using (var dbContext = new AppUserDbContext(servProv.GetRequiredService<DbContextOptions<AppUserDbContext>>()))
            {
                dbContext.Database.EnsureCreated();
                AddRoles(dbContext);
            }
        }

        private static void AddRoles(AppUserDbContext context)
        {
            if (context.Roles.Any()) return;

            foreach (var role in Roles)
            {
                context.Roles.Add(role);
                context.SaveChanges();
            }
        }
    }
}



