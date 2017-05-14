using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CyberSurfer.Data.Interfaces;
using Moq;
using CyberSurfer.Data.Implementations;
using System.Collections.Generic;

namespace CyberSurfer.UnitTests
{
    [TestClass]
    public class SearchServiceFixture
    {
        private Mock<ISearchUrlBuilder> searchUrlBuilder;
        private Mock<ISearchWebClient> searchWebClient;
        private Mock<ISearchParser> searchParser;
        private ISearchService searchService;

        //public SearchService(ISearchUrlBuilder searchUrlBuilder, ISearchWebClient searchWebClient, ISearchParser searchParser)
        //{
        //    this.searchUrlBuilder = searchUrlBuilder;
        //    this.searchWebClient = searchWebClient;
        //    this.searchParser = searchParser;
        //}

        [TestInitialize]
        public void Setup()
        {
            //TODO: note
            searchUrlBuilder = new Mock<ISearchUrlBuilder>();
           

            searchWebClient = new Mock<ISearchWebClient>();
          

            searchParser = new Mock<ISearchParser>();
          

            searchService = new SearchService(searchUrlBuilder.Object, searchWebClient.Object, searchParser.Object);
        }

        [TestMethod]
        public void SearchService_Search()
        {
            //Arrange

            //TODO: Note Just an example of input/output mock
            searchUrlBuilder.Setup(s => s.BuildSearchUrl(It.IsAny<string>(), It.IsAny<int>())).Returns("test").Verifiable();
            searchWebClient.Setup(s => s.Search(It.IsAny<string>())).Returns("test").Verifiable();
            searchParser.Setup(s => s.Parse(It.IsAny<string>())).Returns(new List<ISearchResult>()).Verifiable();

            //Act
            searchService.Search("Hello World!");

            //Assert

            //We just check if the methods has been called.
            //At the moment there is no logic in Search
            searchUrlBuilder.VerifyAll();
            searchWebClient.VerifyAll();
            searchParser.VerifyAll();
        }

        //TODO: mock and implement the tests below

        [TestMethod]
        public void SearchService_SearchFull_LessThan100()
        {
            //Arrange

            //Act
           
            //Assert
        }

        [TestMethod]
        public void SearchService_SearchFull_MoreThan100()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}
