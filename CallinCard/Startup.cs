using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
 
namespace CallingCard
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Mvc as a service making it available across our entire app
            services.AddMvc();
        }
         
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            // The "diagnostics" in the "project.jason" package gives us access to the .UseDeveloperExceptionPage() middleware, which renders a detailed error page to the browser when a run time exception occurs. "Logging.Console" produces a readout in our terminal displaying the response codes from our http requests. Both of these tools are enabled in our startup file
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();
            // Use the Mvc to handle Http requests and responses **Always Last**
            app.UseMvc();
        }
    }
}