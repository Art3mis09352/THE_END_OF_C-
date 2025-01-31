using Microsoft.EntityFrameworkCore;
using THE_END_OF_C_.Models;

namespace THE_END_OF_C_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connection = builder.Configuration.GetConnectionString("testConnection");

            

            builder.Services.AddDbContext<Context>(options => options.UseSqlServer(connection));
            

            builder.Services.AddControllersWithViews();

            // Configure the HTTP request pipeline.
            var app = builder.Build();
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
                pattern: "{controller=Home}/{action=Index_TGROUP}/{id?}");

            app.MapControllerRoute(
                name: "property",
                pattern: "{controller=Home}/{action=Create_TPROPERTY}/{id?}");

            app.Run();

        }
    }
}
