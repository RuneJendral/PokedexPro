using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexLibrary.Dtos
{
    public record TypeElement(
        [property: JsonPropertyName("slot")] long Slot,
        [property: JsonPropertyName("type")] Species Type
    );
}
