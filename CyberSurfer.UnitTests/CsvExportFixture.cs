using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CyberSurfer.Data.Utilities;
using CyberSurfer.Data.Implementations;
using CyberSurfer.Data.Interfaces;

namespace CyberSurfer.UnitTests
{
    [TestClass]
    public class CsvExportFixture
    {
        private CsvExport csvExport;
        private const string winLB = "\r\n";

        [TestInitialize]
        public void SetUp()
        {
            csvExport = new CsvExport();
        }

        [TestMethod]
        public void CsvExport_SingleObject()
        {
            var id = 1;
            var title = "Hello World!";
            var url = "http://hello.world.com";
            var summary = "Hello World Summary!";

            //Arrange
            var searchResult = new SearchResult() { Id = id, Url = url, Title = title, Summary = summary };
            var searchResults = new List<ISearchResult>() { searchResult };

            var expectedCsvResult = "Id,Url,Title,Summary" + winLB + "1,http://hello.world.com,Hello World!,Hello World Summary!" + winLB;

            //Act
            csvExport.AddRows<ISearchResult>(searchResults);
            var csvResult = csvExport.Export();

            //Assert
            Assert.AreEqual(csvResult, expectedCsvResult);
        }

        [TestMethod]
        public void CsvExport_MultipleObjects()
        {
            var id = 1;
            var title = "Hello World!";
            var url = "http://hello.world.com";
            var summary = "Hello World Summary!";

            //Arrange
            var searchResult1 = new SearchResult() { Id = id, Url = url, Title = title, Summary = summary };
            var searchResult2 = new SearchResult() { Id = id + 1, Url = url, Title = title, Summary = summary };
            var searchResults = new List<ISearchResult>() { searchResult1, searchResult2 };

            var expectedCsvResult = "Id,Url,Title,Summary" + winLB + "1,http://hello.world.com,Hello World!,Hello World Summary!" + winLB + "2,http://hello.world.com,Hello World!,Hello World Summary!" + winLB;

            //Act
            csvExport.AddRows<ISearchResult>(searchResults);
            var csvResult = csvExport.Export();

            //Assert
            Assert.AreEqual(csvResult, expectedCsvResult);
        }
    }
}
