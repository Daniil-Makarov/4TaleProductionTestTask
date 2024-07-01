using Core.Features.UI.Screens;

namespace Core.Services.StateMachine.States {
	public class GameLoseState : IState {
		private readonly GameLoseScreen gameLoseScreen;
		
		public GameLoseState(GameLoseScreen gameLoseScreen) => this.gameLoseScreen = gameLoseScreen;
		public void Enter() => gameLoseScreen.Open();
		public void Exit() {}
	}
}