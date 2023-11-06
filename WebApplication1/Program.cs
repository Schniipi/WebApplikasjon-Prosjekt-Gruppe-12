
using Microsoft.AspNetCore.Mvc;

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
        "script-src 'self''sha256-225058969f03b805882feb9401db6e53a7b6d0f32f0ab0d51b57e7a3d002003a'; " +
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
