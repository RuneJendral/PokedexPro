namespace PokedexLibrary.API.DTOs.Pokemon
{
    public record Stats(
        [property: JsonPropertyName("base_stat")] long BaseStat,
        [property: JsonPropertyName("effort")] long Effort,
        [property: JsonPropertyName("stat")] Species StatValue
    );
}
