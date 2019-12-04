using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomHearth;

namespace CardsDatabase.NonClassed._1cost
{
	public class Lightwarden : _1costNeutral
	{
		public Lightwarden()
		{
			effects.Add(new Effect(this));
		}
		public override Rarity Rarity => Rarity.Rare;

		public override string Name => "Lightwarden";

		public override string Text => "Whenever a character is healed, gain +2 Attack.";

		public override Tribe Tribe => Tribe.Non;
		
		protected override int InitAttack => 1;
		protected override int InitHealth => 2;

		private class Effect : Everytime
		{
			Lightwarden lightwarden;
			int times = 0;
			public Effect(Lightwarden lightwarden)
			{
				this.lightwarden = lightwarden;
			}
			public override List<When> When 
				=> new List<When>() { CustomHearth.When.OnAnythingHealed};

			public override void AtExistenceEnd(EffectInfo info)
			{
				lightwarden.AddStats(-2 * times, 0);
			}

			public override void Run(EffectInfo info)
			{
				lightwarden.AddStats(2, 0);
				times++;
			}
		}
	}
}
