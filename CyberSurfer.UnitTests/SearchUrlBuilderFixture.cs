using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CyberSurfer.Data.Searchers.BingSearcher;
using CyberSurfer.Data.Interfaces;

namespace CyberSurfer.UnitTests
{
    [TestClass]
    public class SearchUrlBuilderFixture
    {
        Mock<IConfigurationProvider> configProvider;
        ISearchUrlBuilder bingSearchUrlBuilder;

        [TestInitialize]
        public void Setup()
        {
            configProvider = new Mock<IConfigurationProvider>();
            configProvider.Setup(c => c.BingSearchBaseUrl).Returns("https://www.bing.com/search");

            bingSearchUrlBuilder = new BingSearchUrlBuilder(configProvider.Object);
        }

        [TestMethod]
        public void BuildSearchUrl_Page1()
        {
            //Arrange
            var expected = "https://www.bing.com/search?q=Hello+World!&first=1";

            //Act
            var actual = bingSearchUrlBuilder.BuildSearchUrl("Hello World!", 1);

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void BuildSearchUrl_Page2()
        {
            //Arrange
            var expected = "https://www.bing.com/search?q=Hello+World!&first=11";

            //Act
            var actual = bingSearchUrlBuilder.BuildSearchUrl("Hello World!", 2);

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void BuildSearchUrl_Page14()
        {
            //Arrange
            var expected = "https://www.bing.com/search?q=Hello+World!&first=131";

            //Act
            var actual = bingSearchUrlBuilder.BuildSearchUrl("Hello World!", 14);

            //Assert
            Assert.AreEqual(actual, expected);
        }
    }
}
