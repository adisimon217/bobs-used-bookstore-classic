using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Bookstore.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure services here
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env, ILoggerFactory loggerFactory)
        {
// Configure logging using the built-in ILoggerFactory
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            ConfigurationSetup.ConfigureConfiguration();

            // Note: DependencyInjection should be configured in ConfigureServices method
            // DependencyInjectionSetup.ConfigureDependencyInjection(app);

            // Authentication configuration might need to be adjusted for ASP.NET Core
            // AuthenticationConfig.ConfigureAuthentication(app);

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