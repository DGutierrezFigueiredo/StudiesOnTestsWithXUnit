using Xunit;
using StudiesOnTestsWithXUnit;



namespace BasicTests.Tests
{
    public class StringToolTests
    {
        [Fact]
        public void StringTool_JoinStrings_ShouldReturnFullName()
        {
            //Arrange
            StringTool stringTool = new StringTool();

            //Act
            string fullName = stringTool.JoinStrings("Diego", "Gutierrez");

            //Assert
            Assert.Equal("Diego Gutierrez", fullName);
        }

        [Fact]
        public void JoinStrings_DifferentLetterCases_ShouldntMatter()
        {
            //Arrange
            StringTool stringTool = new StringTool();

            //Act
            string fullName = stringTool.JoinStrings("DIEgO", "gUTIerRez");

            //Assert
            Assert.Equal("DIEGO GUTIERREZ", fullName, true);
        }

        [Fact]
        public void JoinStrings_CheckingForTargetOccuranceWithinString_MustContainOccurance()
        {
            //Arrange
            StringTool stringTool = new StringTool();

            //Act
            string fullName = stringTool.JoinStrings("Diego", "Gutierrez");

            //Assert
            Assert.Contains("ierre", fullName);
        }

        [Fact]
        public void JoinStrings_CheckingOcurranceAtStringStart_MustContainOccurance()
        {
            //Arrange
            StringTool stringTool = new StringTool();

            //Act
            string fullName = stringTool.JoinStrings("Diego", "Gutierrez");

            //Assert
            Assert.StartsWith("Die", fullName);
        }

        [Fact]
        public void JoinStrings_CheckingOccuranceAtStringdEnd()
        {
            //Arrange
            StringTool stringTool = new StringTool();

            //Act
            string fullName = stringTool.JoinStrings("Diego", "Gutierrez");

            //Assert
            Assert.EndsWith("rrez", fullName);
        }

        [Fact]
        public void JoinStrings_UsingRegularExpressions_ShouldMatchRegEx()
        {
            //Arrange
            StringTool stringTool = new StringTool();

            //Act
            string fullName = stringTool.JoinStrings("Diego", "Gutierrez");

            //Assert
            Assert.Matches("^[A-Za-z]+\\s[A-Za-z]+$", fullName);
        }

        [Fact]
        public void JoinStrings_UsingRegularExpressions_ShouldntMatchRegEx()
        {
            //Arrange
            StringTool stringTool = new StringTool();

            //Act
            string fullName = stringTool.JoinStrings("Diego", "Gutierrez89");

            //Assert
            Assert.DoesNotMatch("^[A-Za-z]+\\s[A-Za-z]+$", fullName);
        }

    }
}
