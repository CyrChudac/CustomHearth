using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomHearth;

namespace CardsDatabase.NonClassed._1cost
{
	public sealed class AngryChicken : _1costNeutral
	{
		public AngryChicken()
		{
			effects.Add(new AngryChickenEffect(this));
		}
		public override Rarity Rarity => Rarity.Rare;

		public override string Name => "Angry Chicken";

		public override string Text => "Has +5 attack while damaged.";

		public override Tribe Tribe => Tribe.Beast;
		int AngryBonusAttack = 0;
		protected override int InitAttack => 1 + AngryBonusAttack;
		protected override int InitHealth => 1;

		private class AngryChickenEffect : Everytime
		{

			public AngryChickenEffect(AngryChicken chicken)
			{
				this.chicken = chicken;
			}
			AngryChicken chicken;

			public override List<When> When => new List<When>() {
				CustomHearth.When.Damaged,
				CustomHearth.When.OnStatsSet,
				CustomHearth.When.Healed
			};

			public override void Run(EffectInfo info)
			{
				if (chicken.CurrHealth < chicken.AbsHealth)
					chicken.AngryBonusAttack = 5;
				else
					chicken.AngryBonusAttack = 0;
			}

			public override void AtExistenceEnd(EffectInfo info)
			{
				chicken.AngryBonusAttack = 0;
			}
		}
	}
}
