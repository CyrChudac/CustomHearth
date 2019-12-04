using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHearth
{
	public abstract class Weapon :Card
	{
		public abstract int Attack { get; }
		public abstract int Durab { get; set; }

		public virtual byte SpellDamage => 0;
		public virtual bool Poisonous => false;
		public virtual bool Charge => true;
		public virtual bool Lifesteal => false;
		public virtual bool Rush => true;
		public virtual bool Windfury => false;
		public virtual bool MegaWindfury => false;
		public virtual bool CantBeTargeted => false;
	}
}
