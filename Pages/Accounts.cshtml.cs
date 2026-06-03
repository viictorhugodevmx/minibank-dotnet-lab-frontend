using HolaDotnetFront.Models;
using HolaDotnetFront.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HolaDotnetFront.Pages;

public class AccountsModel : PageModel
{
    private readonly MiniBankApiService _miniBankApiService;

    public List<AccountViewModel> Accounts { get; private set; } = new();
    public string? ErrorMessage { get; private set; }

    public AccountsModel(MiniBankApiService miniBankApiService)
    {
        _miniBankApiService = miniBankApiService;
    }

    public async Task OnGetAsync()
    {
        try
        {
            Accounts = await _miniBankApiService.GetAccountsAsync();
        }
        catch
        {
            ErrorMessage = "No se pudieron cargar las cuentas. Verifica que la API esté corriendo en http://localhost:5155.";
        }
    }
}
