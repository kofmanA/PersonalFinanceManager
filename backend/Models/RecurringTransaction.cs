using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class RecurringTransaction
{
    public int RecurringTransactionId { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal Amount { get; set; }

    [Required]
    [RegularExpression("Daily|Weekly|Monthly|Yearly",
        ErrorMessage = "Frequency must be Daily, Weekly, Monthly, or Yearly.")]
    public string Frequency { get; set; } = "Monthly";

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }
}

