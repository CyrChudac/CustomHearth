using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomHearth;

namespace CardsDatabase.NonClassed._1cost
{
	public class LeperGnome : _1costNeutral
	{
		public LeperGnome()
		{
			effects.Add(new Effect());
		}
		public override Rarity Rarity => Rarity.Common;

		public override string Name => "Leper Gnome";

		public override string Text => "Deathrattle: Deal 2 damage to the enemy hero.";

		public override Tribe Tribe => Tribe.Non;

		protected override int InitAttack => 1;
		protected override int InitHealth => 1;

		private class Effect : Deathrattle
		{
			public override void Run(EffectInfo info)
			{
				info.GetEnemy().DamageMe(2);
			}
		}
	}
}
