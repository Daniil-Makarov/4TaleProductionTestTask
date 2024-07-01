using System.Collections.Generic;
using Core.Features.Cards;

namespace Core.Services.Storages {
	public class CardsStorage {
		public readonly List<Card> Cards = new ();
		
		public void AddCard(Card card) => Cards.Add(card);
		public void CleanUp() => Cards.Clear();
	}
}