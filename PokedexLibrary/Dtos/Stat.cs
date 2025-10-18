using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexLibrary.Dtos
{
    public record Stat(
        [property: JsonPropertyName("base_stat")] long BaseStat,
        [property: JsonPropertyName("effort")] long Effort,
        [property: JsonPropertyName("stat")] Species StatValue
    );
}
