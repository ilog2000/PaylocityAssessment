using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Api.Models;
using Api.Utils;

using Newtonsoft.Json;

using Xunit;

namespace ApiTests;

internal static class ShouldExtensions
{
    public static Task ShouldReturn(this HttpResponseMessage response, HttpStatusCode expectedStatusCode)
    {
        AssertCommonResponseParts(response, expectedStatusCode);
        return Task.CompletedTask;
    }
    
    public static async Task ShouldReturn<T>(this HttpResponseMessage response, HttpStatusCode expectedStatusCode, T expectedContent)
    {
        await response.ShouldReturn(expectedStatusCode);
        Assert.Equal("application/json", response.Content.Headers.ContentType?.MediaType);
        var apiResponse = JsonConvert.DeserializeObject<ApiResponse<T>>(await response.Content.ReadAsStringAsync());
        Assert.True(apiResponse!.Success);
        var decimalConverter = new DecimalFormatConverter();
        // Use DecimalFormatConverter to serialize data, so that decimal string formatting is consistent
        Assert.Equal(JsonConvert.SerializeObject(expectedContent, decimalConverter), JsonConvert.SerializeObject(apiResponse.Data, decimalConverter));
    }

    private static void AssertCommonResponseParts(this HttpResponseMessage response, HttpStatusCode expectedStatusCode)
    {
        Assert.Equal(expectedStatusCode, response.StatusCode);
    }
}

