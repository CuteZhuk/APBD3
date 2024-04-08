namespace LegacyApp.Tests;

public class UserService : IUserService
{
    private readonly IUserDataAccess _userDataAccess;

    public UserService(IUserDataAccess userDataAccess)
    {
        _userDataAccess = userDataAccess;
    }

    public void AddUser(User user)
    {
        ValidateUser(user);

        _userDataAccess.SaveUser(user);
    }

    private void ValidateUser(User user)
    {
        // Walidacja użytkownika
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        if (string.IsNullOrWhiteSpace(user.Name))
            throw new ArgumentException("User name cannot be empty", nameof(user.Name));

        // Możemy dodać więcej walidacji w przyszłości
    }
}