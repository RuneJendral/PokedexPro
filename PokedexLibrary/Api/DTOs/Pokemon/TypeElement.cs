namespace PokedexLibrary.API.DTOs.Pokemon
{
    public record TypeElement(
        [property: JsonPropertyName("slot")] long Slot,
        [property: JsonPropertyName("type")] Species Type
    );
}
