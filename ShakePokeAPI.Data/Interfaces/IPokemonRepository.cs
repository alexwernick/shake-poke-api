using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShakePokeAPI.Data.Interfaces
{
    public interface IPokemonRepository
    {
        Task<string> GetDescriptionByName(string name);
    }
}
