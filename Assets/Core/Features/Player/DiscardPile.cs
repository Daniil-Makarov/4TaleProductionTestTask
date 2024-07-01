using System.Collections.Generic;
using Core.Features.Cards;
using TMPro;
using UnityEngine;

namespace Core.Features.Player {
	public class DiscardPile : MonoBehaviour {
		[SerializeField] private TextMeshProUGUI cardsAmountLabel;
		private readonly Stack<Card> cards = new ();

		public IEnumerable<Card> TakeAllCards() {
			List<Card> allCards = new ();
			while (cards.TryPop(out Card card)) {
				allCards.Add(card);
			}
			UpdateCardsAmountLabel();
			
			return allCards;
		}
		public void AddCard(Card card) {
			MoveCard(card);
			UpdateCardsAmountLabel();
		}
		public void CleanUp() {
			foreach (Card card in cards) {
				Destroy(card.gameObject);
			}

			cards.Clear();
			UpdateCardsAmountLabel();
		}
		private void MoveCard(Card card) {
			cards.Push(card);

			card.gameObject.SetActive(false);
			card.transform.SetParent(transform);
		}
		private void UpdateCardsAmountLabel() => cardsAmountLabel.text = cards.Count.ToString();
	}
}