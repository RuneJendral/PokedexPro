using System;
using System.Threading.Tasks;
using PokedexLibrary.API;
using PokedexLibrary.API.DTOs.Pokemon;
using PokedexLibrary.Calculations;
using PokedexLibrary.Calculations.Common;

class Program
{
    private static bool _running = true; 
    static async Task Main(string[] args)
    {
        while (_running) {
            Console.Write("Pokemon name: ");
            string? input = Console.ReadLine();

            if (String.IsNullOrEmpty(input))
            {
                Console.Write("input is empty");
                Console.ReadKey();
                continue;
            }

            if (input == "q")
                _running = false;

            PokeApiClient? fetchService = new();

            Pokemon? pokemon = await fetchService.GetPokemonAsync(input);

            BaseStats baseStats = StatConverter.GetBaseStats(pokemon);

            if (pokemon != null)
            {
                Console.WriteLine($"ID: {pokemon.Id}");
                Console.WriteLine($"Name: {pokemon.Name}");
                Console.WriteLine($"stats: {baseStats.HP}");
                Console.ReadKey();
            }
        }
    }
}