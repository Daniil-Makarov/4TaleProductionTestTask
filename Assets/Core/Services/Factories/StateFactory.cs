using Core.Services.StateMachine;
using Plugins.Zenject.Source.Main;

namespace Core.Services.Factories {
	public class StateFactory {
		private readonly IInstantiator instantiator;

		public StateFactory(IInstantiator instantiator) => this.instantiator = instantiator;
		public TState Create<TState>() where TState : IState => instantiator.Instantiate<TState>();
	}
}