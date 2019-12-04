using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomHearth;

namespace CardsDatabase.NonClassed._1cost
{
	public class FaithfulLumi : _1costNeutral
	{
		public FaithfulLumi()
		{
			effects.Add( new Effect());
		}
		public override Rarity Rarity => Rarity.Common;

		public override string Name => "Faithful Lumi";

		public override string Text => "Battlecry: Give a friendly Mech +1/+1.";

		public override Tribe Tribe => Tribe.Mech;

		protected override int InitAttack => 1;

		protected override int InitHealth => 1;

		private class Effect : CustomHearth.MinionTargetedBattlecry
		{
			protected override Condition<Minion> MinionCondition =>
				(m,i) => m.Tribe == Tribe.Mech && m.IsFriendly(i.From);

			public override void Run(EffectInfo info)
			{
				Target.AddStats(1,1);
			}
		}
	}
}
