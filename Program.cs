using Microsoft.EntityFrameworkCore;
using Parcial1_Ap1_SamuelDuran.Components;
using Parcial1_Ap1_SamuelDuran.DAL;
using Parcial1_Ap1_SamuelDuran.Services;

namespace Parcial1_Ap1_SamuelDuran
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var ConStr = builder.Configuration.GetConnectionString("ConStr");
            builder.Services.AddDbContext<Context>(Options => Options.UseSqlite(ConStr));
            builder.Services.AddScoped<MetasService>();

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
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}