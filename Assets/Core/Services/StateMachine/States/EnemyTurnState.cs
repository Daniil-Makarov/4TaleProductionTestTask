using System.Collections;
using Core.Features.Characters.Enemy;
using Core.Services.Storages;
using UnityEngine;

namespace Core.Services.StateMachine.States {
	public class EnemyTurnState : IState {
		private Coroutine enemiesGameLoop;
		private readonly GameStateMachine gameStateMachine;
		private readonly EnemiesStorage enemiesStorage;
		private readonly CoroutineRunner coroutineRunner;

		public EnemyTurnState(EnemiesStorage enemiesStorage, GameStateMachine gameStateMachine, CoroutineRunner coroutineRunner) {
			this.enemiesStorage = enemiesStorage;
			this.gameStateMachine = gameStateMachine;
			this.coroutineRunner = coroutineRunner;
		}
		public void Enter() => enemiesGameLoop = coroutineRunner.StartCoroutine(EnemiesGameLoop());
		public void Exit() {
			if (enemiesGameLoop != null) {
				coroutineRunner.StopCoroutine(enemiesGameLoop);
			}
		}
		private IEnumerator EnemiesGameLoop() {
			foreach (Enemy enemy in enemiesStorage.Enemies) {
				enemy.Health.ResetBlock();
				enemy.CommandInvoker.Execute();
				enemy.IntentActivator.DeactivateAll();
				
				float commandDuration = enemy.CommandInvoker.CurrentCommand.Duration;
				if (commandDuration > 0) {
					yield return new WaitForSeconds(commandDuration);
				}
			}
			
			gameStateMachine.SwitchStateTo<PlayerTurnState>();
		}
	}
}