using carritOSCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
/**
* https://www.youtube.com/watch?v=p5l7x_pFjmI&t=40s
* @author Juan Diego Alosilla
* @email diegoalosillagmail.com
*/
namespace XIntegrationTest
{
  
    public class TestClientProvider:IDisposable
    {
        private TestServer server;
        public HttpClient Client { get; set; }

        public TestClientProvider()
        {
            server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = server.CreateClient();
        }

        public void Dispose()
        {
            server?.Dispose();
            Client?.Dispose();
        }
    }
}
