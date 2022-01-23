using System;
using System.Linq;
using Domain.Repositories;
using Infra.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Integration
{
    public class TestingWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<Context>));
                services.Remove(descriptor);
                services.AddDbContext<Context>(options =>
                {
                    options.UseSqlServer("Server=localhost,11000;Database=BlissAppTests;User Id=sa;Password=Bl1ssApp.*");
                });


                var sp = services.BuildServiceProvider();
                var context = sp.GetRequiredService<Context>();
                context.Database.EnsureDeleted();

                services.AddScoped<IQuestionRepository>((_) => new QuestionRepository(context));

                ServiceProviderHelper.ServiceProvider = sp;
            });
        }
    }
}
