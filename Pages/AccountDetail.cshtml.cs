using HolaDotnetFront.Models;
using HolaDotnetFront.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HolaDotnetFront.Pages;

public class AccountDetailModel : PageModel
{
    private readonly MiniBankApiService _miniBankApiService;

    public AccountViewModel? Account { get; private set; }
    public List<MovementViewModel> Movements { get; private set; } = new();
    public string? ErrorMessage { get; private set; }

    public AccountDetailModel(MiniBankApiService miniBankApiService)
    {
        _miniBankApiService = miniBankApiService;
    }

    public async Task OnGetAsync(string accountId)
    {
        try
        {
            Account = await _miniBankApiService.GetAccountByIdAsync(accountId);

            if (Account is null)
            {
                ErrorMessage = "No se encontró la cuenta solicitada.";
                return;
            }

            Movements = await _miniBankApiService.GetMovementsByAccountIdAsync(accountId);
        }
        catch
        {
            ErrorMessage = "No se pudo cargar el detalle de la cuenta. Verifica que la API esté corriendo.";
        }
    }
}
