using ShakePokeAPI.External.Dto.FunTranslations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShakePokeAPI.Clients.Interfaces
{
    public interface IFunTranslationsClient
    {
        Task<TranslationDto> GetShakespeareanTranslation(string text);
    }
}
