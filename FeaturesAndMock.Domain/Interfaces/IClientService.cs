using FeaturesAndMock.Domain.Entities;
using System;
using System.Collections.Generic;


namespace FeaturesAndMock.Domain.Interfaces
{
    public interface IClientService : IDisposable
    {
        IEnumerable<Client> GetAllActiveClients();
        void AddClient(Client client);
        void UpdateClient(Client client);
        void RemoveClient(Client client);
        void MakeClientInactive(Client client);
    }
}
