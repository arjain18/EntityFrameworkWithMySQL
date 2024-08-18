using EntityFrameworkWithMySQL.Data;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkWithMySQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Added ConnectionString
            var connectionString = builder.Configuration.GetConnectionString("AppDbConnectionString");
            builder.Services.AddDbContext<AppDbContext>
                (options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
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
