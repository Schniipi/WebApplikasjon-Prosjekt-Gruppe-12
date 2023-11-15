using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using WebApplication1.Models.Tables;
using MySqlConnector;
using System.Data;
using System.Reflection.PortableExecutable;
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
                        services.AddTransient<KundeTableModelRepository>();
                        services.AddTransient<BrukerTableModelRepository>();

                        services.AddAuthentication(options =>
                        {
                            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                            options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;

                            //Default log in scheme
                            options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        })
                            .AddCookie(options =>
                            {
                                options.LoginPath = "/Home/Login"; 
                                options.AccessDeniedPath = "/Home/Error"; 
                            });
                        services.AddRazorPages();
                        services.AddControllersWithViews();

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
=======
using Microsoft.AspNetCore.Mvc;

>>>>>>> origin/master
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Sikkerhetsheaderene legges til her
app.Use(async (context, next) =>
{

    context.Response.Headers.Add("X-Xss-Protection", "1");
    context.Response.Headers.Add("X-Frame-Options", "DENY");
    context.Response.Headers.Add("Referrer-Policy", "no-referrer");
    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
    context.Response.Headers.Add(
        "Content-Security-Policy",
        "default-src 'self' ; " +
        "img-src 'self';" +
        "font-src 'self'; " +
        "style-src 'self'; " +
        "script-src 'self'; " +
        "frame-src 'self'; " +
        "connect-src 'self' wss;") ;
    await next();
});

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
*/