using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShakePokeAPI.Clients.Interfaces;
using ShakePokeAPI.Core.CustomExceptions;
using ShakePokeAPI.Data.Repositories;
using ShakePokeAPI.External.Dto.PokeAPI;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShakePokeAPI.Data.Tests
{
    [TestClass]
    public class PokemonRepositoryTests
    {
        private readonly PokemonRepository _pokemonRepository;
        private const string _validPokemonName = "Pikachu";
        private const string _invalidPokemonName = "zqzqzqzqz";
        private const string _validPokemonSpeciesName = "Pikachu";

        public PokemonRepositoryTests()
        {
            _pokemonRepository = new PokemonRepository(new FakePokeAPIClient());
        }

        [TestMethod]
        public void GetDescriptionByName_ValidPokemon_SucessfulResponse()
        {
            string description = _pokemonRepository.GetDescriptionByName(_validPokemonName).Result;
            Assert.IsTrue(!string.IsNullOrEmpty(description));
        }

        [TestMethod]
        public void GetDescriptionByName_InvalidPokemon_AggregateException()
        {
            Assert.ThrowsException<AggregateException>(() => _pokemonRepository.GetDescriptionByName(_invalidPokemonName).Result);
        }

        private class FakePokeAPIClient : IPokeAPIClient
        {
            public async Task<PokemonDto> GetPokemonByName(string name)
            {
                if (name == _validPokemonName)
                {
                    return new PokemonDto()
                    {
                        Name = name,
                        Species = new SpeciesDto()
                        {
                            Name = _validPokemonSpeciesName
                        }
                    };
                }
                else
                    throw new PokemonCustomException("error", null);
            }

            public async Task<PokemonSpeciesDto> GetPokemonSpeciesByName(string name)
            {
                if (name == _validPokemonSpeciesName)
                {
                    return new PokemonSpeciesDto()
                    {
                        Name = name,
                        Flavor_Text_Entries = new List<FlavourTextEntriesDto>()
                        {
                            new FlavourTextEntriesDto()
                            {
                                Flavor_Text = "Lorem ipsum",
                                Language = new LanguageDto()
                                {
                                    Name = "en"
                                }
                            }                   
                        }
                    };
                }
                else
                    throw new PokemonCustomException("error", null);
            }
        }
    }
}
