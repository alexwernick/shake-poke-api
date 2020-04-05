using System;
using System.Collections.Generic;
using System.Text;

namespace ShakePokeAPI.Core.CustomExceptions
{
    public class TranslationCustomException : Exception
    {
        public TranslationCustomException(string message, Exception innerException)
           : base(message, innerException)
        {

        }
    }
}
