using Core.Features.Rooms;
using Core.Features.UI.Screens;
using Core.Services.Storages;

namespace Core.Services.StateMachine.States {
	public class RoomWinState : IState {
		private readonly GameStateMachine gameStateMachine;
		private readonly Progress progress;
		private readonly RoomsConfig roomsConfig;
		private readonly RoomWinScreen roomWinScreen;
		private readonly CardsStorage cardsStorage;

		public RoomWinState(GameStateMachine gameStateMachine, Progress progress, RoomsConfig roomsConfig, RoomWinScreen roomWinScreen, CardsStorage cardsStorage) {
			this.gameStateMachine = gameStateMachine;
			this.progress = progress;
			this.roomsConfig = roomsConfig;
			this.roomWinScreen = roomWinScreen;
			this.cardsStorage = cardsStorage;
		}
		public void Enter() {
			if (progress.CurrentRoom >= roomsConfig.Rooms.Length) {
				gameStateMachine.SwitchStateTo<GameWinState>();
			}
			else {
				ClearNextTurnCommands();
				progress.MoveToNextRoom();
				roomWinScreen.Open();
			}
		}
		public void Exit() => roomWinScreen.Close();
		private void ClearNextTurnCommands() => cardsStorage.Cards.ForEach(card => card.CardCommandsInvoker.ClearNextTurnCommands());
	}
}