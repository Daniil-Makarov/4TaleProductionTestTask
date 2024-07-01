using Core.Features.Characters.Enemy;
using Core.Features.Characters.Enemy.Configs;
using Core.Services.Storages;
using Plugins.Zenject.Source.Main;
using UnityEngine;
using Zenject;

namespace Core.Services.Factories {
	public class EnemyFactory {
		private IInstantiator instantiator;
		private PrefabsHub prefabsHub;
		private EnemiesStorage enemiesStorage;

		[Inject]
		private void Construct(IInstantiator instantiator, PrefabsHub prefabsHub, EnemiesStorage enemiesStorage) {
			this.instantiator = instantiator;
			this.prefabsHub = prefabsHub;
			this.enemiesStorage = enemiesStorage;
		}
		public void CreateEnemy(EnemyConfig enemyConfig, Transform parent) {
			Enemy enemy = instantiator
				.InstantiatePrefab(prefabsHub.Enemy, parent.position, Quaternion.identity, parent)
				.GetComponent<Enemy>();
			
			enemy.Initialize(enemyConfig);
			enemiesStorage.AddEnemy(enemy);
		}
	}
}