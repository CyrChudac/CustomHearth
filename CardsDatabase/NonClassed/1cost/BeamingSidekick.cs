using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomHearth;

namespace CardsDatabase.NonClassed._1cost
{
	public sealed class BeamingSidekick : _1costNeutral
	{
		public BeamingSidekick()
		{
			effects.Add(new BeamingSidekickEffect());
		}
		public override Rarity Rarity => Rarity.Common;

		public override string Name => "Beaming Sidekick";

		public override string Text => "Battlecry: Give a friendly minion +2 Health.";

		public override Tribe Tribe => Tribe.Non;

		protected override int InitAttack => 1;
		protected override int InitHealth => 2;

		class BeamingSidekickEffect : MinionTargetedBattlecry
		{
			protected override Condition<Minion> MinionCondition => 
				(m,i) => m.IsFriendly(i.From);

			public override void Run(EffectInfo info)
			{
				Target.AddStats(0, 2);
			}
		}
	}
}
