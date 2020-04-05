using System;
using System.Collections.Generic;
using System.Text;

namespace ShakePokeAPI.External.Dto.PokeAPI
{
    public class PokemonDto
    {
        public string Name { get; set; }
        public SpeciesDto Species { get; set; }
    }
}