using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class Category
{
    public int CategoryId { get; set; }

    [Required]
    [StringLength(52)]
    public string CategoryName { get; set; } = string.Empty;

    [StringLength(7)]
    public string CategoryColor { get; set; } = "#000000";

    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    public ICollection<RecurringTransaction> RecurringTransactions { get; set; } = new List<RecurringTransaction>();
    public ICollection<Budget> Budgets { get; set; } = new List<Budget>();
}
