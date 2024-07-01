using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Core.Features.Cards.Commands;
using Core.Features.Cards.Configs;
using Core.Features.Player;
using UnityEngine;
using Zenject;

namespace Core.Features.Cards {
	public class CardCommandsInvoker : MonoBehaviour {
		private const float DelayBetweenCommands = 0.15f;
		
		[SerializeField] private Draggable draggable;
		private List<CardCommand> commands;
		private CardConfig cardConfig;
		private DiscardPile discardPile;
		private EnergyHandler energyHandler;
		private Hand hand;
		private Card card;
		private readonly Queue<CardCommand> nextTurnCommands = new ();

		private bool IsAllCommandsExecutable => commands.All(x => x.CanExecute());

		[Inject]
		private void Construct(DiscardPile discardPile, EnergyHandler energyHandler, Hand hand) {
			this.discardPile = discardPile;
			this.energyHandler = energyHandler;
			this.hand = hand;
		}
		public void Initialize(CardConfig cardConfig, List<CardCommand> commands, Card card) {
			this.cardConfig = cardConfig;
			this.commands = commands;
			this.card = card;
		}
		private void OnEnable() => draggable.DragEnded += StartExecuteCommands;
		private void OnDisable() => draggable.DragEnded -= StartExecuteCommands;
		public void ExecuteNextTurnCommands() {
			while (nextTurnCommands.Count > 0) {
				CardCommand command = nextTurnCommands.Dequeue();
				command.Execute();
			}
		}
		public void ClearNextTurnCommands() => nextTurnCommands.Clear();
		private void MoveToDiscardPile() {
			if (hand.RemoveCard(card)) {
				discardPile.AddCard(card);
			}

			draggable.Unfreeze();
		}
		private void StartExecuteCommands() {
			if (IsAllCommandsExecutable && TryDecreaseEnergy()) {
				draggable.Freeze();
				StartCoroutine(ExecuteCommands());
			}
		}
		private IEnumerator ExecuteCommands() {
			foreach (CardCommand command in commands) {
				if (command.NextTurn) {
					nextTurnCommands.Enqueue(command);
				}
				else {
					command.Execute();
					yield return new WaitForSeconds(DelayBetweenCommands);
				}
			}

			MoveToDiscardPile();
		}
		private bool TryDecreaseEnergy() => energyHandler.TryDecreaseEnergy(cardConfig.EnergyCost);
	}
}