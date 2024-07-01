using System;
using System.Collections.Generic;
using Core.Features.Characters.Enemy.Commands;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Features.Characters.Enemy {
	public class EnemyCommandInvoker : MonoBehaviour {
		private List<EnemyCommand> commands;
		
		public EnemyCommand CurrentCommand { get; private set; }

		public void Initialize(List<EnemyCommand> commands) => this.commands = commands;
		public void SetCommand() {
			CurrentCommand = GetRandomCommand();
			CurrentCommand.ActivateIntent();
		}
		public void Execute() => CurrentCommand.Execute();
		private EnemyCommand GetRandomCommand() {
			int random = Random.Range(0, 100);
			foreach (EnemyCommand command in commands) {
				int currentProbability = command.Probability;
				if (random <= currentProbability) {
					return command;
				}

				random -= currentProbability;
			}

			throw new InvalidOperationException("No command found");
		}
	}
}