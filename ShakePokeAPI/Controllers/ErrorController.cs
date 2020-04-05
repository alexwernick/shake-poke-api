using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShakePokeAPI.Core.CustomExceptions;

namespace ShakePokeAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error-local-development")]
        public IActionResult ErrorLocalDevelopment()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            return StatusCode(500, new
            {
                errorMessage = context.Error.Message,
                detail = context.Error.StackTrace
            });
        }

        [Route("/error")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            List<Exception> exceptions = new List<Exception>();

            if (context.Error is AggregateException
                && ((AggregateException)context.Error).InnerExceptions.Any())
                exceptions.AddRange(((AggregateException)context.Error).InnerExceptions);          
            else
                exceptions.Add(context.Error);

            foreach (var e in exceptions)
            {
                if (e is PokemonCustomException
                    || e is TranslationCustomException)
                {
                    return StatusCode(500, new
                    {
                        errorMessage = e.Message
                    });
                }
            }

            return StatusCode(500, new
            {
                errorMessage = "Internal server error"
            }
           );
        }
    }
}