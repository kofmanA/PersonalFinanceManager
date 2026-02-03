namespace backend.DTOs.TransactionDtos;

public class TransactionDto
{
    public int TransactionId { get; set; }
    public decimal Amount { get; set; }

    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
}

public class CreateTransactionDto
{
    public decimal Amount { get; set; }
    public int CategoryId { get; set; }
}
