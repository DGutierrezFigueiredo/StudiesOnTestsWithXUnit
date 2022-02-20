using Xunit;
using StudiesOnTestsWithXUnit;



namespace BasicTests.Tests
{
    public class StringToolTests
    {
        //Strings
        [Fact(DisplayName = "Join Method should work correctly - Strings")]
        [Trait("Category", "StringTool")]
        public void StringTool_JoinStrings_ShouldReturnFullName()
        {
            //Arrange
            StringTool stringTool = new StringTool();

            //Act
            string fullName = stringTool.JoinStrings("Diego", "Gutierrez");

            //Assert
            Assert.Equal("Diego Gutierrez", fullName);
        }

        [Fact(DisplayName = "Join Method Assertion should not be case sensitive - Strings")]
        [Trait("Category", "StringTool")]
        public void JoinStrings_DifferentLetterCases_CasesShouldNotMatter()
        {
            //Arrange
            StringTool stringTool = new StringTool();

            //Act
            string fullName = stringTool.JoinStrings("DIEgO", "gUTIerRez");

            //Assert
            Assert.Equal("DIEGO GUTIERREZ", fullName, true);
        }

        [Fact(DisplayName = "Must contain part of a string any where assertion - Strings")]
        [Trait("Category", "StringTool")]
        public void JoinStrings_CheckingForTargetOccuranceWithinString_MustContainOccurance()
        {
            //Arrange
            StringTool stringTool = new StringTool();

            //Act
            string fullName = stringTool.JoinStrings("Diego", "Gutierrez");

            //Assert
            Assert.Contains("ierre", fullName);
        }

        [Fact(DisplayName = "Must contain part of a string at the Start assertion - Strings")]
        [Trait("Category", "StringTool")]
        public void JoinStrings_CheckingOcurranceAtStringStart_MustContainOccurance()
        {
            //Arrange
            StringTool stringTool = new StringTool();

            //Act
            string fullName = stringTool.JoinStrings("Diego", "Gutierrez");

            //Assert
            Assert.StartsWith("Die", fullName);
        }

        [Fact(DisplayName = "Must contain part of a string at the End assertion - Strings")]
        [Trait("Category", "StringTool")]
        public void JoinStrings_CheckingOcurranceAtStringEnd_MustContainOccurance()
        {
            //Arrange
            StringTool stringTool = new StringTool();

            //Act
            string fullName = stringTool.JoinStrings("Diego", "Gutierrez");

            //Assert
            Assert.EndsWith("rrez", fullName);
        }

        [Fact(DisplayName = "Assertion matching RegEx - Strings")]
        [Trait("Category", "StringTool")]
        public void JoinStrings_UsingRegularExpressions_ShouldMatchRegEx()
        {
            //Arrange
            StringTool stringTool = new StringTool();

            //Act
            string fullName = stringTool.JoinStrings("Diego", "Gutierrez");

            //Assert
            Assert.Matches("^[A-Za-z]+\\s[A-Za-z]+$", fullName);
        }

        [Fact(DisplayName = "Assertion can't match RegEx - Strings")]
        [Trait("Category", "StringTool")]
        public void JoinStrings_UsingRegularExpressions_ShouldNotMatchRegEx()
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
