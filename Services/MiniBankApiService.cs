using System.Text.Json;
using HolaDotnetFront.Models;

namespace HolaDotnetFront.Services;

public class MiniBankApiService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public MiniBankApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<BankSummaryViewModel?> GetSummaryAsync()
    {
        return await _httpClient.GetFromJsonAsync<BankSummaryViewModel>(
            "/api/minibank/summary",
            _jsonOptions
        );
    }

    public async Task<List<AccountViewModel>> GetAccountsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<AccountViewModel>>(
            "/api/minibank/accounts",
            _jsonOptions
        ) ?? new List<AccountViewModel>();
    }

    public async Task<List<MovementViewModel>> GetMovementsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<MovementViewModel>>(
            "/api/minibank/movements",
            _jsonOptions
        ) ?? new List<MovementViewModel>();
    }
}
