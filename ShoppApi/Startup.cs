using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ShoppApi.Model;
using ShoppApi.Repositories;
using ShoppApi.Repositories.Cache;
using ShoppApi.Repositories.Contexts;
using ShoppApi.Repositories.Contracts;
using ShoppApi.Service;
using ShoppApi.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //  Redis
            services.AddSingleton<RedisConnection>();

            // Database
            services.AddDbContext<DatabaseContext>(options =>
                                                 options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            // Controllers
            services.AddControllers();

            // Services
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IProductService, ProductService>();
            
            // Repositories
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ISkuRepository, SkuRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shop API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
