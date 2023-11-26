using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using WebApplication1.Repositories;
using MySqlConnector;
using System.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace DapperMariaDBDemo
{
    
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices((hostContext, services) =>
                    {
                        // Add services to the container.
                        services.AddControllersWithViews();

                        // Configure the database connection.
                        var configuration = hostContext.Configuration;
                        var connectionString = configuration.GetConnectionString("DefaultConnection");
                        services.AddScoped<IDbConnection>(_ => new MySqlConnection(connectionString));

                        // Register your repository here.
                        services.AddTransient<KundeTableRepository>();
                        services.AddTransient<BrukerTableRepository>();
                        services.AddTransient<ServiceTableRepository>();
                        services.AddTransient<ServiceFormTableRepository>();
                        services.AddTransient<ServiceSkjemaTableRepository>();

                        services.AddSession();
                        //{
                        //    options.IdleTimeout = TimeSpan.FromMinutes(30);
                        //});



                        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                            .AddCookie(options =>
                            {
                                options.Cookie.Name = "Innlogget";
                                options.LoginPath = "/Home/Login";
                                options.AccessDeniedPath = "/Home/Login";
                                options.LogoutPath = "";
                            });

                        services.AddAuthorization(options =>
                        {
                            options.AddPolicy("UserOnly", policy => policy.RequireClaim("BrukerNavn"));

                        });



                    });


                    webBuilder.Configure((appBuilder) =>
                    {
 

                        var env = appBuilder.ApplicationServices.GetRequiredService<IWebHostEnvironment>();

                        if (env.IsDevelopment())
                        {
                            appBuilder.UseDeveloperExceptionPage();
                        }
                        else
                        {
                            appBuilder.UseExceptionHandler("/Home/Error");
                            appBuilder.UseHsts();
                        }

                        appBuilder.UseHttpsRedirection();
                        appBuilder.UseStaticFiles();
                        appBuilder.UseRouting();

                        appBuilder.UseSession();

                        appBuilder.UseAuthentication();
                        appBuilder.UseAuthorization();
                        
                        appBuilder.UseHttpLogging();

                        appBuilder.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllerRoute(
                                name: "default",
                                pattern: "{controller=Home}/{action=Login}/{id?}");
                        });
                    });
                });


    }
}
