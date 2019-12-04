using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHearth
{
    public class Player : IUnit
	{
		public static readonly byte DEFAULT_DECK_SIZE = 30;
		public static readonly byte MAX_DECK_SIZE = 60;
		public static readonly byte MAX_HAND_SIZE = 10;
		public static readonly byte MAX_BOARD_SIZE = 7;
		public static readonly int DEFAULT_STARTING_HEALTH = 30;

		public bool Taunt => false;
		public bool DivineShield => false;
		public bool Poisonous => Weapon.Poisonous;
		public bool Charge => Weapon.Charge;
		public bool Lifesteal => Weapon.Lifesteal;
		public bool Rush => Weapon.Rush;
		public bool Windfury => Weapon.Windfury;
		public bool MegaWindfury => Weapon.MegaWindfury;
		public bool Stealth { get; private set; } = false;
		public bool Reborn => false;
		public bool CantBeTargeted { get; private set; } = false;

		public void Attacked(int strength)
		{
			DamageMe(strength);
		}

		public Player(Hero hero, List<Card> deck, IPlayerLogic logic, InputGetter inputGetter)
		{
			this.Hero = hero;
			this.Deck = deck;
			this.logic = logic;
			this.InputGetter = inputGetter;
		}
		public InputGetter InputGetter { get; }
		public List<Card> Deck;
		public List<Card> Hand = new List<Card>();
		public List<IBoardable> Board = new List<IBoardable>();
		public byte SpellDamage { get
			{
				byte value = 0;
				foreach (var m in Board)
					if (m is Minion)
						value += ((Minion)m).SpellDamage;
				value += (byte)(Hero.SpellDamage + Weapon.SpellDamage);
				return value;
			} }
		public Weapon Weapon = null;
		public Hero Hero;
		public Tribe Tribe => Hero.Tribe;
		public Class Class => Hero.Class;
		public int MaxHealth = DEFAULT_STARTING_HEALTH;
		public int CurrHealth { get; private set; } = DEFAULT_STARTING_HEALTH;
		public void DamageMe(int damage)
		{
			if (damage >= 0)
				Armor -= damage;
			if (Armor < 0)
			{
				CurrHealth += Armor;
				Armor = 0;
			}
			else
				throw new ArgumentException("Trying to heal by dealing damage. Use 'Healed' function instead.");
		}
		public void Healed(int heal)
		{
			if (heal >= 0)
				CurrHealth += heal;
			else
				throw new ArgumentException("Trying to deal damage by healing. Use 'Damaged' function instead.");
		}

		public void DestroyMe(IEnvirContract contract)
		{
			CurrHealth = -8640;

		}

		public int AttackBonus { set; private get; } = 0;
		public int Attack => Weapon is null ? AttackBonus : Weapon.Attack + AttackBonus;
		public int Armor = 0;
		public bool Alive => CurrHealth > 0;

		Player IUnit.Player => this;

		public IEnvirContract contract { protected get; set; }

		IPlayerLogic logic;

		public void AddToHand(Card card)
			=> logic.AddToHand(card);
		public void AddToHand(IEnumerable<Card> cardsList)
			=> logic.AddToHand(cardsList);
		public void AddToHand(params Card[] cards)
			=> logic.AddToHand(cards: cards);

		public bool CanAttack<WHAT>() where WHAT : IUnit
			=> (Attack > 0) &&
			((timesAttacked < 1) ||
			((timesAttacked < 2) && (Windfury == true)) ||
			((timesAttacked < 4) && (MegaWindfury == true)) ||
			((timesAttacked == Minion.DefaultTimesAttacked) &&
			(Charge || (typeof(Player).IsSubclassOf(typeof(WHAT)) && Rush))));

		int timesAttacked = Minion.DefaultTimesAttacked;

		public bool DeckHasNoDuplicates
			=> CommonConditions.HasNoDuplicates(Deck);

		public bool IsHoldingDragon
			=> Hand.Where(c => c is Minion && ((Minion)c).Tribe == Tribe.Dragon).Count() < 0;

		public bool PlayedElementalLastTurn
			=> throw new NotImplementedException();

	}

	public interface IPlayerLogic {
		void AddToHand(Card card);
		void AddToHand(IEnumerable<Card> cardsList);
		void AddToHand(params Card[] cards);
	}
}
