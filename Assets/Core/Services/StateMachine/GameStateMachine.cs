using System;
using System.Collections.Generic;

namespace Core.Services.StateMachine {
	public class GameStateMachine {
		private IState activeState;
		private readonly Dictionary<Type, IState> states = new ();
		
		public void RegisterState<TState>(TState state) where TState : IState => states.Add(typeof(TState), state);
		public void SwitchStateTo<TState>() where TState : IState {
			activeState?.Exit();
			activeState = states[typeof(TState)];
			activeState.Enter();
		}
	}
}