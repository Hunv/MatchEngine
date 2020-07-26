using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MatchEngine.DatabaseModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MatchEngine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Ensure database is created
            using (var dbContext = new MyDbContext())
            {   
                var created = dbContext.Database.EnsureCreated();
                if (created)
                {
                    dbContext.StandaloneMatch.Add(new StandaloneMatch() { Teams = new List<StandaloneTeam>() { new StandaloneTeam(), new StandaloneTeam() } });
                    dbContext.SaveChanges();
                }
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
