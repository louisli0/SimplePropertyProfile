using System;
using System.Text;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RealEstateAPI;
using System.Net;

using System.Linq;
using Contracts.V1.Request;
using System.Collections.Generic;
using System.Collections;

public class Setup : IDisposable
{
    public readonly HttpClient TestClient;
    private readonly IServiceProvider _serviceProvider;

    public Setup()
    {
        var factory = new WebApplicationFactory<Startup>()
        .WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<DataContext>));
                services.AddDbContext<DataContext>(opt => opt.UseSqlServer("TestWindowsDB"));

                // Ensure DB Setup
                var sp = services.BuildServiceProvider();
                using(var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<DataContext>();
                    db.Database.EnsureCreated();
                }
            });
        });

        _serviceProvider = factory.Services;
        TestClient = factory.CreateClient();
    }

    public async Task<HttpResponseMessage> QueryProperty(QueryVGData data)
    {
       var result =  await TestClient.GetAsync(ApiRoutes.VGData.QueryProperty + "/?" + ToQueryString(data));
        return result;
    }

    public async Task<HttpResponseMessage> QueryLocality(QueryVGData data)
    {
        return await TestClient.GetAsync(ApiRoutes.VGData.QueryLocality + "/?" + ToQueryString(data));
    }


    //Helper
    public string ToQueryString(object data)
    {

        //Source: https://stackoverflow.com/a/37657375
        var result = new List<string>();
        var properties = data.GetType().GetProperties().Where(p => p.GetValue(data, null) != null);
        foreach (var p in properties)
        {
            var value = p.GetValue(data, null);
            var enumerable = value as ICollection;
            if (enumerable != null)
            {
                result.AddRange(from object v in enumerable select string.Format("{0}={1}", p.Name, HttpUtility.UrlEncode(v.ToString())));
            }
            else
            {
                result.Add(string.Format("{0}={1}", p.Name, HttpUtility.UrlEncode(value.ToString())));
            }
        }
        return string.Join("&", result.ToArray());

    }

    public void Dispose()
    {
        Console.WriteLine("Resetting DB");
        using var serviceScope = _serviceProvider.CreateScope();
        var context = serviceScope.ServiceProvider.GetService<DataContext>();
        context.Database.EnsureDeleted();
    }
}