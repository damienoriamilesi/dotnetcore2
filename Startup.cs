using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreapp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace coreapp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IConfiguration _config { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<StoreUser,IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
                //cfg.Password.RequireUppercase = true;
            })
            // Could have stored security user data in another context
            .AddEntityFrameworkStores<DutchContext>();

            //=> Scan assemblies to inject
            services.AddDbContext<DutchContext>(cfg =>{
                cfg.UseSqlServer(_config.GetConnectionString("DutchConnectionString"));
            });
            /*
                - Don't forget to add connectionstring in config.json file
                - Don't forget to add ctor with DbContextOptions and derive from base(options)            
             */

            services.AddTransient<DutchSeeder>();
            //services.AddScoped<IRepository<Product>,Repository<Product>>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // // Little web server
            // app.Run(async(ctx)=>{
            //     await ctx.Response.WriteAsync("Hello World");
            // });
            
            // UseStaticFiles => By default, files are served from wwwroot folder
            // UseDefaultFiles => Search for default files like index.html
            //==> Order Matters !!!!

            app.UseDeveloperExceptionPage();
            // if (env.IsDevelopment())
            // {
            //     app.UseDeveloperExceptionPage();
            // }
            // else
            //     app.UseExceptionHandler("/error");


            //app.UseDefaultFiles();
            app.UseStaticFiles();
            
            // ////////////////////////////////////////////////////////
            // =======>>>>>>> IMPORTANT : Have to be BEFORE UseMvc
            // ////////////////////////////////////////////////////////
            app.UseAuthentication();
            // ////////////////////////////////////////////////////////
            app.UseMvc(
                cfg => {
                    cfg.MapRoute("Default",
                    "{controller}/{action}/{id?}",
                    new{controller = "App", action="Index"});
                }
            );

            if(env.IsDevelopment())
            {
                // Configure Method isn't in a scope...we have to create the scope before seeding
                // Lifetime of seeder is limited to this piece of code
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    // Get a scope to include DutchContext
                    // Create an instance of seeder and needed services
                    var seeder = scope.ServiceProvider.GetService<DutchSeeder>();
                    seeder.Seed();
                }
            }
        } 
    }
}
