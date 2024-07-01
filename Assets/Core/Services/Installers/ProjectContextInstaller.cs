using Core.Features.Player;
using Core.Features.Rooms;
using Core.Services.StateMachine;
using Core.Services.Storages;
using Plugins.Zenject.Source.Install;
using UnityEngine;

namespace Core.Services.Installers {
	public class ProjectContextInstaller : MonoInstaller {
		[SerializeField] private PrefabsHub prefabsHub;
		[SerializeField] private RoomsConfig roomsConfig;
		[SerializeField] private PlayerConfig playerConfig;
		[SerializeField] private CoroutineRunner coroutineRunner;
		
		public override void InstallBindings() {
			BindConfigs();
			Bind<GameStateMachine>();
			Bind<Progress>();
			Bind<PlayerStorage>();
			Bind<EnemiesStorage>();
			Bind<CardsStorage>();
			Bind(coroutineRunner);
		}
		private void BindConfigs() {
			Bind(prefabsHub);
			Bind(roomsConfig);
			Bind(playerConfig);
		}
		private void Bind<TService>(TService service) => Container.Bind<TService>().FromInstance(service).AsSingle();
		private void Bind<Service>() => Container.Bind<Service>().AsSingle();
	}
}