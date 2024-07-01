using UnityEngine;

namespace Core.Services {
	[CreateAssetMenu(fileName = "PrefabsHub", menuName = "Configs/PrefabsHub")]
	public class PrefabsHub : ScriptableObject {
		public GameObject Player;
		public GameObject Enemy;
		public GameObject Card;
	}
}