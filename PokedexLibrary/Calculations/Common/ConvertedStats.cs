using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexLibrary.Calculations.Common
{
    public readonly record struct ConvertedStats(double HP, double Attack, double Defense, double SpAttack, double SpDefense, double Speed);
}
