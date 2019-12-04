using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHearth
{
	public abstract class IEffect
	{
		public abstract void Run(EffectInfo info);
	}
}
