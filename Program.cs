using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using ZenithCMS.Data;
using ZenithCMS.Service;
using ZenithCMS.Services;

namespace ZenithCMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<UserService>();  //  Register your UserService
            builder.Services.AddScoped<ServiceManager>();
            builder.Services.AddScoped<AboutManager>();
            builder.Services.AddScoped<ProjectManager>();



            builder.Services.AddControllersWithViews();
            builder.Services.AddDistributedMemoryCache(); // Required for session
            builder.Services.AddSession(); // Add session support
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                    });
            });


            builder.Services.Configure<FormOptions>(options =>
                {
                    options.MultipartBodyLengthLimit = 20971520;
                    options.MultipartHeadersLengthLimit = 20971520; // 20MB
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            builder.Services.AddSession();
            app.UseSession();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("AllowAllOrigins");

            app.UseAuthorization();

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}" // Adjust to your controller
                );

            app.Run();
        }
    }
}
