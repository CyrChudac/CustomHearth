using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomHearth;

namespace CardsDatabase.NonClassed._1cost
{
	public sealed class AbusiveSergeant : _1costNeutral
	{
		public AbusiveSergeant()
		{
			Effect_1 e1 = new Effect_1();
			effects.Add(e1);
			effects.Add(new Effect_1.Effect_2(e1, effects));
		}
		public override Rarity Rarity => Rarity.Common;

		public override string Name => "Abusive Sergeant";

		public override string Text => "Battlecry: Give a minion +2 attack this turn.";

		public override Tribe Tribe => Tribe.Non;

		protected override int InitAttack => 1;

		protected override int InitHealth => 1;

		private class Effect_1 : CustomHearth.MinionTargetedBattlecry
		{
			private int attackBonus = 2;

			protected override Condition<Minion> MinionCondition => 
				(m,i) => true;

			public override void Run(EffectInfo info)
			{
				Target.AttackBonus += attackBonus;
			}

			public class Effect_2 : CustomHearth.EndOfYourTurn
			{
				public Effect_2(Effect_1 effect, List<TimedEffect> effects)
				{
					this.effects = effects;
					this.effect = effect;
				}
				List<TimedEffect> effects;
				Effect_1 effect;
				public override void Run(EffectInfo info)
				{
					effect.Target.AttackBonus -= effect.attackBonus;
					effects.RemoveAll( e => ReferenceEquals(e, this));
				}
			}
		}
	}
}
