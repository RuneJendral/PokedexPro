using PokedexLibrary.API.DTOs.Pokemon;
using PokedexLibrary.Calculations.Common;

namespace PokedexLibrary.Calculations
{
    public static class StatConverter
    {
        public static BaseStats GetBaseStats(Pokemon pokemon)
        {
            ArgumentNullException.ThrowIfNull(pokemon);

            if (pokemon.Stats is null || pokemon.Stats.Count == 0)
                throw new InvalidOperationException("There are no valid stat entries");

            Dictionary<string, int> dict = pokemon.Stats.ToDictionary(s => s.StatValue.Name, s => (int)s.BaseStat, StringComparer.OrdinalIgnoreCase);

            int Get(string key) => dict.TryGetValue(key, out var v) ? v : throw new KeyNotFoundException($"stat entry '{key}' in '{pokemon.Name}' was not found.");

            return new BaseStats(
                HP: Get("hp"),
                Attack: Get("attack"),
                Defense: Get("defense"),
                SpAttack: Get("special-attack"),
                SpDefense: Get("special-defense"),
                Speed: Get("speed")
            );
        }

        public static ConvertedStats ApplyNatureModifier(BaseStats baseStats, Nature nature)
        {
            return new ConvertedStats
            (
                baseStats.HP,
                baseStats.Attack * GetModifier(nature, StatType.Attack),
                baseStats.Defense * GetModifier(nature, StatType.Defense),
                baseStats.SpAttack * GetModifier(nature, StatType.SpAttack),
                baseStats.SpDefense * GetModifier(nature, StatType.SpDefense),
                baseStats.Speed * GetModifier(nature, StatType.Speed)
            ); 
        }

        public static double GetModifier(Nature nature, StatType stat)
        {
            if (nature is Nature.Hardy or Nature.Docile or Nature.Serious or Nature.Bashful or Nature.Quirky)
                return 1.0;

            return (nature, stat) switch
            {
                // +Atk
                (Nature.Lonely, StatType.Attack) => 1.1,
                (Nature.Brave, StatType.Attack) => 1.1,
                (Nature.Adamant, StatType.Attack) => 1.1,
                (Nature.Naughty, StatType.Attack) => 1.1,

                // +Def
                (Nature.Bold, StatType.Defense) => 1.1,
                (Nature.Relaxed, StatType.Defense) => 1.1,
                (Nature.Impish, StatType.Defense) => 1.1,
                (Nature.Lax, StatType.Defense) => 1.1,

                // +Spe
                (Nature.Timid, StatType.Speed) => 1.1,
                (Nature.Hasty, StatType.Speed) => 1.1,
                (Nature.Jolly, StatType.Speed) => 1.1,
                (Nature.Naive, StatType.Speed) => 1.1,

                // +SpA
                (Nature.Modest, StatType.SpAttack) => 1.1,
                (Nature.Mild, StatType.SpAttack) => 1.1,
                (Nature.Quiet, StatType.SpAttack) => 1.1,
                (Nature.Rash, StatType.SpAttack) => 1.1,

                // +SpD
                (Nature.Calm, StatType.SpDefense) => 1.1,
                (Nature.Gentle, StatType.SpDefense) => 1.1,
                (Nature.Sassy, StatType.SpDefense) => 1.1,
                (Nature.Careful, StatType.SpDefense) => 1.1,

                // –Atk
                (Nature.Bold, StatType.Attack) => 0.9,
                (Nature.Timid, StatType.Attack) => 0.9,
                (Nature.Modest, StatType.Attack) => 0.9,
                (Nature.Calm, StatType.Attack) => 0.9,

                // –Def
                (Nature.Lonely, StatType.Defense) => 0.9,
                (Nature.Hasty, StatType.Defense) => 0.9,
                (Nature.Mild, StatType.Defense) => 0.9,
                (Nature.Gentle, StatType.Defense) => 0.9,

                // –Spe
                (Nature.Brave, StatType.Speed) => 0.9,
                (Nature.Relaxed, StatType.Speed) => 0.9,
                (Nature.Quiet, StatType.Speed) => 0.9,
                (Nature.Sassy, StatType.Speed) => 0.9,

                // –SpA
                (Nature.Adamant, StatType.SpAttack) => 0.9,
                (Nature.Impish, StatType.SpAttack) => 0.9,
                (Nature.Jolly, StatType.SpAttack) => 0.9,
                (Nature.Careful, StatType.SpAttack) => 0.9,

                // –SpD
                (Nature.Naughty, StatType.SpDefense) => 0.9,
                (Nature.Lax, StatType.SpDefense) => 0.9,
                (Nature.Naive, StatType.SpDefense) => 0.9,
                (Nature.Rash, StatType.SpDefense) => 0.9,

                _ => 1.0
            };
        }
    }
}
