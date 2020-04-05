using ShakePokeAPI.Data.Interfaces;
using ShakePokeAPI.Domain;
using ShakePokeAPI.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShakePokeAPI.Services
{
    public class ShakePokeService : IShakePokeService
    {

        private readonly IPokemonRepository _pokemonRepository;
        private readonly IShakespeareanRepository _shakespeareanRepository;

        public ShakePokeService(IPokemonRepository pokemonRepository,
            IShakespeareanRepository shakespeareanRepository)
        {
            this._pokemonRepository = pokemonRepository;
            this._shakespeareanRepository = shakespeareanRepository;
        }

        public async Task<ShakespeareanPokemon> GetByPokemonName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentOutOfRangeException("name", "name should not be null or empty");

            string pokemonDescription = await _pokemonRepository.GetDescriptionByName(name);

            string shakespeareanPokemonDescription = await _shakespeareanRepository.GetShakespeareanTranslation(pokemonDescription);

            return new ShakespeareanPokemon()
            {
                Name = name,
                Description = shakespeareanPokemonDescription
            };

        }
    }
}
