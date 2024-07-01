using Core.Features.Cards;
using Core.Features.Characters.Enemy;
using Core.Features.Player;
using Core.Features.UI.Buttons;
using Core.Services.Storages;

namespace Core.Services.StateMachine.States {
	public class PlayerTurnState : IState {
		private readonly EndPlayerTurnButton endPlayerTurnButton;
		private readonly EnergyHandler energyHandler;
		private readonly Hand hand;
		private readonly PlayerStorage playerStorage;
		private readonly EnemiesStorage enemiesStorage;
		private readonly CardsStorage cardsStorage;

		public PlayerTurnState(EndPlayerTurnButton endPlayerTurnButton, EnergyHandler energyHandler, Hand hand, 
			PlayerStorage playerStorage, EnemiesStorage enemiesStorage, CardsStorage cardsStorage) {
			this.endPlayerTurnButton = endPlayerTurnButton;
			this.energyHandler = energyHandler;
			this.hand = hand;
			this.playerStorage = playerStorage;
			this.enemiesStorage = enemiesStorage;
			this.cardsStorage = cardsStorage;
		}
		public void Enter() {
			playerStorage.PlayerHealth.ResetBlock();
			energyHandler.ResetEnergy();
			SetEnemiesAction();
			ExecuteNextTurnCommands();
			hand.StartDrawCards(onComplete: endPlayerTurnButton.Activate);
		}
		public void Exit() {
			endPlayerTurnButton.Deactivate();
			hand.MoveCardsToDiscardPile();
		}
		private void SetEnemiesAction() {
			foreach (Enemy enemy in enemiesStorage.Enemies) {
				enemy.CommandInvoker.SetCommand();
			}
		}
		private void ExecuteNextTurnCommands() {
			foreach (Card card in cardsStorage.Cards) {
				card.CardCommandsInvoker.ExecuteNextTurnCommands();
			}
		}
	}
}