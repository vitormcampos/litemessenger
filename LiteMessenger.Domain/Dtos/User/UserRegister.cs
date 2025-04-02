namespace LiteMessenger.Domain.Dtos.User;

public sealed record UserRegister(
    string UserName,
    string Email,
    string Password,
    string ConfirmPassword
)
{
    public bool PasswordIsValid()
    {
        return Password.Count() > 6 && Password == ConfirmPassword;
    }
}
