using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHearth
{
	public class SimpleBattlecryInfo : EffectInfo
	{
		public SimpleBattlecryInfo(int indexOnBoard, IEnvirContract contract, Player from) : base(contract, from)
		{
			this.IndexOnBoard = indexOnBoard;
		}
		public readonly int IndexOnBoard;
	}
}
