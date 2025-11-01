using PokedexLibrary.Api.DTOs.Pokemon;
using PokedexLibrary.API.DTOs.Pokemon;
using System.Net;

namespace PokedexLibrary.API
{
    public class PokeApiClient :IApiClient
    {
        private readonly HttpClient _client;

        public PokeApiClient(HttpClient? client = null)
        {
            _client = client ?? new HttpClient{BaseAddress = new Uri("https://pokeapi.co/api/v2/")};
            _client.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task<Pokemon?> GetPokemonAsync(string idOrName, CancellationToken cancellationToken = default) => await Fetch<Pokemon>($"pokemon/{idOrName}", cancellationToken);
        public async Task<Ability?> GetAbilityAsync(string idOrName, CancellationToken cancellationToken = default) => await Fetch<Ability>($"ability/{idOrName}", cancellationToken);
        public async Task<Move?> GetMoveAsync(string idOrName, CancellationToken cancellationToken = default) => await Fetch<Move>($"move/{idOrName}", cancellationToken);
        public async Task<SpeciesDetails?> GetLocalizedNamesAsync(string idOrName, CancellationToken cancellationToken = default) => await Fetch<SpeciesDetails>($"pokemon-species/{idOrName}", cancellationToken);

        public async Task<T?> Fetch<T>(string endpoint, CancellationToken cancellationToken = default) where T : class
        {          
            try
            {
                HttpResponseMessage response = await _client.GetAsync(endpoint, cancellationToken);

                if (response.StatusCode == HttpStatusCode.NotFound)
                    return null;

                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync(cancellationToken);
                return JsonSerializer.Deserialize<T>(jsonResponse);
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP fetching error: {ex.Message}");
                return null;
            }
            catch (JsonException ex)
            {
                Console.Error.WriteLine($"JSON parsing error: {ex.Message}");
                return null;
            }
        }
    }
}
