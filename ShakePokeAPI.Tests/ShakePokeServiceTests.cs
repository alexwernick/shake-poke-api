using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShakePokeAPI.Data.Interfaces;
using ShakePokeAPI.Services;
using System.Threading.Tasks;

namespace ShakePokeAPI.Tests
{
    [TestClass]
    public class ShakePokeServiceTests
    {
        private const string _validPokemonName = "Pikachu";
        private const string _validPokemonDescription = "Lorum ipsum";
        private const string _validPokemonTranslatedDescription = "Shake dorum";

        private readonly ShakePokeService _shakePokeService;


        public ShakePokeServiceTests()
        {
            _shakePokeService = new ShakePokeService(new FakePokemonRepository()
                , new FakeShakespeareanRepository());
        }

        [TestMethod]
        public void GetByPokemonName_ValidPokemon_SucessfulResponse()
        {
            var pokemon = _shakePokeService.GetByPokemonName(_validPokemonName).Result;

            Assert.AreEqual(pokemon.Name, _validPokemonName);
            Assert.AreEqual(pokemon.Description, _validPokemonTranslatedDescription);
        }

        private class FakePokemonRepository : IPokemonRepository
        {
            public async Task<string> GetDescriptionByName(string name)
            {
                return _validPokemonDescription;
            }
        }

        private class FakeShakespeareanRepository : IShakespeareanRepository
        {
            public async Task<string> GetShakespeareanTranslation(string text)
            {
                return _validPokemonTranslatedDescription;
            }
        }
    }
}
