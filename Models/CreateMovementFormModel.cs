using System.ComponentModel.DataAnnotations;

namespace HolaDotnetFront.Models;

public class CreateMovementFormModel
{
    [Required]
    public string AccountId { get; set; } = string.Empty;

    [Required]
    [MinLength(3)]
    public string Description { get; set; } = string.Empty;

    [Required]
    public string Type { get; set; } = "expense";

    [Range(1, 999999)]
    public decimal Amount { get; set; }
}
