using LinkDev.IKEA.BLL;
using LinkDev.IKEA.DAL;
using LinkDev.IKEA.DAL.Persistance.Data;
using LinkDev.IKEA.PL.Extenstions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Extensions.Options;


namespace LinkDev.IKEA.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure services 

            // Add services to the container.
            builder.Services.AddControllersWithViews();
           
            #region OR
            /// builder.Services.AddDbContext<ApplicationDbContext>(
            ///     optionsAction: (OptionBuilder) =>
            ///     {
            ///         OptionBuilder.UseSqlServer(connectionString:builder.Configuration.GetConnectionString("DefaultConnection"));
            ///     },
            ///     contextLifetime:ServiceLifetime.Scoped,
            ///     optionsLifetime: ServiceLifetime.Scoped
            ///     ); 
            ///     

            builder.Services.AddPresistanceServices(builder.Configuration);
            builder.Services.AddApplicationService();
            #endregion
            /// builder.Services.AddScoped<DbContextOptions<ApplicationDbContext>>();
            /// builder.Services.AddScoped<ApplicationDbContext>();
            builder.Services.AddScoped((ServicesProvider) =>
            {
                // var option = ServicesProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>();
                var OptionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                OptionBuilder.UseSqlServer("Server =.;Database =IKEA;Trusted_Connection =True ; Encrypt =True;TrustServerCertificate =true");

                return new ApplicationDbContext(OptionBuilder.Options);
            });
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

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets(); 
            #endregion

            app.Run();
        }
    }
}
