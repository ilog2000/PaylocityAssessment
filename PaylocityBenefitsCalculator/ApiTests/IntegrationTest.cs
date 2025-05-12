using System.Net.Http;

using Xunit;

namespace ApiTests;

public class IntegrationTest :  IClassFixture<TestServer>
{
    public readonly HttpClient HttpClient;

    public IntegrationTest(TestServer factory)
    {
        HttpClient = factory.CreateClient();
    }
}
