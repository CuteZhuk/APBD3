namespace LegacyApp.Tests;

public class UserCreditService : IUserCreditService
{
    public int GetCreditLimit(string lastName, DateTime dateOfBirth)
    {
        // Simulating contact with remote service to get credit limit
        int randomWaitingTime = new Random().Next(3000);
        Thread.Sleep(randomWaitingTime);

        var database = new Dictionary<string, int>()
        {
            {"Kowalski", 200},
            {"Malewski", 20000},
            {"Smith", 10000},
            {"Doe", 3000},
            {"Kwiatkowski", 1000}
        };

        if (database.ContainsKey(lastName))
            return database[lastName];

        throw new ArgumentException($"Client {lastName} does not exist");
    }
}
