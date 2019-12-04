using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomHearth;

namespace CardsDatabase.NonClassed._1cost
{
	public class Crystallizer : _1costNeutral
	{
		public Crystallizer()
		{
			effects.Add( new CrystallizerEffect());
		}
		public override Rarity Rarity => Rarity.Epic;

		public override string Name => "Crystallizer";

		public override string Text => "Battlecry: Deal 5 damage to your hero. Gain 5 Armor.";

		public override Tribe Tribe => Tribe.Non;

		protected override int InitAttack => 1;

		protected override int InitHealth => 3;

		private class CrystallizerEffect : Battlecry
		{
			public override void Run(EffectInfo info)
			{
				info.From.DamageMe(5);
				info.From.Armor += 5;
			}
		}
	}
}
