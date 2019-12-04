using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomHearth;

namespace Game
{
	class Game
	{
		public Game(Player first, Player second)
		{
			map = new Map(first, second);
			first.contract = new DefaultPlayerContract(first).WithMap(map);
			second.contract = new DefaultPlayerContract(second).WithMap(map);
		}
		public static readonly int TURN_TIME = 90_000;
		public static readonly int MAX_TURNS_COUNT = 90;
		public static readonly int MAX_MANA = 10;
		Player curr, enemy;
		Map map;
		private Player First => map.First;
		private Player Second => map.Second;
		public void Run()
		{
			curr = First;
			enemy = Second;
			int turns = 0;
			while(++turns <= MAX_TURNS_COUNT && First.Alive && Second.Alive)
			{
				TakeTurn();
				TakeTurn();
			}
			GameOver();
		}

		void TakeTurn()
		{

			SwapPlayers();
		}

		void SwapPlayers()
		{
			Player swapper = curr;
			curr = enemy;
			enemy = swapper;
		}

		public void GameOver() {
			
		}
	}
}
