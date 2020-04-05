using ShakePokeAPI.External.Dto.PokeAPI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShakePokeAPI.Clients.Interfaces
{
    public interface IPokeAPIClient
    {
        Task<PokemonDto> GetPokemonByName(string name);
        Task<PokemonSpeciesDto> GetPokemonSpeciesByName(string name);
    }
}
