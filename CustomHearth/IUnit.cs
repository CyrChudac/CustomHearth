using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHearth
{
	public interface IUnit
	{
		void DamageMe(int damage);
		void DestroyMe(IEnvirContract contract);
		void Attacked(int attackStrength);
		int CurrHealth { get; }
		int Attack { get; }
		Tribe Tribe { get; }
		Player Player { get; }

		byte SpellDamage { get; } 
		bool Taunt { get; }
		bool DivineShield { get; } 
		bool Poisonous { get;}
		bool Charge { get;}
		bool Lifesteal { get;}
		bool Rush { get; }
		bool Windfury { get; }
		bool MegaWindfury { get; }
		bool Stealth { get; }
		bool Reborn { get; }
		bool CantBeTargeted { get; }

		void Healed(int heal);
		bool CanAttack<WHAT>() where WHAT : IUnit;
	}

	public static class UnitExtensions
	{
		public static bool IsFriendly(this IUnit me, IUnit other)
		 => ReferenceEquals(me.Player, other.Player) && me.Player != null;
	}
}
