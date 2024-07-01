using System.Collections.Generic;
using Core.Features.Characters.Enemy.Commands;
using Core.Features.Characters.Enemy.Configs;
using Core.Services.Factories;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.Features.Characters.Enemy {
	public class Enemy : MonoBehaviour {
		public EnemyCommandInvoker CommandInvoker;
		public IntentActivator IntentActivator;
		public EnemyHealth Health;
		
		[SerializeField] private Image image;
		private EnemyCommandsFactory commandsFactory;

		[Inject]
		private void Construct(EnemyCommandsFactory commandsFactory) => this.commandsFactory = commandsFactory;
		public void Initialize(EnemyConfig enemyConfig) {
			UpdateUI(enemyConfig);
			Health.Initialize(enemyConfig, this);
			
			List<EnemyCommand> commands = commandsFactory.CreateCommands(enemyConfig, this);
			CommandInvoker.Initialize(commands);
		}
		private void UpdateUI(EnemyConfig enemyConfig) => image.sprite = enemyConfig.Sprite;
	}
}