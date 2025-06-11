using LinkDev.IKEA.BLL;
using LinkDev.IKEA.DAL;
using LinkDev.IKEA.DAL.Persistance.Data;
using LinkDev.IKEA.PL.Extenstions;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.IKEA.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure services 
            // Add services to the container.
            builder.Services.AddWebServices();
            builder.Services.AddPresistanceServices(builder.Configuration);
            builder.Services.AddApplicationService();
            #endregion

            var app = builder.Build();

            #region Database Initializer
            app.InitializeDatabase();
            #endregion

            #region Configure HTTP Request Pipeline 
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();

            // Authentication and Authorization must be after UseRouting() but before mapping routes
            app.UseAuthentication();
            app.UseAuthorization();

            //app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();
            #endregion

            app.Run();
        }
    }
}