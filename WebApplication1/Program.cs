using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using WebApplication1.Models.FormDataMappe;
using MySqlConnector;
using System.Data;

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
                        services.AddTransient<ServiceModelRepository>();
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
                        appBuilder.UseAuthorization();

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


/*
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
*/