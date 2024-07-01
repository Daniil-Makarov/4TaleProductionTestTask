using Core.Services.Storages;
using Plugins.Zenject.Source.Main;
using UnityEngine;
using Zenject;

namespace Core.Services.Factories {
	public class PlayerFactory : MonoBehaviour {
		private IInstantiator instantiator;
		private PrefabsHub prefabsHub;
		private PlayerStorage playerStorage;

		[Inject]
		private void Construct(IInstantiator instantiator, PrefabsHub prefabsHub, PlayerStorage playerStorage) {
			this.instantiator = instantiator;
			this.prefabsHub = prefabsHub;
			this.playerStorage = playerStorage;
		}
		public void CreatePlayer() {
			GameObject player = instantiator.InstantiatePrefab(prefabsHub.Player, transform.position, Quaternion.identity, transform);
			playerStorage.SetPlayer(player);
		}
	}
}