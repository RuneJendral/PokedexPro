using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexLibrary.Dtos
{
    public record VersionGroupDetails(
        [property: JsonPropertyName("level_learned_at")] long LevelLearnedAt,
        [property: JsonPropertyName("move_learn_method")] Species MoveLearnMethod,
        [property: JsonPropertyName("version_group")] Species VersionGroup
    );
}
