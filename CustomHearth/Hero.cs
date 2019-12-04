using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHearth
{
	public abstract class Hero : Card
	{
		public override Rarity Rarity => Rarity.Legendary;
		public abstract override string Text { get; }
		public virtual Tribe Tribe => Tribe.Non;
		public abstract int ArmorGain { get; }
		public byte SpellDamage = 0;
		public abstract HeroPower HeroPower { get; }
	}
}
