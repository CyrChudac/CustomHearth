using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHearth
{
	public abstract class InputGetter
	{
		public abstract IInput GetInput();
		public abstract IUnit GetOneOf(IEnumerable<IUnit> units);
	}

	public interface IInput { }

	public sealed class Play : IInput
	{
		public Play(byte index) { Index = index; }
		public byte Index { get; private set; }
	}
	public sealed class Attack : IInput
	{
		public Attack(byte index) { Index = index; }
		public byte Index { get; private set; }
	}
}
