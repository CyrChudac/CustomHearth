using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomHearth;

namespace CardsDatabase.NonClassed._1cost
{
	public class ElvenArcher : _1costNeutral
	{
		public ElvenArcher()
		{
			effects.Add(new ElvenArcherEffect());
		}
		public override Rarity Rarity => Rarity.Classic;

		public override string Name => "Elven Archer";

		public override string Text => "Battlecry: Deal 1 damage.";

		public override Tribe Tribe => Tribe.Non;

		protected override int InitAttack => 1;

		protected override int InitHealth => 1;

		private class ElvenArcherEffect : TargetedBattlecry
		{
			protected override Condition<IUnit> Condition => 
				(u,i) => true;

			public override void Run(EffectInfo info)
			{
				Target.DamageMe(1);
			}
		}
	}
}
