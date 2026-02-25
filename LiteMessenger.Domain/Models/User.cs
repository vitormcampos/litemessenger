namespace LiteMessenger.Domain.Models;

public class User
{
    public string? Id { get; private set; }
    public string? Email { get; private set; }
    public string? Password { get; private set; }
    public string? Name { get; private set; }
    public int Status { get; private set; }
    public string? ProfilePictureUrl { get; private set; }
    public DateTime? RegistrationDate { get; private set; }
    public DateTime? LastLoginDate { get; private set; }

    public User(
        string? Id,
        string? Email,
        string? Password,
        string? Name,
        int Status,
        string? ProfilePictureUrl,
        DateTime? RegistrationDate,
        DateTime? LastLoginDate
    )
    {
        this.Id = Id;
        this.Email = Email;
        this.Password = Password;
        this.Name = Name;
        this.Status = Status;
        this.ProfilePictureUrl = ProfilePictureUrl;
        this.RegistrationDate = RegistrationDate;
        this.LastLoginDate = LastLoginDate;
    }

    private User() { }

    public void UpdateLastLoginDate()
    {
        this.LastLoginDate = DateTime.Now;
    }

    public void UpdateStatus(int newStatus)
    {
        this.Status = newStatus;
    }
}
