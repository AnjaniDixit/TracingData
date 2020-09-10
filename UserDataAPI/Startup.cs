using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UserDataAPI.Models;

namespace UserDataAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //----Reading from Environment variables-----
            /*
            var server = Configuration["DBServer"] ?? "172.26.16.1";
            var port = Configuration["DBPort"] ?? "1401";
            var user = Configuration["User"] ?? "sa";
            var password = Configuration["Password"] ?? "Sample123";
            var database = Configuration["Database"] ?? "User";

            services.AddDbContext<UserDBContext>(options =>
            {
                options.UseSqlServer($"Server={server},{port};Initial Catalog={database}; User ID={user};Password={password}");
            });
            */

            //----Reading from appsettings-------

            var connection = Configuration.GetConnectionString("UserData");
            services.AddDbContext<UserDBContext>(options => options.UseSqlServer(connection));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
