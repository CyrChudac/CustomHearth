using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomHearth;

namespace CardsDatabase.NonClassed._1cost
{
	public abstract class _1costNeutral : NeutralMinion
	{
		public override byte Cost { get; set; } = 1;
	}
}
