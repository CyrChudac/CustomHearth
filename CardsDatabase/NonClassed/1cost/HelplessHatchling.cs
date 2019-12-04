using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomHearth;

namespace CardsDatabase.NonClassed._1cost
{
	public class HelplessHatchling : _1costNeutral
	{
		public HelplessHatchling()
		{
			effects.Add(new Effect());
		}
		public override Rarity Rarity => Rarity.Common;

		public override string Name => "Helpless Hatchling";

		public override string Text => "Deathrattle: Reduce the Cost of a Beast in your hand by (1).";

		public override Tribe Tribe => Tribe.Beast;

		protected override int InitAttack => 1;
		protected override int InitHealth => 1;

		private class Effect : Deathrattle
		{
			public override void Run(EffectInfo info)
			{
				List<Card> cards = info.From.Hand.Where(c => c is Minion && ((Minion)c).Tribe == Tribe.Beast).ToList();
				int index = CustomHearth.Random.Get() % cards.Count();
				cards[index].Cost -= 1;
			}
		}
	}
}
