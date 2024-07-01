using System.Collections.Generic;
using Core.Features.Cards.Commands;
using Core.Features.Cards.Configs;
using Core.Services.Factories;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.Features.Cards {
	public class Card : MonoBehaviour {
		public CardCommandsInvoker CardCommandsInvoker;
		public Draggable Draggable;
		
		[SerializeField] private TextMeshProUGUI energy;
		[SerializeField] private TextMeshProUGUI title;
		[SerializeField] private Image icon;
		[SerializeField] private TextMeshProUGUI description;
		[SerializeField] private EnemySelector enemySelector;
		private CardCommandsFactory cardCommandsFactory;

		[Inject]
		private void Construct(CardCommandsFactory cardCommandsFactory) => this.cardCommandsFactory = cardCommandsFactory;
		public void Initialize(CardConfig cardConfig) {
			InitializeCommandsInvoker(cardConfig);
			UpdateUI(cardConfig);
		}
		private void InitializeCommandsInvoker(CardConfig cardConfig) {
			List<CardCommand> commands = cardCommandsFactory.CreateCommands(cardConfig, enemySelector);
			CardCommandsInvoker.Initialize(cardConfig, commands, this);
		}
		private void UpdateUI(CardConfig cardConfig) {
			energy.text = cardConfig.EnergyCost.ToString();
			title.text = cardConfig.Title;
			icon.sprite = cardConfig.Icon;
			description.text = cardConfig.Description;
		}
	}
}