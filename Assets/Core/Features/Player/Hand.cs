using System;
using System.Collections;
using System.Collections.Generic;
using Core.Features.Cards;
using UnityEngine;

namespace Core.Features.Player {
	public class Hand : MonoBehaviour {
		[SerializeField] private int amountCardsToDraw = 5;
		[SerializeField] private DrawPile drawPile;
		[SerializeField] private DiscardPile discardPile;
		private readonly List<Card> cards = new ();

		public void StartDrawCards(Action onComplete) => StartCoroutine(DrawCards(amountCardsToDraw, onComplete));
		public void StartDrawCards(int cardsAmount) => StartCoroutine(DrawCards(cardsAmount));
		public bool RemoveCard(Card card) => cards.Remove(card);
		public void MoveCardsToDiscardPile() {
			foreach (Card card in cards) {
				discardPile.AddCard(card);
				card.Draggable.Unfreeze();
			}
			
			cards.Clear();
		}
		public void CleanUp() {
			foreach (Card card in cards) {
				Destroy(card.gameObject);
			}

			cards.Clear();
		}
		private IEnumerator DrawCards(int cardsAmount, Action onComplete = null) {
			for (int i = 0; i < cardsAmount; i++) {
				DrawCard();
				yield return new WaitForSeconds(0.1f);
			}
			
			onComplete?.Invoke();
		}
		private void DrawCard() {
			Card card = drawPile.TakeCard();
			cards.Add(card);
			
			card.transform.SetParent(transform);
			card.gameObject.SetActive(true);
		}
	}
}