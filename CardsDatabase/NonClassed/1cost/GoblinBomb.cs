using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomHearth;

namespace CardsDatabase.NonClassed._1cost
{
	public class GoblinBomb : _1costNeutral
	{
		public GoblinBomb()
		{
			effects.Add(new Effect());
		}
		public override Rarity Rarity => Rarity.Common;

		public override string Name => "Goblin Bomb";

		public override string Text => "Battlecry: Give a friendly Mech +1/+1.";

		public override Tribe Tribe => Tribe.Mech;

		protected override int InitAttack => 0;

		protected override int InitHealth => 2;

		private class Effect : CustomHearth.Deathrattle
		{
			public override void Run(EffectInfo info)
			{
				info.Contract.GetEnemy().DamageMe(2);
			}
		}
	}
}
