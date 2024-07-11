using System.Text.Json;
using RPSLSGame.Models;

namespace RPSLSGame.Services;

public class RandomNumberService : IRandomNumberService
{
    private readonly HttpClient _httpClient;
    private readonly string? _randomNumberServiceUrl;

    public RandomNumberService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _randomNumberServiceUrl = configuration["RandomNumberService:Url"];
    }

    public async Task<int> FetchRandomNumberAsync()
    {
        var response = await _httpClient.GetStringAsync(_randomNumberServiceUrl);

        var randomNumberResponse = JsonSerializer.Deserialize<RandomNumberResponse>(response);
        if (randomNumberResponse != null && randomNumberResponse.RandomNumber > 0)
        {
            return (randomNumberResponse.RandomNumber % 5) + 1;
        }

        throw new Exception("Invalid response from the external service");
    }
}
