
using Xunit;
using Moq;
using FeaturesAndMockTests.Tests.FixturesUsingBogusForRandomHumanData;
using FeaturesAndMock.Domain.Entities;
using FeaturesAndMock.Domain.Interfaces;
using MediatR;
using FeaturesAndMock.Services;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace FeaturesAndMockTests.Tests.Mock
{
    [Collection(nameof(ClientCollectionWithBogus))]
    public class ClientServiceTestsWithMock
    {
        private readonly ClientTestsWithBogusFixture _clientTestsWithBogusDataFixture;
        public ClientServiceTestsWithMock(ClientTestsWithBogusFixture clientTestsWithBogusFixture)
        {
            _clientTestsWithBogusDataFixture = clientTestsWithBogusFixture;
        }

        [Fact(DisplayName = "Successfully Add Client To Repository")]
        [Trait("Category", "Mock and Bogus")]
        public void ClientService_AddClient_ShouldSucceedInAddingClientToRepo()
        {
            //Arrange
            Client newClient = _clientTestsWithBogusDataFixture.CreateValidClient();
            Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
            Mock<IMediator> mediator = new Mock<IMediator>();

            ClientService clientService = new ClientService(clientRepository.Object, mediator.Object);

            //Act
            clientService.AddClient(newClient);

            //Assert
            Assert.True(newClient.IsValidClient());
            clientRepository.Verify(repo => repo.AddClient(newClient), Times.Once);
            mediator.Verify(mediator => mediator.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
        }

        [Fact(DisplayName = "Invalid Client Should Not Be Added to Repository")]
        [Trait("Category", "Mock and Bogus")]
        public void ClientService_AddClient_InvalidClientShouldNotBeAddedToRepository()
        {
            //Arrange
            Client newInvalidClient = _clientTestsWithBogusDataFixture.CreateInvalidClient();
            Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
            Mock<IMediator> mediator = new Mock<IMediator>();

            ClientService clientService = new ClientService(clientRepository.Object, mediator.Object);

            //Act
            clientService.AddClient(newInvalidClient);

            //Assert
            Assert.False(newInvalidClient.IsValidClient());
            clientRepository.Verify(repo => repo.AddClient(newInvalidClient), Times.Never);
            mediator.Verify(mediator => mediator.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never);

        }

        [Fact(DisplayName = "Get All Active Clients")]
        [Trait("Category", "Mock and Bogus")]
        public void ClientService_GetAllActiveClients_ShouldOnlyReturnActiveClients()
        {
            //Arrange

            Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
            Mock<IMediator> mediator = new Mock<IMediator>();

            clientRepository.Setup(repo => repo.GetallClients())
                .Returns(_clientTestsWithBogusDataFixture.GetAssortedClients());

            ClientService clientService = new ClientService(clientRepository.Object, mediator.Object);

            //Act
            IEnumerable<Client> resultOfClients = clientService.GetAllActiveClients();

            //Assert
            clientRepository.Verify(repo => repo.GetallClients(), Times.Once);
            Assert.True(resultOfClients.Any());
            Assert.True(resultOfClients.Count(client => client.IsActive) > 0);
            Assert.False(resultOfClients.Count(client => !client.IsActive) > 0);
            
        }

    }

    
}
