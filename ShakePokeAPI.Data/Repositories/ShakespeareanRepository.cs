using ShakePokeAPI.Clients.Interfaces;
using ShakePokeAPI.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShakePokeAPI.Data.Repositories
{
    public class ShakespeareanRepository : IShakespeareanRepository
    {
        private readonly IFunTranslationsClient _client;

        public ShakespeareanRepository(IFunTranslationsClient client)
        {
            this._client = client;
        }

        public async Task<string> GetShakespeareanTranslation(string text)
        {
            var translation = await _client.GetShakespeareanTranslation(text);

            return translation != null 
                && translation.Contents != null
                && !string.IsNullOrEmpty(translation.Contents.Translated)
                ? translation.Contents.Translated
                : string.Empty;
        }
    }
}
