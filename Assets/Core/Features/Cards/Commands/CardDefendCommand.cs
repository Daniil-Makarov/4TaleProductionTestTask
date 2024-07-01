using Core.Features.Characters.Player;

namespace Core.Features.Cards.Commands {
	public class CardDefendCommand : CardCommand {
		private readonly int block;
		private readonly PlayerHealth playerHealth;

		public CardDefendCommand(int block, bool nextTurn, PlayerHealth playerHealth) : base(nextTurn) {
			this.block = block;
			this.playerHealth = playerHealth;
		}
		public override void Execute() => playerHealth.AddBlock(block);
		public override bool CanExecute() => true;
	}
}