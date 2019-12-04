using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHearth
{
	public static class CommonConditions
	{
		public static bool HasNoDuplicates(List<Card> cards)
		{
			for (int i = 0; i < cards.Count; i++)
			{
				for (int j = 0; j < i; j++)
				{
					if (cards[i].Equals(cards[j]))
						return false;
				}
			}
			return true;
		}
	}
}
