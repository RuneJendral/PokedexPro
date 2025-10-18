using PokedexLibrary.Dtos;
using System.Net;

namespace PokedexLibrary.Api
{
    public class PokeAPIClient :IPokeAPIClient
    {
        public async Task<Pokemon?> GetPokemonAsync(string idOrName, CancellationToken cancellationToken = default) => await Fetch<Pokemon>($"pokemon/{idOrName}", cancellationToken);
        public async Task<Ability?> GetAbilityAsync(string idOrName, CancellationToken cancellationToken = default) => await Fetch<Ability>($"ability/{idOrName}", cancellationToken);
        public async Task<Move?> GetMoveAsync(string idOrName, CancellationToken cancellationToken = default) => await Fetch<Move>($"move/{idOrName}", cancellationToken);
      
        private readonly HttpClient _client;

        public PokeAPIClient(HttpClient? client = null)
        {
            _client = client ?? new HttpClient{BaseAddress = new Uri("https://pokeapi.co/api/v2/")};
            _client.Timeout = TimeSpan.FromSeconds(30);
        }

        private async Task<T?> Fetch<T>(string endpoint, CancellationToken cancellationToken = default) where T : class
        {          
            try
            {
                var response = await _client.GetAsync(endpoint, cancellationToken);

                if (response.StatusCode == HttpStatusCode.NotFound)
                    return null;

                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync(cancellationToken);
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
