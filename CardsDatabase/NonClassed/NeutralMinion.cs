using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomHearth;

namespace CardsDatabase.NonClassed
{
	public abstract class NeutralMinion : Minion
	{
		public sealed override Class Class => Class.Non;
	}
}
