namespace LiteMessenger.Domain.Exceptions;

public class RegisterNotFoundException : Exception
{
    public RegisterNotFoundException() { }

    public RegisterNotFoundException(string message)
        : base(message) { }
}
