using Core.Features.Characters.Player;
using UnityEngine;

namespace Core.Services.Storages {
	public class PlayerStorage {
		private GameObject player;
		
		public PlayerHealth PlayerHealth { get; private set; }

		public void SetPlayer(GameObject player) {
			this.player = player;
			PlayerHealth = player.GetComponent<PlayerHealth>();
		}
		public void CleanUp() {
			if (player) Object.Destroy(player);
		}
	}
}