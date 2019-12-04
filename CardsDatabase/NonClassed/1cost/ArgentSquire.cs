using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomHearth;

namespace CardsDatabase.NonClassed._1cost
{
	public sealed class ArgentSquire : _1costNeutral
	{
		public ArgentSquire()
		{
			DivineShield = true;
		}
		public override Rarity Rarity => Rarity.Common;

		public override string Name => "Argent Squire";

		public override string Text => "Divione Shield";

		public override Tribe Tribe => Tribe.Non;

		protected override int InitAttack => 1;
		protected override int InitHealth => 1;
	}
}
