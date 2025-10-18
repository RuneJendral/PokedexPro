using System;
using System.Threading.Tasks;
using PokedexLibrary.Api;

class Program
{
    static async Task Main(string[] args)
    {
        var fetchService = new PokeAPIClient();

        var pokemon = await fetchService.GetPokemonAsync("Lucario");

        if (pokemon != null) 
        {
            Console.WriteLine($"ID: {pokemon.Id}");
            Console.WriteLine($"Name: {pokemon.Name}");
            Console.WriteLine($"Sprite: {pokemon.Sprites.FrontDefault}");
        }
    }
}