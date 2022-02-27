using Bogus;
using Bogus.DataSets;
using FeaturesAndMock.Domain.Entities;
using System;
using Xunit;

namespace FeaturesAndMockTests.Tests.FixturesUsingBogusForRandomHumanData
{
    [CollectionDefinition(nameof(ClientCollectionWithBogus))]
    public class ClientCollectionWithBogus : ICollectionFixture<ClientTestsWithBogusFixture>
    {

    }

    public class ClientTestsWithBogusFixture : IDisposable
    {
        public Client CreateValidClient()
        {
            Name.Gender clientGender = new Faker().PickRandom<Name.Gender>();

            var validClient = new Faker<Client>("pt_BR")
                .CustomInstantiator(faker => new Client(
                Guid.NewGuid(),
                faker.Name.FirstName(clientGender),
                faker.Name.LastName(clientGender),
                faker.Date.Past(80, DateTime.Now.AddYears(-18)),
                "",
                true,
                DateTime.Now))
                .RuleFor(client => client.Email, (faker, client) =>
                      faker.Internet.Email(client.Name.ToLower(), client.LastName.ToLower()));

            return validClient;
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
