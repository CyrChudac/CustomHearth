using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHearth
{
	public abstract class HeroPower
	{
		public abstract IEffect_ign Effect { get; }
		public abstract byte Cost { get; }
	}
}
