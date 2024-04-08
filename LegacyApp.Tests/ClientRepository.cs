﻿namespace LegacyApp.Tests;

public class ClientRepository : IClientRepository
{
    public Client GetById(int clientId)
    {
        int randomWaitTime = new Random().Next(2000);
        Thread.Sleep(randomWaitTime);

        var database = new Dictionary<int, Client>()
        {
            {1, new Client{ClientId = 1, Name = "Kowalski", Address = "Warszawa, Złota 12", Email = "kowalski@wp.pl", Type = "NormalClient"}},
            {2, new Client{ClientId = 2, Name = "Malewski", Address = "Warszawa, Koszykowa 86", Email = "malewski@gmail.pl", Type = "VeryImportantClient"}},
            {3, new Client{ClientId = 3, Name = "Smith", Address = "Warszawa, Kolorowa 22", Email = "smith@gmail.pl", Type = "ImportantClient"}},
            {4, new Client{ClientId = 4, Name = "Doe", Address = "Warszawa, Koszykowa 32", Email = "doe@gmail.pl", Type = "ImportantClient"}},
            {5, new Client{ClientId = 5, Name = "Kwiatkowski", Address = "Warszawa, Złota 52", Email = "kwiatkowski@wp.pl", Type = "NormalClient"}},
            {6, new Client{ClientId = 6, Name = "Andrzejewicz", Address = "Warszawa, Koszykowa 52", Email = "andrzejewicz@wp.pl", Type = "NormalClient"}}
        };

        if (database.ContainsKey(clientId))
            return database[clientId];

        throw new ArgumentException($"User with id {clientId} does not exist in database");
    }
}
