using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHearth
{
	public abstract class EffectInfo
	{
		public EffectInfo(IEnvirContract contract, Player from)
		{
			this.From = from;
			this.Contract = contract;
		}
		public Player GetEnemy()
			=> Contract.GetEnemy();
		public Player From { get; }
		public IEnvirContract Contract { get; }
		public IUnit GetUnitThat(Condition<IUnit> condition)
			=> From.InputGetter.GetOneOf(Contract.GetUnits(u => condition(u, this)));
		public IUnit GetUnit()
			=> From.InputGetter.GetOneOf(Contract.GetUnits(x => true));
		public Minion GetMinionThat(Condition<Minion> condition)
			=> (Minion)From.InputGetter.GetOneOf(Contract.GetUnits(m => m is Minion && condition((Minion)m, this)));
		public Minion GetMinion()
			=> (Minion)From.InputGetter.GetOneOf(Contract.GetUnits(x => x is Minion));
		public bool UnitExists(Condition<IUnit> condition)
			=> Contract.GetUnits(u => condition(u, this)).Any();
	}
}
