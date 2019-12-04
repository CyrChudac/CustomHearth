using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomHearth;

namespace Game
{
	class DefaultPlayerLogic : IPlayerLogic
	{
		public DefaultPlayerLogic(Player player)
			=> this.Player = player;
		private Player Player;

		void DrawCard() => DrawCard(c => true);
		void DrawCard(Predicate<Card> condition)
		{
			for (int i = 0; i < Player.Deck.Count; i++)
				if (condition(Player.Deck[i]))
				{
					AddToHand(Player.Deck[i]);
					Player.Deck.RemoveAt(i);
					break;
				}
		}

		void ShuffleCards(params Card[] cards) 
			=> ShuffleCards(cardsList: cards);
		void ShuffleCards(IEnumerable<Card> cardsList)
		{
			if (Player.Deck.Count <= Player.MAX_DECK_SIZE)
			{
				List<Card> newDeck = new List<Card>();
				foreach(Card c in cardsList)
					Player.Deck.Add(c);

				while (Player.Deck.Any())
				{
					int index = CustomHearth.Random.Get() % Player.Deck.Count;
					newDeck.Add(Player.Deck[index]);
					Player.Deck.RemoveAt(index);
				}
			}
		}

		public void AddToHand(Card card) {
			Player.Hand.Add(card);
		}
		public void AddToHand(IEnumerable<Card> cardsList)
		{
			foreach (Card c in cardsList)
				AddToHand(c);
		}
		public void AddToHand(params Card[] cards)
			=> AddToHand(cardsList: cards);
	}
}
