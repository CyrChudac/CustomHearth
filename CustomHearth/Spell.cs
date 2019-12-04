using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHearth
{
	public abstract class Spell : Card
	{
		public override abstract string Text { get; }
	}
}
