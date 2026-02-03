namespace backend.DTOs.UserDtos;

public class RegisterDto
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class LoginDto
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class UserDto
{
    public int UserId { get; set; }
    public string Username { get; set; } = string.Empty;
}
