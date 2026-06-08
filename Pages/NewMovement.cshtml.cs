using HolaDotnetFront.Models;
using HolaDotnetFront.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HolaDotnetFront.Pages;

public class NewMovementModel : PageModel
{
    private readonly MiniBankApiService _miniBankApiService;

    [BindProperty]
    public CreateMovementFormModel Form { get; set; } = new();

    public List<AccountViewModel> Accounts { get; private set; } = new();
    public string? ErrorMessage { get; private set; }

    public NewMovementModel(MiniBankApiService miniBankApiService)
    {
        _miniBankApiService = miniBankApiService;
    }

    public async Task OnGetAsync()
    {
        Accounts = await _miniBankApiService.GetAccountsAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        Accounts = await _miniBankApiService.GetAccountsAsync();

        if (!ModelState.IsValid)
        {
            return Page();
        }

        var created = await _miniBankApiService.CreateMovementAsync(Form);

        if (!created)
        {
            ErrorMessage = "No se pudo crear el movimiento. Verifica los datos.";
            return Page();
        }

        return RedirectToPage("/Index");
    }
}
