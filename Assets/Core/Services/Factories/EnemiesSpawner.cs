using Core.Features.Rooms;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.Services.Factories {
	public class EnemiesSpawner : MonoBehaviour {
		[SerializeField] private HorizontalLayoutGroup horizontalLayoutGroup;
		private Progress progress;
		private RoomsConfig roomsConfig;
		private EnemyFactory enemyFactory;
		
		[Inject]
		private void Construct(EnemyFactory enemyFactory, RoomsConfig roomsConfig, Progress progress) {
			this.enemyFactory = enemyFactory;
			this.roomsConfig = roomsConfig;
			this.progress = progress;
		}
		public void SpawnEnemies() {
			horizontalLayoutGroup.enabled = true;
			
			foreach (var enemyConfig in roomsConfig.Rooms[progress.CurrentRoomIndex].EnemyConfigs) {
				enemyFactory.CreateEnemy(enemyConfig, transform);
			}
			
			horizontalLayoutGroup.CalculateLayoutInputHorizontal();
			horizontalLayoutGroup.SetLayoutHorizontal();
			horizontalLayoutGroup.CalculateLayoutInputVertical();
			horizontalLayoutGroup.SetLayoutVertical();
			horizontalLayoutGroup.enabled = false;
		}
	}
}