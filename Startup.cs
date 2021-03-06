using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using SeniorProject.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SeniorProject.Services;
using Microsoft.Extensions.Options;

namespace SeniorProject
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
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<AppUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>();
            //services.AddDefaultIdentity<IdentityUser<int>>().AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Assistant", policy => 
                                 policy.RequireClaim("Role","Assistant"));

                options.AddPolicy("Trainee", policy =>
                                 policy.RequireClaim("Role", "Trainee"));

                options.AddPolicy("M2Student", policy =>
                                 policy.RequireClaim("Role", "M2Student"));

                options.AddPolicy("PhdStudent", policy =>
                                 policy.RequireClaim("Role", "PHDstudent"));

                options.AddPolicy("Admin", policy =>
                                 policy.RequireClaim("Role", "admin"));

                options.AddPolicy("PHD", policy =>
                                 policy.RequireClaim("Role", "PHD"));


            });
            services.AddRazorPages();
            
            services.AddHostedService<LabDayClosingHostedService>();
            services.AddHostedService<ItemHostedService>();
            services.AddIdentityCore<AppUser>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultUI().AddDefaultTokenProviders();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
