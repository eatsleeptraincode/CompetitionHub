using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CompetitionHub.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.PlatformAbstractions;
using Xunit;

namespace CompetitionHub.IntegrationTests
{
    public class Class1
    {
        [Fact]
        public void PassingTest()
        {
            var path = PlatformServices.Default.Application.ApplicationBasePath;
            var setDir = Path.GetFullPath(Path.Combine(path, @"..\..\..\..\CompetitionHub.Mvc" ));
            var builder = new WebHostBuilder()
                .UseStartup<Startup>()
                .UseContentRoot(setDir);
            var server = new TestServer(builder);
            var client = server.CreateClient();
            var response = client.GetAsync("/").Result;
            response.EnsureSuccessStatusCode();
        }
    }
}
