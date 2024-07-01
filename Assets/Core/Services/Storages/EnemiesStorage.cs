using System.Collections.Generic;
using Core.Features.Characters.Enemy;
using Core.Services.StateMachine;
using Core.Services.StateMachine.States;
using Object = UnityEngine.Object;

namespace Core.Services.Storages {
	public class EnemiesStorage {
		private readonly GameStateMachine gameStateMachine;
		private readonly List<Enemy> enemies = new ();

		public IEnumerable<Enemy> Enemies => enemies;

		public EnemiesStorage(GameStateMachine gameStateMachine) => this.gameStateMachine = gameStateMachine;
		public void AddEnemy(Enemy enemy) => enemies.Add(enemy);
		public void RemoveEnemy(Enemy enemy) {
			enemies.Remove(enemy);

			if (enemies.Count == 0) gameStateMachine.SwitchStateTo<RoomWinState>();
		}
		public void CleanUp() {
			foreach (Enemy enemy in enemies) {
				Object.DestroyImmediate(enemy.gameObject);
			}

			enemies.Clear();
		}
	}
}