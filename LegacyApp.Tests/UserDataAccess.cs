namespace LegacyApp.Tests;

public class UserDataAccess : IUserDataAccess
{
    public void SaveUser(User user)
    {
        Thread.Sleep(2000);
    }
}