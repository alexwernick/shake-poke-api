using ShakePokeAPI.Clients.Interfaces;
using ShakePokeAPI.Core.CustomExceptions;
using ShakePokeAPI.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShakePokeAPI.Data.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly IPokeAPIClient _client;

        public PokemonRepository(IPokeAPIClient client)
        {
            this._client = client;
        }

        public async Task<string> GetDescriptionByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentOutOfRangeException("name", "name should not be null or empty");

            var pokemon = await _client.GetPokemonByName(name);

            if (pokemon == null)
                throw new PokemonCustomException($"Pokemon {name} does not exist", null);

            var pokemonSpecies = await _client.GetPokemonSpeciesByName(pokemon.Species.Name);

            if (pokemonSpecies == null)
                throw new PokemonCustomException($"Pokemon species {name} does not exist", null);

            if (pokemonSpecies.Flavor_Text_Entries == null
                || !pokemonSpecies.Flavor_Text_Entries.Any())
                return String.Empty;

            return pokemonSpecies.Flavor_Text_Entries
                .Where(obj => obj.Language.Name == "en")
                .Select(obj => obj.Flavor_Text)
                .FirstOrDefault();
        }
    }
}
