using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomHearth;

namespace CardsDatabase.NonClassed._1cost
{
	public class HungryCrab : _1costNeutral
	{
		public HungryCrab()
		{
			effects.Add(new Effect(this));
		}
		public override Rarity Rarity => Rarity.Epic;

		public override string Name => "Hungry Crab";

		public override string Text => "Battlecry: Destroy a Murloc and gain +2/+2.";

		public override Tribe Tribe => Tribe.Beast;

		protected override int InitAttack => 1;
		protected override int InitHealth => 2;

		private class Effect : TargetedBattlecry
		{
			public Effect(HungryCrab crab)
			{
				this.crab = crab;
			}
			HungryCrab crab;

			protected override Condition<IUnit> Condition =>
				(u,i) => u.Tribe == Tribe.Murloc;

			public override void Run(EffectInfo info)
			{
				if( null != Target)
				{
					Target.DestroyMe(info.Contract);
					crab.AddStats(2, 2);
				}
			}
		}
	}
}
