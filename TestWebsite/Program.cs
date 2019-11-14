using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace TestWebsite
{
    public class Program
    {
    //https://docs.microsoft.com/en-us/aspnet/core/migration/1x-to-2x/
    //public static void Main(string[] args)
    //{
    //    var host = new WebHostBuilder()
    //        .UseKestrel()
    //        .UseContentRoot(Directory.GetCurrentDirectory())
    //        .UseIISIntegration()
    //        .UseStartup<Startup>()
    //        .UseApplicationInsights()
    //        .Build();

    //    host.Run();
    //}


    public static void Main(string[] args)
    {
      BuildWebHost(args).Run();
    }

    public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            //.UseKestrel() //https://stackoverflow.com/questions/58080353/application-is-running-inside-iis-process-but-is-not-configured-to-use-iis-serve
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<Startup>()
            .UseApplicationInsights()
            .Build();
  }
}
