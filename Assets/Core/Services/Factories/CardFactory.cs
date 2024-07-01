using Core.Features.Cards;
using Core.Features.Cards.Configs;
using Plugins.Zenject.Source.Main;
using UnityEngine;

namespace Core.Services.Factories {
	public class CardFactory {
		private readonly IInstantiator instantiator;
		private readonly PrefabsHub prefabsHub;

		private CardFactory(IInstantiator instantiator, PrefabsHub prefabsHub) {
			this.instantiator = instantiator;
			this.prefabsHub = prefabsHub;
		}
		public GameObject CreateCard(CardConfig cardConfig, Transform parent) {
			GameObject cardGameObject = instantiator.InstantiatePrefab(prefabsHub.Card, parent.position, Quaternion.identity, parent);
			cardGameObject.SetActive(false);
			
			Card card = cardGameObject.GetComponent<Card>();
			card.Initialize(cardConfig);

			return cardGameObject;
		}
	}
}