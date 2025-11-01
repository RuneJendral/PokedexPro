using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexLibrary.Api.DTOs.Pokemon
{
    public record SpeciesDetails(
        [property: JsonPropertyName("names")] IReadOnlyList<LocalizedName> Names
    );
}
