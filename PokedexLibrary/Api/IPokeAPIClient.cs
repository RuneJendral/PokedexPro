using PokedexLibrary.Dtos;

namespace PokedexLibrary.Api
{
    public interface IPokeAPIClient
    {
        Task<Pokemon?> GetPokemonAsync(string idOrName, CancellationToken cancellationToken = default);
        Task<Move?> GetMoveAsync(string idOrName, CancellationToken cancellationToken = default);
        Task<Ability?> GetAbilityAsync(string idOrName, CancellationToken cancellationToken = default);
    }
}
