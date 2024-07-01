using System.Collections.Generic;
using System.Linq;
using Core.Features.Cards;
using Core.Services.Factories;
using TMPro;
using UnityEngine;

namespace Core.Features.Player {
	public class DrawPile : MonoBehaviour {
		[SerializeField] private TextMeshProUGUI cardsAmountLabel;
		[SerializeField] private DiscardPile discardPile;
		private PlayerConfig playerConfig;
		private CardFactory cardFactory;
		private readonly Stack<Card> cards = new ();
		
		public Card TakeCard() {
			if (cards.Count == 0) AddCardsFromDiscardPile();
			
			Card card = cards.Pop();
			UpdateCardsAmountLabel();

			return card;
		}
		public void AddCardsFromDiscardPile() => AddCards(discardPile.TakeAllCards());
		public void AddCards(IEnumerable<Card> cards) {
			foreach (Card card in Shuffle(cards)) {
				MoveCard(card);
			}
			
			UpdateCardsAmountLabel();
		}
		public void CleanUp() {
			foreach (Card card in cards) {
				Destroy(card.gameObject);
			}
			
			cards.Clear();
			UpdateCardsAmountLabel();
		}
		private IEnumerable<Card> Shuffle(IEnumerable<Card> cards) => cards.OrderBy(_ => Random.Range(int.MinValue, int.MaxValue));
		private void MoveCard(Card card) {
			cards.Push(card);
			card.transform.SetParent(transform);
		}
		private void UpdateCardsAmountLabel() => cardsAmountLabel.text = cards.Count.ToString();
	}
}