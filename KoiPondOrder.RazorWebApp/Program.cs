using KoiPondOrder.Repositories.Models;
using KoiPondOrderSystemManagement.Repositories;
using KoiPondOrderSystemManagement.Services;

namespace KoiPondOrder.RazorWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddScoped<DesignService>();
            builder.Services.AddScoped<DesignRepository>();
            builder.Services.AddScoped<PromotionService>();
            builder.Services.AddScoped<PromotionRepository>();


            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            builder.Services.AddScoped<FA24_PRN221_3W_G5_KoiPondOrderSystemManagementContext>();
            builder.Services.AddScoped<PondsRepository>();
            builder.Services.AddScoped<ServicesRepository>();
            builder.Services.AddScoped<PaymentService>();
            builder.Services.AddScoped<PondsService>();
            builder.Services.AddScoped<ServicesService>();
            builder.Services.AddScoped<UserService>();

            builder.Services.AddScoped<OrderPaymentService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();
            app.MapRazorPages();
            app.MapGet("/", context =>
            {
                context.Response.Redirect("/Login");
                return Task.CompletedTask;
            });


            app.Run();
        }
    }
}
