namespace LegacyApp.Tests;

public interface IClientRepository
{
    Client GetById(int clientId);
}