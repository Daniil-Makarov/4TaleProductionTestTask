using System;
using System.Collections.Generic;
using Core.Features.Characters.Enemy;
using Core.Features.Characters.Enemy.Commands;
using Core.Features.Characters.Enemy.Configs;
using Core.Services.Storages;

namespace Core.Services.Factories {
	public class EnemyCommandsFactory {
		private readonly PlayerStorage playerStorage;
		
		public EnemyCommandsFactory(PlayerStorage playerStorage) => this.playerStorage = playerStorage;
		public List<EnemyCommand> CreateCommands(EnemyConfig enemyConfig, Enemy enemy) {
			List<EnemyCommand> commands = new ();

			foreach (EnemyCommandConfig command in enemyConfig.Commands) {
				switch (command.Type) {
					case EnemyCommandType.Attack:
						commands.Add(new EnemyAttackCommand(command.Value, command.Probability, duration: 1, enemy.IntentActivator, enemy.transform, playerStorage.PlayerHealth));
						break;
					case EnemyCommandType.Defend:
						commands.Add(new EnemyDefendCommand(command.Value, command.Probability, duration: 0, enemy.IntentActivator, enemy.Health));
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}

			return commands;
		}
	}
}