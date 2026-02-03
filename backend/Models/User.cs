using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class User
{
    public int UserId { get; set; }

    [Required]
    [StringLength(52)]
    public string Username { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string PasswordHash { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Salt { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    public ICollection<RecurringTransaction> RecurringTransactions { get; set; } = new List<RecurringTransaction>();
    public ICollection<Budget> Budgets { get; set; } = new List<Budget>();
}
