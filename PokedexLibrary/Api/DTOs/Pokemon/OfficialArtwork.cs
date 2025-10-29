using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexLibrary.Api.DTOs.Pokemon
{
    public record OfficialArtwork(
        [property: JsonPropertyName("front_default")] Uri? FrontDefault,
        [property: JsonPropertyName("front_shiny")] Uri? FrontShiny
    );
}
