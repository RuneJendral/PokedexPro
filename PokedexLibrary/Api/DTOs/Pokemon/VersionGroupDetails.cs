namespace PokedexLibrary.API.DTOs.Pokemon
{
    public record VersionGroupDetails(
        [property: JsonPropertyName("level_learned_at")] long LevelLearnedAt,
        [property: JsonPropertyName("move_learn_method")] Species MoveLearnMethod,
        [property: JsonPropertyName("version_group")] Species VersionGroup
    );
}
