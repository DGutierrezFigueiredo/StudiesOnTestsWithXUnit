using FeaturesAndMock.Domain.Entities;
using System;
using Xunit;

namespace FeaturesAndMockTests.Tests.Fixtures
{

    [CollectionDefinition(nameof(ClientCollection))]
    public class ClientCollection : ICollectionFixture<ClientTestsFixture>
    {

    }
    
    public class ClientTestsFixture : IDisposable
    {
        public Client CreateValidClient()
        {
            Client validClient = new Client(
                Guid.NewGuid(),
                "Diego",
                "Gutierrez",
                DateTime.Now.AddYears(-40),
                "diego@email.com",
                true,
                DateTime.Now
                );
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
