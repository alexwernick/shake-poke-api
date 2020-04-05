using Newtonsoft.Json;
using ShakePokeAPI.Clients.Interfaces;
using ShakePokeAPI.Core.CustomExceptions;
using ShakePokeAPI.External.Dto.FunTranslations;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShakePokeAPI.Clients.Clients
{
    public class FunTranslationsClient : IFunTranslationsClient
    {
        private readonly HttpClient _httpClient;

        public FunTranslationsClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TranslationDto> GetShakespeareanTranslation(string text)
        {
            HttpResponseMessage response = null;
            try
            {
                response = await _httpClient.PostAsync($"shakespeare.json", new StringContent(JsonConvert.SerializeObject(new { text = text }), Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                var translation = JsonConvert.DeserializeObject<TranslationDto>(content);
                return translation;
            }
            catch(Exception ex)
            {
                if (response != null 
                    && response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                {
                    throw new TranslationCustomException($"You have reached your translation request limit", ex);
                }
                throw ex;
            }
                       
        }
    }
}
