using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomHearth;

namespace CardsDatabase.NonClassed._1cost
{
	public class JarDealer :_1costNeutral
	{
		public JarDealer()
		{
			effects.Add(new Effect());
		}
		public override Rarity Rarity => Rarity.Common;

		public override string Name => "Jar Dealer";

		public override string Text => "Deathrattle: Add a random 1-Cost minion to your hand.";

		public override Tribe Tribe => Tribe.Non;

		protected override int InitAttack => 1;
		protected override int InitHealth => 1;
		private class Effect : Deathrattle
		{
			public override void Run(EffectInfo info)
			{
				List<Card> cards = Database.GetCardsThat(c => c is Minion && c.Cost == 1 && c.Collectable).ToList();
				info.From.AddToHand(cards[CustomHearth.Random.Get() % cards.Count]);
			}
		}
	}
}
