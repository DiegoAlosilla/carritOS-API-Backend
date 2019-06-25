using carritOSCore.Model.Context;
using carritOSCore.Model.Entities;
using carritOSCore.Model.Service;
using carritOSCore.Model.ServiceImpl;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;
/**
* https://www.youtube.com/watch?v=p5l7x_pFjmI&t=40s
* @author Juan Diego Alosilla
* @email diegoalosillagmail.com
* NuGet
* FluentAssertions
* Miscrosoft.AspNetCore.TestHost
*/
namespace XIntegrationTest
{

    public class IntegrationTest
    {
        //String Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImRpZWdvYWxvc2lsbGFiY0BtZ2FpbC5jb20iLCJBbG9zaWxsYSI6Ikp1YW4gRGllZ28iLCJqdGkiOiIzNmE5OGFmMC00NWQ5LTQwYmItODFiNS1mYzRmZmVhYzFjODYiLCJleHAiOjE1NjEzMzUxNzIsImlzcyI6ImFsb3NpbGxhLmNvbSIsImF1ZCI6ImFsb3NpbGxhLmNvbSJ9.7Iyn7JehQPkd0oTi86OWfDwfNqyzLrCyZevIIIa5j4o";

        [Fact]
        public async Task Test_Post()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.PostAsync("api/BusinessOwner/Create", new
                    StringContent(JsonConvert.SerializeObject(new BusinessOwner()
                    {
                        FirstName = "DiegoGetta",
                        LastName = "Alosilla",
                        Dni = "12345678",
                        Email = "deigoalosilla@gmail.com",
                        Movil = "966450252",
                        Password = "1234",
                        City = "Lima",
                        Country = "Peru"
                    }), Encoding.UTF8, "application/json"));

                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);

            }
        }


        [Fact]
        public async Task Test_Get_All()
        {
            using (var client = new TestClientProvider().Client)
            {
                
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", Token);
                var response = await client.GetAsync("api/BusinessOwner");
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);

            }
        }


        [Fact]
        public async Task Test_Put()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.PutAsync("api/BusinessOwner/update/27", new
                    StringContent(JsonConvert.SerializeObject(new BusinessOwner()
                    {
                        Id = 27,
                        FirstName = "dash",
                        LastName = "Alosilla",
                        Dni = "12345678",
                        Email = "deigoalosilla@gmail.com",
                        Movil = "966450252",
                        Password = "1234",
                        City = "Lima",
                        Country = "Peru"
                    }), Encoding.UTF8, "application/json"));

                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);

            }
        }

        [Fact]
        public async Task Test_Delete()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.DeleteAsync("api/BusinessOwner/delete/11");

                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);

            }
        }

    }
}
