namespace LegacyApp.Tests;

public interface IUserCreditService
{
    int GetCreditLimit(string lastName, DateTime dateOfBirth);
}