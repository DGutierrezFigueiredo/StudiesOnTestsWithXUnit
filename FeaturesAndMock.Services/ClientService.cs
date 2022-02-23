using FeaturesAndMock.Domain.Interfaces;
using FeaturesAndMock.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using MediatR;

namespace FeaturesAndMock.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repositoryClient;
        private readonly IMediator _mediator;

        public ClientService(IClientRepository repositoryClient,
                              IMediator mediator)
        {
            _repositoryClient = repositoryClient;
            _mediator = mediator;
        }

        public IEnumerable<Client> GetAllActiveClients()
        {
            return _repositoryClient.GetallClients().Where(c => c.IsActive);
        }

        public void AddClient(Client client)
        {
            if (!client.IsValidClient())
                return;

            _repositoryClient.AddClient(client);
            _mediator.Publish(new ClientEmailNotification("admin@me.com", client.Email, "Hello", "Welcome!"));
        }

        public void UpdateClient(Client client)
        {
            if (!client.IsValidClient())
                return;

            _repositoryClient.UpdateClient(client);
            _mediator.Publish(new ClientEmailNotification("admin@me.com", client.Email, "Changes", "Check it out!"));
        }

        public void MakeClientInactive(Client client)
        {
            if (!client.IsValidClient())
                return;

            client.MakeInactive();
            _repositoryClient.UpdateClient(client);
            _mediator.Publish(new ClientEmailNotification("admin@me.com", client.Email, "So long", "I see you later!"));
        }

        public void RemoveClient(Client client)
        {
            _repositoryClient.RemoveClient(client.Id);
            _mediator.Publish(new ClientEmailNotification("admin@me.com", client.Email, "Goodbye", "Have a nice life!"));
        }

        public void Dispose()
        {
            _repositoryClient.Dispose();
        }
    }
}
