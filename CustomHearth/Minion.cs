using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHearth
{
	public abstract class Minion : Card, IUnit, IBoardable
	{
		public Minion()
		{
			AbsHealth = InitHealth;
			CurrHealth = InitHealth;
		}

		public abstract Tribe Tribe { get; }
		protected abstract int InitAttack { get; }
		protected abstract int InitHealth { get; }
		public int AttackBonus = 0;
		public int AbsHealth { get; protected set; }
		public int CurrHealth { get; protected set; }
		public int Attack => InitAttack + AttackBonus;

		public int TimesAttacked { get; protected set; } = DefaultTimesAttacked;
		public static int DefaultTimesAttacked = 578;

		public byte SpellDamage { get; protected set; } = 0;
		public bool Taunt { get; protected set; } = false;
		public bool DivineShield { get; protected set; } = false;
		public bool Poisonous { get; protected set; } = false;
		public bool Charge { get; protected set; } = false;
		public bool Lifesteal { get; protected set; } = false;
		public bool Rush { get; protected set; } = false;
		public bool Windfury { get; protected set; } = false;
		public bool MegaWindfury { get; protected set; } = false;
		public bool Stealth { get; protected set; } = false;
		public bool Reborn { get; protected set; } = false;
		public bool CantBeTargeted { get; protected set; } = false;

		public bool OnBoard => Player != null;
		public Player Player { get; protected set; } = null;

		public virtual bool CanAttack<WHAT>() where WHAT : IUnit
			=> (Attack > 0) &&
			((TimesAttacked < 1) ||
			((TimesAttacked < 2) && (Windfury == true)) ||
			((TimesAttacked < 4) && (MegaWindfury == true)) ||
			((TimesAttacked == DefaultTimesAttacked) &&
			(Charge || ( typeof(Player).IsSubclassOf(typeof(WHAT)) && Rush))));

		public bool IsFriendly(Minion with)
			=> ReferenceEquals(Player, with) && Player != null;

		public void Played(int indexOnBoard, Player by, IEnvirContract situation)
		{
			bool hasTarget = false;
			foreach (var e in effects)
				if (e is TargetedBattlecry)
					if (!hasTarget)
						hasTarget = true;
					else
						throw new TargetedBattlecry.TooManyTargetsException("This minion has 2 or more targets: " + this.GetType().ToString());
			foreach (var e in effects)
				if (e is Battlecry)
					e.Run(new SimpleBattlecryInfo(indexOnBoard, situation, by));
			Summoned(by);
		}

		public void DestroyMe(IEnvirContract contract)
			=> Die(contract);
		protected void Die(IEnvirContract contract)
		{
			Player.Board.Remove(this);
			foreach (var e in effects)
				if (e is Deathrattle)
					e.Run(new DeathrattleInfo(contract, Player));
		}

		public void Summoned(Player p)
		{
			Player = p;
		}

		public void DamageMe(int attackStrength)
		{
			CurrHealth -= attackStrength;
		}
		public void Attacked(int attackStrength)
		{
			DamageMe(attackStrength);
		}

		public void AddStats(int Attack, int Health)
		{
			AbsHealth += 1;
			CurrHealth += 1;
			AttackBonus += 1;
		}

		public void Healed(int heal)
		{
			CurrHealth = Math.Min(CurrHealth + heal, AbsHealth);
		}
	}
}
