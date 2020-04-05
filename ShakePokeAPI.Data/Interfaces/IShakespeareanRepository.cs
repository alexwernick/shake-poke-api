using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShakePokeAPI.Data.Interfaces
{
    public interface IShakespeareanRepository
    {
        Task<string> GetShakespeareanTranslation(string text);
    }
}
