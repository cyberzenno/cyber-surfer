using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CyberSurfer.Data.Interfaces;
using CyberSurfer.Data.Implementations;
using System.Collections.Generic;
using CyberSurfer.Data.Implementations;

namespace CyberSurfer.UnitTests
{
    [TestClass]
    public class SearchAnaliserFixture
    {
        private ISearchAnalyser searchAnalyser;

        [TestInitialize]
        public void Setup()
        {

        }

        [TestMethod]
        public void CountWordsOccurences()
        {
            //Arrange
            var blobToAnalyse = "Hello World. Hello Happy World! hello Happy, World hello Foo bar baz";
            searchAnalyser = new SearchAnalyser(blobToAnalyse);

            //Act
            var analysysResults = searchAnalyser.CountWordsOccurences();

            //Assert
            Assert.IsTrue(analysysResults["hello"] == 4);
            Assert.IsTrue(analysysResults["world"] == 3);
            Assert.IsTrue(analysysResults["happy"] == 2);

            //todo: check out some hardcoded settings in searchAnalyser.CountWordsOccurences
            //Assert.IsTrue(analysysResults["foo"] == 1);
            //Assert.IsTrue(analysysResults["bar"] == 1);
            //Assert.IsTrue(analysysResults["baz"] == 1);
        }


    }
}
