using UnityEngine;

namespace Core.Features.Characters.Enemy.Configs {
	[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/Enemy")]
	public class EnemyConfig : ScriptableObject {
		public Sprite Sprite;
		public int MaxHealth;
		public EnemyCommandConfig[] Commands;
		
		private void OnValidate() {
			if (MaxHealth < 1) MaxHealth = 1;
			
			foreach (EnemyCommandConfig commands in Commands) {
				if (commands.Value < 1) commands.Value = 1;
			}
		}
	}
}