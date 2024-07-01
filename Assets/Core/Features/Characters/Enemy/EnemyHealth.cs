using Core.Features.Characters.Common;
using Core.Features.Characters.Enemy.Configs;
using Core.Services.Storages;
using Zenject;

namespace Core.Features.Characters.Enemy {
	public class EnemyHealth : Health {
		private EnemyConfig enemyConfig;
		private Enemy enemy;
		private EnemiesStorage enemiesStorage;

		[Inject]
		private void Construct(EnemiesStorage enemiesStorage) => this.enemiesStorage = enemiesStorage;
		public void Initialize(EnemyConfig enemyConfig, Enemy enemy) {
			this.enemyConfig = enemyConfig;
			this.enemy = enemy;
		}
		protected override int GetMaxHealth() => enemyConfig.MaxHealth;
		protected override void Die() {
			enemiesStorage.RemoveEnemy(enemy);
			Destroy(gameObject);
		}
	}
}