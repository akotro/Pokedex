using Newtonsoft.Json;
using PokeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex
{
    internal class PokeApiHandler
    {
        internal RestSharpHandler? RestHandler { get; set; }

        internal PokeApiHandler()
        {
            RestHandler = new RestSharpHandler("https://pokeapi.co/api/v2/");
        }

        internal Pokemon? GetPokemon(int id)
        {
            Pokemon? pokemon = null;

            try
            {
                var response = RestHandler.RequestRestSharp($"pokemon/{id}", "", RestSharp.Method.Get);

                if (response != null)
                {
                    if (!string.IsNullOrWhiteSpace(response.Content))
                    {
                        pokemon = JsonConvert.DeserializeObject<Pokemon>(response.Content);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception {ex}");
            }

            return pokemon;
        }

        internal Pokemon? GetPokemon(string name)
        {
            Pokemon? pokemon = null;

            try
            {
                var response = RestHandler.RequestRestSharp($"pokemon/{name}", "", RestSharp.Method.Get);

                if (response != null)
                {
                    if (!string.IsNullOrWhiteSpace(response.Content))
                    {
                        pokemon = JsonConvert.DeserializeObject<Pokemon>(response.Content);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception {ex}");
            }

            return pokemon;
        }
    }
}
