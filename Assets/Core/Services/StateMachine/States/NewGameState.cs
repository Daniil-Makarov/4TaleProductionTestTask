using Core.Services.Factories;

namespace Core.Services.StateMachine.States {
	public class NewGameState : IState {
		private readonly GameStateMachine gameStateMachine;
		private readonly CardsSpawner cardsSpawner;
		private readonly PlayerFactory playerFactory;

		public NewGameState(GameStateMachine gameStateMachine, CardsSpawner cardsSpawner, PlayerFactory playerFactory) {
			this.gameStateMachine = gameStateMachine;
			this.cardsSpawner = cardsSpawner;
			this.playerFactory = playerFactory;
		}
		public void Enter() {
			playerFactory.CreatePlayer();
			cardsSpawner.SpawnCards();
			gameStateMachine.SwitchStateTo<StartRoomState>();
		}
		public void Exit() {}
	}
}