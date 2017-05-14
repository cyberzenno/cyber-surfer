using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CyberSurfer.Data.Implementations;
using CyberSurfer.Data.Utilities;

namespace CyberSurfer.UnitTests
{
    [TestClass]
    public class CustomUtilitiesFixture
    {
        [TestMethod]
        public void StripTagsRegexCompiled_NoTags()
        {
            //Arrange
            var stringToParse = "Hello World!";

            //Act
            var strippedString = CustomUtlities.StripTagsRegexCompiled(stringToParse);

            //Assert
            Assert.AreEqual(stringToParse, strippedString);
        }

        [TestMethod]
        public void StripTagsRegexCompiled_WithTags()
        {
            //Arrange
            var stringToParse = "<html>Hello <strong>World!</strong></html>";
            var expectedString = "Hello World!";

            //Act
            var strippedString = CustomUtlities.StripTagsRegexCompiled(stringToParse);

            //Assert
            Assert.AreEqual(strippedString, expectedString);
        }
    }
}
