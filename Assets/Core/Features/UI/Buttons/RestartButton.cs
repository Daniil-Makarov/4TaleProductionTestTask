using Core.Services.StateMachine;
using Core.Services.StateMachine.States;
using UnityEngine;
using Zenject;
using Screen = Core.Features.UI.Screens.Screen;

namespace Core.Features.UI.Buttons {
	public class RestartButton : ButtonBase {
		[SerializeField] private Screen screen;
		private GameStateMachine gameStateMachine;

		[Inject]
		private void Construct(GameStateMachine gameStateMachine) => this.gameStateMachine = gameStateMachine;
		protected override void Action() {
			screen.Close();
			gameStateMachine.SwitchStateTo<CleanupState>();
		}
	}
}