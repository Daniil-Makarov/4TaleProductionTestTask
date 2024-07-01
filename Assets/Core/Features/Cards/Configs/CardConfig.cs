using UnityEngine;

namespace Core.Features.Cards.Configs {
	[CreateAssetMenu(fileName = "CardConfig", menuName = "Configs/Card")]
	public class CardConfig : ScriptableObject {
		[Range(0, 3)] public int EnergyCost;
		public string Title;
		public Sprite Icon;
		[TextArea(1, 5)] public string Description;
		public CardCommandConfig[] Commands;

		private void OnValidate() {
			foreach (CardCommandConfig command in Commands) {
				if (command.Value < 1) command.Value = 1;
			}
		}
	}
}