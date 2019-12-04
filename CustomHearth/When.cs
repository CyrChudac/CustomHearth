using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHearth
{
	public delegate bool Condition<U>(U u, EffectInfo info) where U :IUnit;

	public abstract class Battlecry : IEffect { }
	public abstract class TargetedBattlecry : Battlecry
	{
		public void SetTarget(EffectInfo info, bool random = false)
		{
			if (random)
				throw new NotImplementedException();
			else
				SetTarget(info);
		}
		protected abstract Condition<IUnit> Condition { get; }

		protected IUnit Target;
		protected bool SetTarget(EffectInfo info)
		{
			if (info.UnitExists(Condition))
				return null != (Target = info.GetUnitThat(Condition));
			return true;
		}
		public class TooManyTargetsException : Exception{
			public TooManyTargetsException(string message) : base(message) { }
			public TooManyTargetsException() : base() { }
		}
	}
	public abstract class MinionTargetedBattlecry : TargetedBattlecry
	{
		protected abstract Condition<Minion> MinionCondition { get; }
		protected sealed override Condition<IUnit> Condition => (u,i) => u is Minion && MinionCondition((Minion)u,i);
		protected new Minion Target => (Minion)base.Target;
	}
	public abstract class Deathrattle : IEffect { }
	public abstract class EndOfYourTurn : IEffect { }
	public abstract class EndOfEachTurn : IEffect { }
	public abstract class StartOfYourTurn : IEffect { }
	public abstract class StartOfGame : IEffect { }
	public abstract class Overkill : IEffect { }
	public abstract class Inspire : IEffect { }
	public abstract class Combo : IEffect { }
	public abstract class Everytime : IEffect
	{
		public abstract void AtExistenceEnd(EffectInfo info);
		public abstract List<When> When { get; }
	}

	public enum When
	{
		OnPlay,
		OnAnythingHealed,
		OnStatsSet,
		OnPlayed,
		Everytime,
		OnMinionSummon,
		Damaged,
		Attacked,
		OnSpellCast,
		Healed
	}
}
