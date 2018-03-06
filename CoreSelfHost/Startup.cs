using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CoreSelfHost
{
    public class Startup
    {
        //public void Configure(IApplicationBuilder app)
        //{
        //    app.Run(context => context.Response.WriteAsync("Hello Word！"));

        //}

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }
        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddOptions();
            //services.Configure<MyConfig>(Configuration.GetSection("MySets"));
        }
           
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
            app.Run(context => Task.Run(() => { context.Response.ContentType = "text/html; charset=utf-8"; }));
        } 
    }
}
