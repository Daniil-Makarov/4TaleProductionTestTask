using Core.Services.StateMachine;
using Core.Services.StateMachine.States;
using Zenject;

namespace Core.Features.UI.Buttons {
	public class MoveToNextRoomButton : ButtonBase {
		private GameStateMachine gameStateMachine;
		
		[Inject]
		private void Construct(GameStateMachine gameStateMachine) => this.gameStateMachine = gameStateMachine;
		protected override void Action() => gameStateMachine.SwitchStateTo<StartRoomState>();
	}
}