using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeAPI.Data;
using PokeAPI.Models;

namespace PokeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;
        private readonly DataContext _context;

        public PokemonController(DataContext context, ILogger<PokemonController> logger)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public List<Pokemon>? GetPokemon()
        {
            if (_context == null || _context.Pokemon == null)
            {
                return null;
            }

            return _context.Pokemon.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pokemon>> GetPokemon(int id)
        {
            Pokemon? pokemon = null;

            if (_context.Pokemon != null)
                pokemon = await _context.Pokemon.FindAsync(id);

            if (pokemon == null)
            {
                return NotFound("Pokemon not found");
            }

            return Ok(pokemon);
        }

        [HttpPost]
        public async Task<ActionResult<List<Pokemon>>> AddPokemon(Pokemon pokemon)
        {
            Pokemon? existingPokemon = null;

            if (_context.Pokemon != null)
            {
                existingPokemon = await _context.Pokemon.FindAsync(pokemon.Id);

                if (existingPokemon != null)
                {
                    return Ok();
                }

                _context.Pokemon.Add(pokemon);
                await _context.SaveChangesAsync();
            }

            return Ok(pokemon);
        }

        [HttpPut]
        public async Task<ActionResult<List<Pokemon>>> UpdatePokemon(Pokemon request)
        {
            Pokemon? dbPokemon = null;

            if (_context.Pokemon != null)
            {
                await _context.Pokemon.FindAsync(request.Id);

                if (dbPokemon == null)
                {
                    return NotFound("Pokemon not found");
                }

                dbPokemon.Name = request.Name;
                dbPokemon.Sprites = request.Sprites;
                dbPokemon.Types = request.Types;

                await _context.SaveChangesAsync();
            }

            return Ok(request);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Pokemon>>> DeletePokemon(int id)
        {
            Pokemon? dbPokemon = null;

            if (_context.Pokemon != null)
            {
                await _context.Pokemon.FindAsync(id);

                if (dbPokemon == null)
                {
                    return NotFound("Pokemon not found");
                }

                _context.Pokemon.Remove(dbPokemon);
                await _context.SaveChangesAsync();
            }

            return Ok(dbPokemon);
        }
    }
}
