using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHearth
{
	public static class Random
	{
		static System.Random r = new System.Random();
		public static int Get()
			=> r.Next();
	}
}
