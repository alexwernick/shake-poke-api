using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShakePokeAPI.Clients.Clients;
using ShakePokeAPI.Core.CustomExceptions;
using ShakePokeAPI.External.Dto.PokeAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShakePokeAPI.Clients.Tests
{
    [TestClass]
    public class PokeAPIClientTests
    {
        private readonly PokeAPIClient _pokeAPIClient;
        private const string _pokeAPISrc = "https://pokeapi.co/api/v2/";

        public PokeAPIClientTests()
        {
            _pokeAPIClient = new PokeAPIClient(new System.Net.Http.HttpClient()
            {
                BaseAddress = new Uri(_pokeAPISrc)
            });
        }

        [TestMethod]
        public void GetPokemonByName_SendInvalidPokemon_PokemonCustomException()
        {
            string fakePokemonName = "zqzqzqzqz";
            PokemonDto pokemon = null;

            Assert.ThrowsException<AggregateException>(() => _pokeAPIClient.GetPokemonByName(fakePokemonName).Result);

            try
            {            
                pokemon = _pokeAPIClient.GetPokemonByName(fakePokemonName).Result;
            }
            catch(Exception ex)
            {
                Assert.IsTrue(ex.InnerException is PokemonCustomException);
            }
           
        }

        [TestMethod]
        public void GetPokemonByName_SendValidPokemon_SucessfulResponse()
        {
            string pokemonName = "Pikachu";
            PokemonDto pokemon = _pokeAPIClient.GetPokemonByName(pokemonName).Result;

            Assert.AreEqual(pokemon.Name.ToLower().Trim(), pokemonName.ToLower().Trim(), "Name incorrect");
        }

        [TestMethod]
        public void GetPokemonSpeciesByName_SendInvalidPokemonSpecies_PokemonCustomException()
        {
            string fakePokemonSpeciesName = "zqzqzqzqz";
            PokemonSpeciesDto pokemonSpecies = null;

            Assert.ThrowsException<AggregateException>(() => _pokeAPIClient.GetPokemonSpeciesByName(fakePokemonSpeciesName).Result);

            try
            {
                pokemonSpecies = _pokeAPIClient.GetPokemonSpeciesByName(fakePokemonSpeciesName).Result;
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.InnerException is PokemonCustomException);
            }

        }

        [TestMethod]
        public void GetPokemonSpeciesByName_SendValidPokemonSpecies_SucessfulResponse()
        {
            string pokemonSpeciesName = "Pikachu";
            PokemonSpeciesDto pokemonSpecies = _pokeAPIClient.GetPokemonSpeciesByName(pokemonSpeciesName).Result;

            Assert.AreEqual(pokemonSpecies.Name.ToLower().Trim(), pokemonSpeciesName.ToLower().Trim(), "Name incorrect");
        }
    }
}
