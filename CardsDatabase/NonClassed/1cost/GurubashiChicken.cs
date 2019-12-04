using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomHearth;

namespace CardsDatabase.NonClassed._1cost
{
	public class GurubashiChicken : _1costNeutral
	{
		public GurubashiChicken()
		{
			effects.Add(new Effect(this));
		}
		public override Rarity Rarity => Rarity.Common;

		public override string Name => "Gurubashi Chicken";

		public override string Text => "Overkill: Gain +5 Attack.";

		public override Tribe Tribe => Tribe.Beast;
		protected override int InitAttack => 1;
		protected override int InitHealth => 1;

		private class Effect : Overkill
		{

			public Effect(GurubashiChicken chicken)
			{
				this.chicken = chicken;
			}
			GurubashiChicken chicken;

			public override void Run(EffectInfo info)
			{
				chicken.AddStats(5, 0);
			}
		}
	}
}
