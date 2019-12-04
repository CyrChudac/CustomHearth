using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomHearth;

namespace CardsDatabase.NonClassed
{
	public class Wisp : NeutralMinion
	{
		public override Rarity Rarity => Rarity.Common;

		public override string Name => "Wisp";

		public override byte Cost { get; set; } = 0;

		public override Tribe Tribe => Tribe.Non;

		protected override int InitAttack => 1;
		protected override int InitHealth => 1;
	}
}
