namespace LegacyApp.Tests;

public class UserCreditServiceFactory : IUserCreditServiceFactory
{
    public IUserCreditService Create()
    {
        return new UserCreditService();
    }
}
