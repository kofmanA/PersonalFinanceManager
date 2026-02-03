namespace backend.DTOs.CategoryDtos;

public class CategoryDto
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string CategoryColor { get; set; } = "#000000";
}

public class CreateCategoryDto
{
    public string CategoryName { get; set; } = string.Empty;
    public string CategoryColor { get; set; } = "#000000";
}
