using carritOSCore.Model.Context;
using carritOSCore.Model.Entities;
using carritOSCore.Model.Service;
using carritOSCore.Model.ServiceImpl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace XIntegrationTest
{
    public class IntegrationTest
    {
        
        [Fact]
        public async Task Test_Get_All()
        {
            var client = new TestClientProvider().Client;

            var response = await client.GetAsync("/api/BusinessOwner");

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
