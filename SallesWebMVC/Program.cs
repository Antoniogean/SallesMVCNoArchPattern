using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SallesWebMVC.Data;
using SallesWebMVC.Services;

namespace SallesWebMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connection = builder.Configuration.GetConnectionString("SallesWebMVCContext");
            Console.WriteLine(connection);
            builder.Services.AddDbContextPool<SallesWebMVCContext>(options =>
                options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

            builder.Services.AddScoped<SeedingService>();
            builder.Services.AddScoped<SellerService>();
         
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddControllersWithViews();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingService>().Seed();

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

            app.Run();
        }

    }
}



