using Ecommerce_App.Data;
using Ecommerce_App.Models;
using Ecommerce_App.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString") ?? throw new InvalidOperationException("Connection string 'DefaultConnectionString' not found.");

        // Add services to the container.

        builder.Services.AddMvc();
        builder.Services.AddTransient<IEcommerceRepository<Product>, ProductRepository>();
        builder.Services.AddTransient<IEcommerceRepository<Category>, CategoryRepository>();
        builder.Services.AddDbContext<EcommerceAppDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
        });

        builder.Services.AddDbContext<Ecommerce_AppIdentityContext>(options => options.UseSqlServer(connectionString));

        builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<Ecommerce_AppIdentityContext>();

        builder.Services.AddControllersWithViews();

        builder.Services.AddRazorPages();

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
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.MapRazorPages();

        app.Run();

    }
}

