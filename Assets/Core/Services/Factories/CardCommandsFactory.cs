using System;
using System.Collections.Generic;
using Core.Features.Cards;
using Core.Features.Cards.Commands;
using Core.Features.Cards.Configs;
using Core.Features.Player;
using Core.Services.Storages;

namespace Core.Services.Factories {
	public class CardCommandsFactory {
		private readonly PlayerStorage playerStorage;
		private readonly Hand hand;
		private readonly EnergyHandler energyHandler;

		public CardCommandsFactory(PlayerStorage playerStorage, Hand hand, EnergyHandler energyHandler) {
			this.playerStorage = playerStorage;
			this.hand = hand;
			this.energyHandler = energyHandler;
		}
		public List<CardCommand> CreateCommands(CardConfig cardConfig, EnemySelector enemySelector) {
			List<CardCommand> commands = new ();

			foreach (CardCommandConfig command in cardConfig.Commands) {
				switch (command.Type) {
					case CardCommandType.Attack:
						commands.Add(new CardAttackCommand(command.Value, command.NextTurn, enemySelector));
						break;
					case CardCommandType.Defend:
						commands.Add(new CardDefendCommand(command.Value, command.NextTurn, playerStorage.PlayerHealth));
						break;
					case CardCommandType.Heal:
						commands.Add(new CardHealCommand(command.Value, command.NextTurn, playerStorage.PlayerHealth));
						break;
					case CardCommandType.DrawCards:
						commands.Add(new CardDrawCardsCommand(command.Value, command.NextTurn, hand));
						break;
					case CardCommandType.IncreaseEnergy:
						commands.Add(new CardIncreaseEnergyCommand(command.Value, command.NextTurn, energyHandler));
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}

			return commands;
		}
	}
}