using System;
using System.Collections.Generic;
using System.Text;

namespace ShakePokeAPI.Core.CustomExceptions
{
    public class PokemonCustomException : Exception
    {
        public PokemonCustomException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
