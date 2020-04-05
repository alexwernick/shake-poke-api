using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShakePokeAPI.Clients.Interfaces;
using ShakePokeAPI.Data.Repositories;
using ShakePokeAPI.External.Dto.FunTranslations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShakePokeAPI.Data.Tests
{
    [TestClass]
    public class ShakespeareanRepositoryTests
    {
        private readonly ShakespeareanRepository _shakespeareanRepository;

        public ShakespeareanRepositoryTests()
        {
            _shakespeareanRepository = new ShakespeareanRepository(new FakeFunTranslationsClient());
        }

        [TestMethod]
        public void GetShakespeareanTranslation_Text_SucessfulResponse()
        {
            string text = _shakespeareanRepository.GetShakespeareanTranslation("Lorum ipsum").Result;
            Assert.IsTrue(!string.IsNullOrEmpty(text));
        }

        private class FakeFunTranslationsClient : IFunTranslationsClient
        {
            public async Task<TranslationDto> GetShakespeareanTranslation(string text)
            {
                return new TranslationDto()
                {
                    Contents = new ContentsDto()
                    {
                        Text = text,
                        Translated = text
                    }
                };
            }
        }
    }
}
