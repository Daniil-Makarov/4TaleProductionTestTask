using Core.Services.Factories;
using Core.Services.StateMachine;
using Core.Services.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Core.Services {
	public class Bootstrapper : MonoBehaviour {
		private GameStateMachine gameStateMachine;
		private StateFactory stateFactory;

		[Inject]
		private void Construct(GameStateMachine gameStateMachine, StateFactory stateFactory, EnemiesSpawner enemiesSpawner) {
			this.gameStateMachine = gameStateMachine;
			this.stateFactory = stateFactory;
		}
		private void Start() {
			RegisterStates();
			gameStateMachine.SwitchStateTo<NewGameState>();
		}
		private void RegisterStates() {
			gameStateMachine.RegisterState(stateFactory.Create<NewGameState>());
			gameStateMachine.RegisterState(stateFactory.Create<StartRoomState>());
			gameStateMachine.RegisterState(stateFactory.Create<PlayerTurnState>());
			gameStateMachine.RegisterState(stateFactory.Create<EnemyTurnState>());
			gameStateMachine.RegisterState(stateFactory.Create<RoomWinState>());
			gameStateMachine.RegisterState(stateFactory.Create<GameWinState>());
			gameStateMachine.RegisterState(stateFactory.Create<GameLoseState>());
			gameStateMachine.RegisterState(stateFactory.Create<CleanupState>());
		}
	}
}