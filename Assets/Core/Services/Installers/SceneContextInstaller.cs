using Core.Features.Player;
using Core.Features.UI.Buttons;
using Core.Features.UI.Screens;
using Core.Services.Factories;
using Plugins.Zenject.Source.Install;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Core.Services.Installers {
	public class SceneContextInstaller : MonoInstaller {
		[SerializeField] private EventSystem eventSystem;
		[SerializeField] private GraphicRaycaster graphicRaycaster;
		[SerializeField] private DrawPile drawPile;
		[SerializeField] private Hand hand;
		[SerializeField] private DiscardPile discardPile;
		[SerializeField] private EnergyHandler energyHandler;
		[SerializeField] private EndPlayerTurnButton endPlayerTurnButton;
		[SerializeField] private RoomWinScreen roomWinScreen;
		[SerializeField] private GameWinScreen gameWinScreen;
		[SerializeField] private GameLoseScreen gameLoseScreen;
		[SerializeField] private EnemiesSpawner enemiesSpawner;
		[SerializeField] private CardsSpawner cardsSpawner;
		[SerializeField] private PlayerFactory playerFactory;

		public override void InstallBindings() {
			BindFactories();
			Bind(eventSystem);
			Bind(graphicRaycaster);
			Bind(drawPile);
			Bind(hand);
			Bind(discardPile);
			Bind(energyHandler);
			Bind(endPlayerTurnButton);
			Bind(roomWinScreen);
			Bind(gameWinScreen);
			Bind(gameLoseScreen);
			Bind(enemiesSpawner);
			Bind(cardsSpawner);
		}
		private void BindFactories() {
			Bind<CardFactory>();
			Bind<CardCommandsFactory>();
			Bind<EnemyCommandsFactory>();
			Bind<EnemyFactory>();
			Bind<StateFactory>();
			Bind(playerFactory);
		}
		private void Bind<TService>(TService service) => Container.Bind<TService>().FromInstance(service).AsSingle();
		private void Bind<Service>() => Container.Bind<Service>().AsSingle();
	}
}