using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomHearth;

namespace Game
{
	class DefaultPlayerContract : IEnvirContract
	{
		public IEnvirContract WithMap(Map map)
		{
			this.Map = map;
			return this;
		}
		public DefaultPlayerContract(Player player)
		{
			this.Player = player;
		}
		Map Map;
		Player Player;
		Player First => Map.First;
		Player Second => Map.Second;
		Player IEnvirContract.GetEnemy()
		{
			if (ReferenceEquals(Player, First))
				return Second;
			else if (ReferenceEquals(Player, Second))
				return First;
			else
				throw new ArgumentException("Player, that asks for an enemy, is not a part of this game.");
		}
		IEnumerable<IUnit> IEnvirContract.GetUnits(Predicate<IUnit> condition)
		{
			if (condition(First))
				yield return First;
			if (condition(Second))
				yield return Second;
			foreach (Minion m in board)
				if (condition(m))
					yield return m;
		}
		IEnumerable<Minion> IEnvirContract.Board => board;
		IEnumerable<Minion> board
		{
			get
			{
				foreach (Minion m in First.Board)
					yield return m;
				foreach (Minion m in Second.Board)
					yield return m;
			}
		}
	}
}
