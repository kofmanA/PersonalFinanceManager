namespace backend.DTOs.RecurringTransactionDtos;

public class RecurringTransactionDto
{
    public int RecurringTransactionId { get; set; }
    public decimal Amount { get; set; }
    public string Frequency { get; set; } = string.Empty;

    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
}

public class CreateRecurringTransactionDto
{
    public decimal Amount { get; set; }
    public string Frequency { get; set; } = string.Empty;
    public int CategoryId { get; set; }
}
