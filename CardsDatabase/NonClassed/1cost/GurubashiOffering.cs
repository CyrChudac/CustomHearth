using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomHearth;

namespace CardsDatabase.NonClassed._1cost
{
	public class GurubashiOffering : _1costNeutral
	{
		public GurubashiOffering()
		{
			effects.Add(new Effect(this));
		}
		public override Rarity Rarity => Rarity.Epic;

		public override string Name => "Gurubashi Offering";

		public override string Text => "At the start of your turn, destroy this and gain 8 Armor.";

		public override Tribe Tribe => Tribe.Non;

		protected override int InitAttack => 0;
		protected override int InitHealth => 2;
		private class Effect : StartOfYourTurn
		{
			public Effect(GurubashiOffering go)
			{
				this.go = go;
			}
			GurubashiOffering go;
			public override void Run(EffectInfo info)
			{
				go.Die(info.Contract);
				info.From.Armor += 8;
			}
		}
	}
}
