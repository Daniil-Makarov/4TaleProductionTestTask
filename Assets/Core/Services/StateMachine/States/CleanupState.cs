using Core.Features.Player;
using Core.Services.Storages;

namespace Core.Services.StateMachine.States {
	public class CleanupState : IState {
		private readonly GameStateMachine gameStateMachine;
		private readonly PlayerStorage playerStorage;
		private readonly EnemiesStorage enemiesStorage;
		private readonly CardsStorage cardsStorage;
		private readonly DrawPile drawPile;
		private readonly Hand hand;
		private readonly DiscardPile discardPile;
		private readonly Progress progress;

		public CleanupState(GameStateMachine gameStateMachine, Progress progress, PlayerStorage playerStorage, 
			EnemiesStorage enemiesStorage, CardsStorage cardsStorage, DrawPile drawPile, Hand hand, DiscardPile discardPile) {
			this.gameStateMachine = gameStateMachine;
			this.progress = progress;
			this.playerStorage = playerStorage;
			this.enemiesStorage = enemiesStorage;
			this.cardsStorage = cardsStorage;
			this.drawPile = drawPile;
			this.hand = hand;
			this.discardPile = discardPile;
		}
		public void Enter() {
			playerStorage.CleanUp();
			enemiesStorage.CleanUp();
			cardsStorage.CleanUp();
			drawPile.CleanUp();
			hand.CleanUp();
			discardPile.CleanUp();
			progress.Reset();
			
			gameStateMachine.SwitchStateTo<NewGameState>();
		}
		public void Exit() {}
	}
}