using ShakePokeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShakePokeAPI.Interfaces.Services
{
    public interface IShakePokeService
    {
        Task<ShakespeareanPokemon> GetByPokemonName(string name);
    }
}
