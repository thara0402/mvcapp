using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace mvcapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 環境変数からURLを取得する
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables("")
                .Build();
            var url = config["ASPNETCORE_URLS"] ?? "http://*:5000";

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseUrls(url)
                .Build();

            host.Run();
        }
    }
}
