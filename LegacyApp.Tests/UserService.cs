namespace LegacyApp.Tests;

public class UserService
{
    private readonly IClientRepository _clientRepository;
    private readonly IUserCreditServiceFactory _userCreditServiceFactory;

    public UserService(IClientRepository clientRepository, IUserCreditServiceFactory userCreditServiceFactory)
    {
        _clientRepository = clientRepository;
        _userCreditServiceFactory = userCreditServiceFactory;
    }

    public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
    {
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            return false;

        if (!IsValidEmail(email))
            return false;

        if (IsUnderage(dateOfBirth))
            return false;

        var client = _clientRepository.GetById(clientId);

        var user = CreateUser(firstName, lastName, email, dateOfBirth, client);

        if (user.HasCreditLimit && user.CreditLimit < 500)
            return false;

        SaveUser(user);
        return true;
    }

    private bool IsValidEmail(string email)
    {
        return email.Contains("@") && email.Contains(".");
    }

    private bool IsUnderage(DateTime dateOfBirth)
    {
        return DateTime.Now.Year - dateOfBirth.Year < 21;
    }

    private User CreateUser(string firstName, string lastName, string email, DateTime dateOfBirth, Client client)
    {
        var user = new User
        {
            Client = client,
            DateOfBirth = dateOfBirth,
            EmailAddress = email,
            FirstName = firstName,
            LastName = lastName
        };

        if (client.Type == "VeryImportantClient")
        {
            user.HasCreditLimit = false;
        }
        else
        {
            var userCreditService = _userCreditServiceFactory.Create();
            try
            {
                var creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                user.CreditLimit = client.Type == "ImportantClient" ? creditLimit * 2 : creditLimit;
            }
            finally
            {
                if (userCreditService is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
            user.HasCreditLimit = true;
        }

        return user;
    }

    private void SaveUser(User user)
    {
        UserDataAccess.AddUser(user);
    }
}

