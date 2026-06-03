namespace HolaDotnetFront.Models;

public class BankSummaryViewModel
{
    public decimal TotalBalance { get; set; }
    public decimal MonthlyIncome { get; set; }
    public decimal MonthlyExpenses { get; set; }
    public int MovementCount { get; set; }
    public List<string> Alerts { get; set; } = new();
}
