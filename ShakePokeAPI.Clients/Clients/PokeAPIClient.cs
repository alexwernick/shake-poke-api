using Newtonsoft.Json;
using ShakePokeAPI.Clients.Interfaces;
using ShakePokeAPI.Core.CustomExceptions;
using ShakePokeAPI.External.Dto.PokeAPI;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShakePokeAPI.Clients.Clients
{
    public class PokeAPIClient : IPokeAPIClient
    {
        private readonly HttpClient _httpClient;

        public PokeAPIClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PokemonDto> GetPokemonByName(string name)
        {
            HttpResponseMessage response = null;
            try
            {
                name = string.IsNullOrEmpty(name) ? name : name.ToLower().Trim();
                response = await _httpClient.GetAsync($"pokemon/{name}");
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                var pokemon = JsonConvert.DeserializeObject<PokemonDto>(responseString);
                return pokemon;
            }
            catch (Exception ex)
            {
                if (response != null
                    && response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new PokemonCustomException($"Pokemon {name} does not exist", ex);
                }
                throw ex;
            }
        }

        public async Task<PokemonSpeciesDto> GetPokemonSpeciesByName(string name)
        {
            HttpResponseMessage response = null;
            try
            {
                name = string.IsNullOrEmpty(name) ? name : name.ToLower().Trim();
                response = await _httpClient.GetAsync($"pokemon-species/{name}");
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                var pokemonSpecies = JsonConvert.DeserializeObject<PokemonSpeciesDto>(responseString);
                return pokemonSpecies;
            }
            catch (Exception ex)
            {
                if (response != null
                    && response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new PokemonCustomException($"Pokemon species {name} does not exist", ex);
                }
                throw ex;
            }
        }

    }
}
