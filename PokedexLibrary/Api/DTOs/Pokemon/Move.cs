namespace PokedexLibrary.API.DTOs.Pokemon
{
    public record Move(
        [property: JsonPropertyName("move")] Species MoveValue,
        [property: JsonPropertyName("version_group_details")] IReadOnlyList<VersionGroupDetails> VersionGroupDetails
    );
}
