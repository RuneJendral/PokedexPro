namespace PokedexLibrary.Dtos
{
    public record Species(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("url")] Uri Url
    );
}
