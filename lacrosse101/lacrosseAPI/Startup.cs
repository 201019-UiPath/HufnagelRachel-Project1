using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lacrosseDB;
using lacrosseDB.Repos;
using lacrosseLib;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace lacrosseAPI
{
    public class Startup
    {

        readonly string MyAllowSpecifOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecifOrigins,
                    builder =>
                    {
                        builder.WithOrigins("*")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

            services.AddControllers();
            services.AddDbContext<lacrosseContext>(options => options.UseNpgsql(Configuration.GetConnectionString("lacrosseDB")));
            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<IProductRepo, DBRepo>();
            services.AddScoped<ILocationServices, LocationServices>();
            services.AddScoped<ILocationRepo, DBRepo>();
            services.AddScoped<ICustomerServices, CustomerServices>();
            services.AddScoped<ICustomerRepo, DBRepo>();
            services.AddScoped<IManagerServices, ManagerServices>();
            services.AddScoped<IManagerRepo, DBRepo>();
            services.AddScoped<ICartItemServices, CartItemServices>();
            services.AddScoped<ICartItemsRepo, DBRepo>();
            services.AddScoped<ICartServices, CartServices>();
            services.AddScoped<ICartRepo, DBRepo>();
            services.AddScoped<IlineItemServices, lineItemServices>();
            services.AddScoped<ILineItemRepo, DBRepo>();
            services.AddScoped<IOrderServices, OrderServices>();
            services.AddScoped<IOrderRepo, DBRepo>();
            services.AddScoped<IInventoryServices, InventoryServices>();
            services.AddScoped<IInventoryRepo, DBRepo>();


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

            app.UseCors(MyAllowSpecifOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
