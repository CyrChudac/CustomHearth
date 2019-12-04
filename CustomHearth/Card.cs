using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHearth
{
    public abstract class Card
    {
		public abstract string Name { get; }
		public virtual string Text => "";
		public abstract Rarity Rarity { get; }
		public abstract Class Class { get; }
		public abstract byte Cost { get; set; }
		public virtual bool Collectable => true;
		public virtual string Creator => "Blizz";

		protected List<IEffect> effects { get; private set; } = new List<IEffect>();
		public IEnumerable<IEffect> Effects
		{
			get
			{
				foreach (IEffect te in effects)
					yield return te;
			}
		}

		public bool Echo { get; protected set; } = false;

		public sealed override bool Equals(object obj)
		{
			Card other = (Card)obj;
			return Rarity == other.Rarity &&
				Collectable == other.Collectable &&
				Creator == other.Creator &&
				Name == other.Name &&
				Class == other.Class;
		}

		public sealed override int GetHashCode()
		{
			long result = 13 * (int)Rarity;
			result += (Collectable ? 23 : 5);
			for (int i = 0; i < Creator.Length; i++)
				result += 83 * Creator[i];
			for (int i = 0; i < Name.Length; i++)
				result += 1427 * Name[i];
			result += (int)Class;
			return (int)(result % int.MaxValue);
		}
	}
}
