using System;

namespace Core.Features.Cards.Configs {
	[Serializable]
	public class CardCommandConfig {
		public CardCommandType Type;
		public int Value;
		public bool NextTurn;
	}
}