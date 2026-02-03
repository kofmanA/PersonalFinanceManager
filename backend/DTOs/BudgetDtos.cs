namespace backend.DTOs.BudgetDtos;

public class BudgetDto
{
    public int BudgetId { get; set; }
    public decimal MonthlyLimit { get; set; }

    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
}

public class CreateBudgetDto
{
    public decimal MonthlyLimit { get; set; }
    public int CategoryId { get; set; }
}
