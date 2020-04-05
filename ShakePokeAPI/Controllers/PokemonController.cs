using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShakePokeAPI.Core.CustomExceptions;
using ShakePokeAPI.Domain;
using ShakePokeAPI.Interfaces.Services;

namespace ShakePokeAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {

        private readonly IShakePokeService _shakePokeService;

        public PokemonController(IShakePokeService shakePokeService)
        {
            this._shakePokeService = shakePokeService;
        }

        [HttpGet("{name}")]
        public ActionResult<ShakespeareanPokemon> Get(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentOutOfRangeException("name", "name should not be null or empty");

            return _shakePokeService.GetByPokemonName(name).Result;
        }
    }
}
