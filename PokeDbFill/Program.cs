using Newtonsoft.Json;
using PokeAPI.Models;
using PokeDbFill;
using System.Diagnostics;

var pokeApiHandler = new RestSharpHandler("https://pokeapi.co/api/v2/");

var response = pokeApiHandler.RequestRestSharp("pokemon?limit=151", "", RestSharp.Method.Get);

var pokeResponse = new PokeResponse();
if (!string.IsNullOrWhiteSpace(response.Content))
{
    pokeResponse = JsonConvert.DeserializeObject<PokeResponse>(response.Content);
}

var pokemonList = new List<Pokemon>();
if (pokeResponse != null)
{
    if (pokeResponse.Results != null)
    {
        foreach (var result in pokeResponse.Results)
        {
            var pokemon = JsonConvert.DeserializeObject<Pokemon>(result.ToString()!);

            if (pokemon != null)
            {
                pokemon.Id = pokeResponse.Results.IndexOf(result) + 1;

                var apiResponse = pokeApiHandler.RequestRestSharp($"pokemon/{pokemon.Id}", "", RestSharp.Method.Get);

                Pokemon? apiPokemon = new();
                if (apiResponse != null)
                {
                    if (!string.IsNullOrWhiteSpace(apiResponse.Content))
                        apiPokemon = JsonConvert.DeserializeObject<Pokemon>(apiResponse.Content);

                    if (apiPokemon != null)
                    {
                        pokemon.Sprites = apiPokemon.Sprites;
                        pokemon.Types = apiPokemon.Types;

                        pokemonList.Add(pokemon);
                    }
                }


            }
        }
    }
}

var apiProcess = Process.Start(@"C:\Users\akotr\programming\ConnectLine\PokeAPI\PokeAPI\bin\Debug\net6.0\PokeApi.exe");

var localApiHandler = new RestSharpHandler("https://localhost:5001/api/");

foreach (var pokemon in pokemonList)
{
    string pokeJson = JsonConvert.SerializeObject(pokemon);

    try
    {
        var apiResponse = localApiHandler.RequestRestSharp("Pokemon", pokeJson, RestSharp.Method.Post);

        if (string.IsNullOrWhiteSpace(apiResponse.Content))
        {
            apiResponse = localApiHandler.RequestRestSharp("Pokemon", pokeJson, RestSharp.Method.Put);
        }
    }
    catch (Exception)
    {
        Console.WriteLine($"Pokemon already exists, updating: {pokeJson}");
    }
}

var getResponse = localApiHandler.RequestRestSharp("Pokemon", "", RestSharp.Method.Get);

apiProcess.WaitForExit();
