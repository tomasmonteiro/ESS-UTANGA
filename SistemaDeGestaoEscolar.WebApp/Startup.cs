using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SistemaDeGestaoEscolar.Common;
using SistemaDeGestaoEscolar.Validation;
using SistemaDeGestaoEscolar.WebApp;
using System.Net;

namespace SistemaDeGestaoEscolarWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<RegistroValidator>());

            services.AddDatabase(Configuration);
            services.AddIdentity();

            services.AddRepositories();
            services.AddSingleton<ILog, LogConcrete>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILog logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseGestaoException(logger);
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseGestaoException(logger);
                //app.UseStatusCodePagesWithRedirects("/Home/ErrorStatusCode?code={0}");
                app.UseStatusCodePagesWithReExecute("/Home/ErrorStatusCode", "?code={0}");
            app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
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
