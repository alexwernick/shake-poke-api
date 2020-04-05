using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShakePokeAPI.Clients.Clients;
using System;

namespace ShakePokeAPI.Clients.Tests
{
    [TestClass]
    public class FunTranslationsClientTests
    {

        private readonly FunTranslationsClient _funTranslationsClient;
        private const string _funTranslationsSrc = "https://api.funtranslations.com/translate/";

        public FunTranslationsClientTests()
        {
            _funTranslationsClient = new FunTranslationsClient(new System.Net.Http.HttpClient()
            {
                BaseAddress = new Uri(_funTranslationsSrc)
            });
        }

        [TestMethod]
        public void GetShakespeareanTranslation_SendMockText_SuccessfulResponse()
        {
            var translation = _funTranslationsClient.GetShakespeareanTranslation("lorem ipsum").Result;

            Assert.AreEqual(translation.Success.Total, 1, "Translation was not successful");
            Assert.IsTrue(!string.IsNullOrEmpty(translation.Contents.Translated), "Translated text should not be null or empty");
        }


    }
}
