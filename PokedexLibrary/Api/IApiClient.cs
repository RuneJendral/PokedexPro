using PokedexLibrary.API.DTOs.Pokemon;

namespace PokedexLibrary.API
{
    public interface IApiClient
    {
        Task<T?> Fetch<T>(string endpoint, CancellationToken cancellationToken = default) where T : class;
    }
}
