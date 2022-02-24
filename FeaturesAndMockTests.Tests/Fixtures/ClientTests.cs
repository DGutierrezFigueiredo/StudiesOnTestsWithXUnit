using FeaturesAndMock.Domain.Entities;
using System;
using Xunit;

namespace FeaturesAndMockTests.Tests.Fixtures
{
    [Collection(nameof(ClientCollection))]
    public class ClientValidationTests
    {
        private readonly ClientTestsFixture _clientTestsFixture;
        public ClientValidationTests(ClientTestsFixture clientTestsFixture)
        {
            _clientTestsFixture = clientTestsFixture;

        }

        [Fact(DisplayName = "Client is Valid")]
        [Trait("Category", "Fixtures")]
        public void Client_ClientIsValid()
        {
            //Arrange 
            Client newClient = _clientTestsFixture.CreateValidClient();

            //Act

            bool result = newClient.IsValidClient();

            //Assert
            Assert.True(result);
            Assert.Equal(0, newClient.ValidationResult.Errors.Count);

            
        }

        [Fact(DisplayName = "Client is Invalid")]
        [Trait("Category", "Fixtures")]
        public void Client_ClientIsInvalid()
        {
            //Arrange
            Client newClient = _clientTestsFixture.CreateInvalidClient();

            //Act
            bool result = newClient.IsValidClient();

            //Assert
            Assert.False(result);
            Assert.NotEqual(0, newClient.ValidationResult.Errors.Count);
        }

    }
}
