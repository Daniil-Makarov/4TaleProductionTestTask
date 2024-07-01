using Core.Features.Cards;
using Core.Features.Cards.Configs;
using Core.Features.Player;
using Core.Services.Storages;
using UnityEngine;
using Zenject;

namespace Core.Services.Factories {
	public class CardsSpawner : MonoBehaviour {
		[SerializeField] private DrawPile drawPile;
		private PlayerConfig playerConfig;
		private CardFactory cardFactory;
		private CardsStorage cardsStorage;

		[Inject]
		private void Construct(PlayerConfig playerConfig, CardFactory cardFactory, CardsStorage cardsStorage) {
			this.playerConfig = playerConfig;
			this.cardFactory = cardFactory;
			this.cardsStorage = cardsStorage;
		}
		public void SpawnCards() {
			foreach (CardConfig cardConfig in playerConfig.Cards) {
				GameObject cardGameObject = cardFactory.CreateCard(cardConfig, transform);
				
				Card card = cardGameObject.GetComponent<Card>();
				cardsStorage.AddCard(card);
			}
			
			drawPile.AddCards(cardsStorage.Cards);
		} 
	}
}