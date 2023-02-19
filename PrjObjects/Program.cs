using Microsoft.EntityFrameworkCore;
using PrjObjects.Models;
namespace PrjObjects
{
   public class Program
   {
      public static void Main(string[] args)
      {
         var builder = WebApplication.CreateBuilder(args);
         builder.Services.AddControllersWithViews();
         builder.Services.AddDbContext<EfDatabase>(options =>
         {
            MySqlServerVersion serverVersion = new(new Version(8, 0, 31));
            string connectionString = builder.Configuration.GetConnectionString("Database");
            options.UseMySql(connectionString, serverVersion);
         });
         var app = builder.Build();
         if (!app.Environment.IsDevelopment())
         {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
         }
         app.UseHttpsRedirection();
         app.UseStaticFiles();
         app.UseRouting();
         app.UseAuthorization();
         app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
         app.Run();
      }
   }
}