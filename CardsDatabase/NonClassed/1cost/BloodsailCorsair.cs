using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomHearth;

namespace CardsDatabase.NonClassed._1cost
{
	public sealed class BloodsailCorsair : _1costNeutral
	{
		public BloodsailCorsair()
		{
			effects.Add(new BloodsailCorsairEffect());
		}

		public override Rarity Rarity => Rarity.Common;

		public override string Name => "Bloodsail Corsair";

		public override string Text => "Battlecry: Remove 1 Durability from your opponent's weapon.";

		public override Tribe Tribe => Tribe.Non;

		protected override int InitAttack => 1;
		protected override int InitHealth => 2;

		class BloodsailCorsairEffect : Battlecry
		{
			public override void Run(EffectInfo info)
			{
				if (info.GetEnemy().Weapon != null)
					info.GetEnemy().Weapon.Durab -= 1;
			}
		}
	}
}
