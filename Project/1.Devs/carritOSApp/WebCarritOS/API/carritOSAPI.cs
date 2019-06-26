using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebCarritOS.API
{
    public class carritOSAPI
    {
       
        public HttpClient Initial()
        {

            var Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:60217/");
            return Client;
        }

       
    }
}
