using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexLibrary.Api.DTOs.Pokemon
{
    public record OtherSprites(
      [property: JsonPropertyName("official-artwork")] OfficialArtwork? OfficialArtwork
  );
}
