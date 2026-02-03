using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class Budget
{
    public int BudgetId { get; set; }

    [Range(0, double.MaxValue)]
    public decimal MonthlyLimit { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }
}
