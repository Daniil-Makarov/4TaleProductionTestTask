using Core.Services.StateMachine;
using Core.Services.StateMachine.States;
using TMPro;
using UnityEngine;
using Zenject;

namespace Core.Features.UI.Buttons {
	public class EndPlayerTurnButton : ButtonBase {
		[SerializeField] private TextMeshProUGUI label;
		private GameStateMachine gameStateMachine;

		[Inject]
		private void Construct(GameStateMachine gameStateMachine) => this.gameStateMachine = gameStateMachine;
		public void Activate() {
			Button.interactable = true;
			label.text = "End Turn";
		}
		public void Deactivate() {
			Button.interactable = false;
			label.text = "Enemy Turn";
		}
		protected override void Action() {
			gameStateMachine.SwitchStateTo<EnemyTurnState>();
		}
	}
}