namespace Personal_Landing.Services;

public sealed class HttpCallService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HttpCallService(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

    public async Task CallHealthCheck()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, "https://rambod.dev/health"));
        Console.WriteLine($"Status:{response.IsSuccessStatusCode}");
    }
}