using Core.Features.Player;
using Core.Features.Rooms;
using Core.Services.Factories;

namespace Core.Services.StateMachine.States {
	public class StartRoomState : IState {
		private readonly EnemyFactory enemyFactory;
		private readonly GameStateMachine gameStateMachine;
		private readonly RoomsConfig roomsConfig;
		private readonly Progress progress;
		private readonly EnemiesSpawner enemiesSpawner;
		private readonly DrawPile drawPile;

		public StartRoomState(GameStateMachine gameStateMachine, EnemiesSpawner enemiesSpawner, DrawPile drawPile) {
			this.gameStateMachine = gameStateMachine;
			this.enemiesSpawner = enemiesSpawner;
			this.drawPile = drawPile;
		}
		public void Enter() {
			enemiesSpawner.SpawnEnemies();
			drawPile.AddCardsFromDiscardPile();
			gameStateMachine.SwitchStateTo<PlayerTurnState>();
		}
		public void Exit() {}
	}
}