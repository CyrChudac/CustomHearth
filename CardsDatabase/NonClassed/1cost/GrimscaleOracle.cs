using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomHearth;

namespace CardsDatabase.NonClassed._1cost
{
	public class GrimscaleOracle : _1costNeutral
	{
		public GrimscaleOracle()
		{
			effects.Add( new Effect());
		}
		public override Rarity Rarity => Rarity.Classic;

		public override string Name => "Grimscale Oracle";

		public override string Text => "Your other Murlocs have +1 Attack.";

		public override Tribe Tribe => Tribe.Murloc;

		protected override int InitAttack => 1;

		protected override int InitHealth => 1;

		private class Effect : CustomHearth.Everytime
		{
			public override List<When> When => new List<When>(){
				CustomHearth.When.OnMinionSummon,
				CustomHearth.When.OnPlayed
			};

			public override void AtExistenceEnd(EffectInfo info)
			{
				foreach (Minion m in affectedMinions)
					m.AddStats(-1, 0);
			}

			IEnumerable<Minion> affectedMinions = new List<Minion>();

			public override void Run(EffectInfo info)
			{
				foreach (Minion m in affectedMinions)
					m.AddStats(-1, 0);
				affectedMinions = info.Contract.GetUnits(
					u => u.Tribe == Tribe.Murloc &&
					u.IsFriendly(info.From) &&
					u is Minion
					).Select(u => (Minion)u);
				foreach (Minion m in affectedMinions)
					m.AddStats(1, 0);
			}
		}
	}
}
