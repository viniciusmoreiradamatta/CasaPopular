using CasaPopular.Application.Interface;
using CasaPopular.Application.Service;
using CasaPopular.Data.Context;
using CasaPopular.Data.Repository;
using CasaPopular.Data.UnitOfWork;
using CasaPopular.Domain.Interfaces;
using CasaPopular.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CasaPopular.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CasaPopularContext>(op => op.UseInMemoryDatabase("Base"));

            services.AddTransient<IUnityOfWork, UnityOfWork>();
            services.AddTransient<IFamiliaService, FamiliaService>();
            services.AddTransient<IFamiliaRepository, FamiliaRepository>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}