namespace HolaDotnetFront.Models;

public class AccountViewModel
{
    public string Id { get; set; } = string.Empty;
    public string Holder { get; set; } = string.Empty;
    public string Product { get; set; } = string.Empty;
    public string Currency { get; set; } = "MXN";
    public decimal Balance { get; set; }
}
