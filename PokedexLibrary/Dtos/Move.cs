namespace PokedexLibrary.Dtos
{
    public record Move(
        [property: JsonPropertyName("move")] Species MoveValue,
        [property: JsonPropertyName("version_group_details")] IReadOnlyList<VersionGroupDetails> VersionGroupDetails
    );
}
