namespace PokedexLibrary.API.DTOs.Pokemon
{
    public record GameIndex(
        [property: JsonPropertyName("game_index")] long GameIndexValue,
        [property: JsonPropertyName("name")] string Name
    );
}
