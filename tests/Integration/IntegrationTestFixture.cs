using System;
using System.Net.Http;
using Api;
using Infra.Data;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace Integration
{
    public class IntegrationTestFixture : IDisposable
    {
        private readonly IDbContextTransaction _transaction;

        protected readonly HttpClient HttpClient;

        protected IntegrationTestFixture(TestingWebApplicationFactory<Startup> factory)
        {
            HttpClient = factory.CreateClient();

            var context = ServiceProviderHelper.ServiceProvider.GetRequiredService<Context>();
            _transaction = context.Database.BeginTransaction();
        }

        public void Dispose()
        {
            if (_transaction == null) return;
            _transaction.Rollback();
            _transaction.Dispose();
        }
    }
}
