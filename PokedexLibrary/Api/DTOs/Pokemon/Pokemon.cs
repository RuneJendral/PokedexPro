namespace PokedexLibrary.API.DTOs.Pokemon
{
    public record Pokemon(
        [property: JsonPropertyName("abilities")] IReadOnlyList<Ability> Abilities,
        [property: JsonPropertyName("base_experience")] long BaseExperience,
        [property: JsonPropertyName("forms")] IReadOnlyList<Species> Forms,
        [property: JsonPropertyName("game_indices")] IReadOnlyList<GameIndex> GameIndices,
        [property: JsonPropertyName("height")] long Height,
        [property: JsonPropertyName("held_items")] IReadOnlyList<object> HeldItems,
        [property: JsonPropertyName("id")] long Id,
        [property: JsonPropertyName("is_default")] bool IsDefault,
        [property: JsonPropertyName("location_area_encounters")] Uri LocationAreaEncounters,
        [property: JsonPropertyName("moves")] IReadOnlyList<Move> Moves,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("order")] long Order,
        [property: JsonPropertyName("species")] Species Species,
        [property: JsonPropertyName("sprites")] Sprites Sprites,
        [property: JsonPropertyName("stats")] IReadOnlyList<Stats> Stats,
        [property: JsonPropertyName("types")] IReadOnlyList<TypeElement> Types,
        [property: JsonPropertyName("weight")] long Weight
    );
}
