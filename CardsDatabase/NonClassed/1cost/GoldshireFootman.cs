using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomHearth;

namespace CardsDatabase.NonClassed._1cost
{
	public class GoldshireFootman : _1costNeutral
	{
		public GoldshireFootman()
		{
			Taunt = true;
		}
		public override Rarity Rarity => Rarity.Classic;

		public override string Name => "Goldshire Footman";

		public override string Text => "Taunt.";

		public override Tribe Tribe => Tribe.Non;

		protected override int InitAttack => 1;

		protected override int InitHealth => 2;
	}
}
