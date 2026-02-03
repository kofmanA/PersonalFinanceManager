using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class Transaction
{
    public int TransactionId { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal Amount { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }
}
