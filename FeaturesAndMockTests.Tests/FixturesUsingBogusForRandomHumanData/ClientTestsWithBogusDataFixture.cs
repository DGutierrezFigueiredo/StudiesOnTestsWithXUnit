using Bogus;
using Bogus.DataSets;
using FeaturesAndMock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FeaturesAndMockTests.Tests.FixturesUsingBogusForRandomHumanData
{
    [CollectionDefinition(nameof(ClientCollectionWithBogus))]
    public class ClientCollectionWithBogus : ICollectionFixture<ClientTestsWithBogusFixture>
    {

    }

    public class ClientTestsWithBogusFixture : IDisposable
    {
        public IEnumerable<Client> GetAssortedClients()
        {
            var clients = new List<Client>();

            clients.AddRange(CreateValidClients(50, true).ToList());
            clients.AddRange(CreateValidClients(50, false).ToList());

            return clients;
        }

        public IEnumerable<Client> CreateValidClients(int quantityOfClients, bool isActive)
        {
            Name.Gender clientGender = new Faker().PickRandom<Name.Gender>();

            Faker<Client> clients = new Faker<Client>("pt_BR")
                .CustomInstantiator(faker => new Client(
                    Guid.NewGuid(),
                    faker.Name.FirstName(clientGender),
                    faker.Name.LastName(clientGender),
                    faker.Date.Past(80, DateTime.Now.AddYears(-18)),
                    "",
                    isActive,
                    DateTime.Now))
                .RuleFor(client => client.Email, (faker, client) =>
                      faker.Internet.Email(client.Name.ToLower(), client.LastName.ToLower()));

            return clients.Generate(quantityOfClients);
        }

        public Client CreateValidClient()
        {
            return CreateValidClients(1, true).FirstOrDefault();
        }

        public Client CreateInvalidClient()
        {
            Client invalidClient = new Client(
                Guid.NewGuid(),
                "",
                "",
                DateTime.Now,
                "diego@email.com",
                true,
                DateTime.Now);
            return invalidClient;
        }

        public void Dispose()
        {

        }
    }
}
