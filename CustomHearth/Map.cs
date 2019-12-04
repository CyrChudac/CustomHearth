using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHearth
{
	public interface IEnvirContract
	{
		IEnvirContract WithMap(Map map);
		Player GetEnemy();
		IEnumerable<Minion> Board { get; }
		IEnumerable<IUnit> GetUnits(Predicate<IUnit> condition);
	}

	public class Map
	{
		public Map(Player first, Player second)
		{
			this.First = first;
			this.Second = second;
		}
		public Player First { get; }
		public Player Second { get; }
	}
}
