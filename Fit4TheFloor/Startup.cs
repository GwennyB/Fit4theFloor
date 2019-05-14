using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fit4TheFloor.Data;
using Fit4TheFloor.Models;
using Fit4TheFloor.Models.Interfaces;
using Fit4TheFloor.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fit4TheFloor
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppUserDbContext>()
                .AddDefaultTokenProviders();

            // TODO: On deploy to AWS, switch from local connection strings to AWS secrets
            services.AddDbContext<AppUserDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("FitUserLocal")));

            services.AddDbContext<SalesDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("FitSalesLocal")));

            services.AddDbContext<StatsDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("FitStatsLocal")));

            services.AddDbContext<BlogPostDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("FitPostsLocal")));


            //services.AddDbContext<AppUserDbContext>(options =>
            //    options.UseSqlServer($"Data Source={Configuration["RDS_HOSTNAME_USER"]};Initial Catalog={Configuration["RDS_DBNAME_USER"]};User ID={Configuration["RDS_USERNAME_USER"]};Password={Configuration["RDS_PASSWORD_USER"]}"));

            //services.AddDbContext<SalesDbContext>(options =>
            //    options.UseSqlServer($"Data Source={Configuration["RDS_HOSTNAME_CONTENT"]};Initial Catalog={Configuration["RDS_DBNAME_SALES"]};User ID={Configuration["RDS_USERNAME_CONTENT"]};Password={Configuration["RDS_PASSWORD_CONTENT"]}"));

            //services.AddDbContext<StatsDbContext>(options =>
            //    options.UseSqlServer($"Data Source={Configuration["RDS_HOSTNAME_CONTENT"]};Initial Catalog={Configuration["RDS_DBNAME_STATS"]};User ID={Configuration["RDS_USERNAME_CONTENT"]};Password={Configuration["RDS_PASSWORD_CONTENT"]}"));

            //services.AddDbContext<StatsDbContext>(options =>
            //    options.UseSqlServer($"Data Source={Configuration["RDS_HOSTNAME_CONTENT"]};Initial Catalog={Configuration["RDS_DBNAME_POSTS"]};User ID={Configuration["RDS_USERNAME_CONTENT"]};Password={Configuration["RDS_PASSWORD_CONTENT"]}"));


            services.AddMvc();

            services.AddScoped<IAppUserManager, AppUserMgmtSvc>();
            services.AddScoped<IBlogPostManager, BlogPostMgmtSvc>();
            services.AddScoped<ICartManager, CartMgmtSvc>();
            services.AddScoped<IPrintManager, PrintMgmtSvc>();
            services.AddScoped<IProductManager, ProductMgmtSvc>();
            services.AddScoped<IPurchaseManager, PurchaseMgmtSvc>();
            services.AddScoped<IWeighInManager, WeighInMgmtSvc>();

        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseStatusCodePagesWithReExecute("/error/{0}");

            app.UseMvc(route =>
            {
                route.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }


    }
}
