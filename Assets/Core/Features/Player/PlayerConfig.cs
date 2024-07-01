using Core.Features.Cards.Configs;
using UnityEngine;

namespace Core.Features.Player {
	[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/Player")]
	public class PlayerConfig : ScriptableObject {
		public int MaxHealth;
		public CardConfig[] Cards;

		private void OnValidate() {
			if (MaxHealth < 1) MaxHealth = 1;
		}
	}
}