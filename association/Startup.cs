using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using association.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using association.Models;
using association.Services;
using association.Models.asso_config;
using System.Globalization;

namespace association
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
                services.Configure<CookiePolicyOptions>(options =>
                {
                    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });


                services.AddDbContext<MyDbContext>(options =>
                    options.UseSqlServer(
                        Configuration.GetConnectionString("DefaultConnection")));

                services.AddIdentity<ApplicationUser, IdentityRole>()
                  .AddEntityFrameworkStores<MyDbContext>()
                  .AddDefaultTokenProviders();

            services.AddDbContext<MyDbContext>();

            services.AddMvc().AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizePage("/test1", "OnlyAdminAccess");


                }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

                services.AddAuthorization(options =>
                {
                    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
                });

            // Add application services.
            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            services.Configure<SecurityStampValidatorOptions>(options =>
    options.ValidationInterval = TimeSpan.FromSeconds(10));

            services.AddAuthentication()
                .Services.ConfigureApplicationCookie(options =>
                {
                    options.SlidingExpiration = true;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                });
            //services.Configure<IISOptions>(options =>
            //{
            //    options.AutomaticAuthentication = false;
            //});
            //services.Configure<IISOptions>(options =>
            //{
            //    options.ForwardClientCertificate = false;
            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseDatabaseErrorPage();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                    app.UseHsts();
                }

                app.UseHttpsRedirection();
                app.UseStaticFiles();
                app.UseCookiePolicy();

                app.UseAuthentication();
                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });
            var cultureInfo = new CultureInfo("fr-FR");
            cultureInfo.NumberFormat.CurrencySymbol = "€";

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;


            CreateRoles(serviceProvider).Wait();
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
            {
            //association 
            // Association association = await Association.FindByEmaic("jignesh@gmail.com");
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();


            //initializing custom roles 
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Admin", "User", "HR" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    //create the roles and seed them to the database: Question 1
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            ApplicationUser user1 = await UserManager.FindByEmailAsync("ismailelaissaoui@gmail.com");

            if (user1 == null)
            {
                user1 = new ApplicationUser()
                {
                    UserName = "ismailelaissaoui@gmail.com",
                    Email = "ismailelaissaoui@gmail.com",
                };
                await UserManager.CreateAsync(user1, "Ismail@10");
            }
            await UserManager.AddToRoleAsync(user1, "Admin");


            //ApplicationUser user = await UserManager.FindByEmailAsync("jignesh@gmail.com");

            //    if (user == null)
            //    {
            //        user = new ApplicationUser()
            //        {
            //            UserName = "jignesh@gmail.com",
            //            Email = "jignesh@gmail.com",
            //        };
            //        await UserManager.CreateAsync(user, "Test@123");
            //    }
            //    await UserManager.AddToRoleAsync(user, "Admin");


            //ApplicationUser user1 = await UserManager.FindByEmailAsync("tejas@gmail.com");

            //    if (user1 == null)
            //    {
            //        user1 = new ApplicationUser()
            //        {
            //            UserName = "tejas@gmail.com",
            //            Email = "tejas@gmail.com",
            //        };
            //        await UserManager.CreateAsync(user1, "Test@123");
            //    }
            //    await UserManager.AddToRoleAsync(user1, "User");

            //ApplicationUser user2 = await UserManager.FindByEmailAsync("rakesh@gmail.com");

            //    if (user2 == null)
            //    {
            //        user2 = new ApplicationUser()
            //        {
            //            UserName = "rakesh@gmail.com",
            //            Email = "rakesh@gmail.com",
            //        };
            //        await UserManager.CreateAsync(user2, "Test@123");
            //    }
            //    await UserManager.AddToRoleAsync(user2, "HR");

        }
    }
    }
