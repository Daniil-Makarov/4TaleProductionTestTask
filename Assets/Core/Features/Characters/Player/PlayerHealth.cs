using Core.Features.Characters.Common;
using Core.Features.Player;
using Core.Services.StateMachine;
using Core.Services.StateMachine.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.Features.Characters.Player {
	public class PlayerHealth : Health {
		[SerializeField] private Image normal;
		[SerializeField] private GameObject dead;
		private PlayerConfig playerConfig;
		private GameStateMachine gameStateMachine;

		[Inject]
		private void Construct(PlayerConfig playerConfig, GameStateMachine gameStateMachine) {
			this.playerConfig = playerConfig;
			this.gameStateMachine = gameStateMachine;
		}
		protected override int GetMaxHealth() => playerConfig.MaxHealth;
		protected override void Die() {
			normal.enabled = false;
			dead.SetActive(true);
			
			gameStateMachine.SwitchStateTo<GameLoseState>();
		}
	}
}