namespace PokedexLibrary.API.DTOs.Pokemon
{
    public record Sprites(
        [property: JsonPropertyName("back_default")] Uri BackDefault,
        [property: JsonPropertyName("back_female")] object BackFemale,
        [property: JsonPropertyName("back_shiny")] Uri BackShiny,
        [property: JsonPropertyName("back_shiny_female")] object BackShinyFemale,
        [property: JsonPropertyName("front_default")] Uri FrontDefault,
        [property: JsonPropertyName("front_female")] object FrontFemale,
        [property: JsonPropertyName("front_shiny")] Uri FrontShiny,
        [property: JsonPropertyName("front_shiny_female")] object FrontShinyFemale
    );
}
