using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace CoreSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("hosting.json")
                .Build();

            var webHost = new WebHostBuilder();

            webHost.UseKestrel()
                .UseConfiguration(config)
                .UseStartup<Startup>()
               .UseContentRoot(Directory.GetCurrentDirectory())
               .UseSetting("log", "false")
               //.UseUrls("http://localhost:1001/", "http://localhost:1002/")
               .Build()
               .Run();

            //var host = new WebHostBuilder()
            //                .UseKestrel(option => {
            //                    option.UseHttps("server.pfx", "linezero");
            //                })
            //                .UseUrls("https://*:443")
            //                .UseContentRoot(Directory.GetCurrentDirectory())
            //                .UseIISIntegration()
            //                .UseStartup<Startup>()
            //                .Build();

            //host.Run();
            Console.WriteLine("启动成功！");
        }
    }
}
