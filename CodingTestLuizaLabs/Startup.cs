using CodingTestLuizaLabs.Business;
using CodingTestLuizaLabs.Business.Implementations;
using CodingTestLuizaLabs.Model;
using CodingTestLuizaLabs.Model.Context;
using CodingTestLuizaLabs.Repository.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodingTestLuizaLabs
{
    public class Startup

    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration["ConnectionStrings:SqlConnectionString"];
            services.AddDbContext<SqlContext>(options => options.UseSqlServer(connectionString));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IBusiness<Product>, GenericBusiness<Product>>();
            services.AddScoped<IBusiness<User>, GenericBusiness<User>>();

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
