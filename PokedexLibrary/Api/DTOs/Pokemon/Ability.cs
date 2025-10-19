namespace PokedexLibrary.API.DTOs.Pokemon
{
    public record Ability(
        [property: JsonPropertyName("ability")] Species AbilityValue,
        [property: JsonPropertyName("is_hidden")] bool IsHidden,
        [property: JsonPropertyName("slot")] long Slot
    );
}
