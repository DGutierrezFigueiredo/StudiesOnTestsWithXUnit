
using FeaturesAndMock.Domain.Entities;
using Xunit;

namespace FeaturesAndMockTests.Tests.FixturesUsingBogusForRandomHumanData
{
    [Collection(nameof(ClientCollectionWithBogus))]
    public class ClientValidationTests
    {
        private readonly ClientTestsWithBogusFixture _clientTestsFixtureWithBogus;
        public ClientValidationTests(ClientTestsWithBogusFixture clientTestsFixtureWithBogus)
        {
            _clientTestsFixtureWithBogus = clientTestsFixtureWithBogus;

        }

        [Fact(DisplayName = "Client is Valid with Bogus")]
        [Trait("Category", "Using Bogus For Random Human Info")]
        public void Client_ClientIsValid()
        {
            //Arrange 
            Client newClient = _clientTestsFixtureWithBogus.CreateValidClient();

            //Act

            bool result = newClient.IsValidClient();

            //Assert
            Assert.True(result);
            Assert.Empty(newClient.ValidationResult.Errors);

        }

        [Fact(DisplayName = "Client is Invalid")]
        [Trait("Category", "Using Bogus For Random Human Info")]
        public void Client_ClientIsInvalid()
        {
            //Arrange
            Client newClient = _clientTestsFixtureWithBogus.CreateInvalidClient();

            //Act
            bool result = newClient.IsValidClient();

            //Assert
            Assert.False(result);
            Assert.NotEmpty(newClient.ValidationResult.Errors);
        }

    }
}
