using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexLibrary.Calculations.Common
{
    public readonly record struct BaseStats(int HP, int Attack, int Defense, int SpAttack, int SpDefense, int Speed);
}
