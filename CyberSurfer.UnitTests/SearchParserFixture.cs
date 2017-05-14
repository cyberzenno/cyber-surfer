using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using CyberSurfer.Data.Searchers.BingSearcher;
using CyberSurfer.Data.Interfaces;

namespace CyberSurfer.UnitTests
{
    [TestClass]
    public class SearchParserFixture
    {
        private string BingTestPage = "";

        [TestInitialize]
        public void Setup()
        {
            BingTestPage = File.ReadAllText("TestFiles/BingTestPage.html");
        }

        [TestMethod]
        public void BingSearchParser_Count()
        {
            //Arrange
            var bingSearchParser = new BingSearchParser();

            //Act
            var results = bingSearchParser.Parse(BingTestPage);

            //Assert
            Assert.IsTrue(results.Count() == 10);
        }
    }
}
