
using System;
using System.Collections.Generic;
using System.Text;

namespace ShakePokeAPI.External.Dto.PokeAPI
{
    public class PokemonSpeciesDto
    {
        public string Name { get; set; }
        public IList<FlavourTextEntriesDto> Flavor_Text_Entries { get; set; }

        public PokemonSpeciesDto()
        {
            this.Flavor_Text_Entries = new List<FlavourTextEntriesDto>();
        }
    }
}

