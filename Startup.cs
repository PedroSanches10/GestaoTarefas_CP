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
using GestaoTarefas_CP.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GestaoTarefas_CP.Models;

namespace GestaoTarefas_CP
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            // services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddDefaultUI();

            services.Configure<IdentityOptions>(
                options =>
                {
                    // Password settings
                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 8;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireLowercase = true;

                    // Lockout
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                    options.Lockout.MaxFailedAccessAttempts = 5;
                    options.Lockout.AllowedForNewUsers = true;

                    // Users
                    options.User.RequireUniqueEmail = true;

                    // Sign in
                    options.SignIn.RequireConfirmedAccount = false;
                }
            );

            services.AddAuthorization(
                options =>
                {
                    options.AddPolicy(
                        "CanManageGestaoTarefas_CP",
                        policy => policy.RequireRole("pedr", "cari")
                    );

                    // other policies ...
                }
            );

            services.AddControllersWithViews();

            services.AddRazorPages();
            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddDbContext<TarefasDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("TarefasDbContext")));
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, IWebHostEnvironment env,
            TarefasDbContext db,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager
        )
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

            SeedData.CreateRolesAsync(roleManager).Wait();

            //SeedData.Populate(db);

            if (env.IsDevelopment())
            {
                SeedData.Populate(db);
                SeedData.PopulateUsersAsync(userManager).Wait();
            }
            else
            {
                // Make sure that there is an  account
                // ...
            }
        }
    }
}

