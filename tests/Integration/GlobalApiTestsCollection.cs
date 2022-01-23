using Api;
using Xunit;

namespace Integration
{
    /// <summary>
    /// Required for configurations before and after running ALL tests
    /// More info: https://xunit.net/docs/shared-context
    /// </summary>
    [CollectionDefinition("API-TESTS")]
    public class GlobalApiTestsCollection : ICollectionFixture<TestingWebApplicationFactory<Startup>>
    {
    }
}
