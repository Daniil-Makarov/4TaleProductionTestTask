using Core.Features.UI.Screens;

namespace Core.Services.StateMachine.States {
	public class GameWinState : IState {
		private readonly GameWinScreen gameWinScreen;
		
		public GameWinState(GameWinScreen gameWinScreen) => this.gameWinScreen = gameWinScreen;
		public void Enter() => gameWinScreen.Open();
		public void Exit() {}
	}
}