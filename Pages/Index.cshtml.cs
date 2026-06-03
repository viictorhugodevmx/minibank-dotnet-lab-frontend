using HolaDotnetFront.Models;
using HolaDotnetFront.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HolaDotnetFront.Pages;

public class IndexModel : PageModel
{
    private readonly MiniBankApiService _miniBankApiService;

    public BankSummaryViewModel? Summary { get; private set; }
    public List<AccountViewModel> Accounts { get; private set; } = new();
    public List<MovementViewModel> Movements { get; private set; } = new();
    public string? ErrorMessage { get; private set; }

    public IndexModel(MiniBankApiService miniBankApiService)
    {
        _miniBankApiService = miniBankApiService;
    }

    public async Task OnGetAsync()
    {
        try
        {
            Summary = await _miniBankApiService.GetSummaryAsync();
            Accounts = await _miniBankApiService.GetAccountsAsync();
            Movements = await _miniBankApiService.GetMovementsAsync();
        }
        catch
        {
            ErrorMessage = "No se pudo conectar con la API de MiniBank. Verifica que HolaDotnet esté corriendo en http://localhost:5155.";
        }
    }
}
