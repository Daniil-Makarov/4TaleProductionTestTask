using Core.Features.Characters.Player;

namespace Core.Features.Cards.Commands {
	public class CardHealCommand : CardCommand {
		private readonly int heal;
		private readonly PlayerHealth playerHealth;

		public CardHealCommand(int heal, bool nextTurn, PlayerHealth playerHealth) : base(nextTurn) {
			this.heal = heal;
			this.playerHealth = playerHealth;
		}
		public override void Execute() => playerHealth.Heal(heal);
		public override bool CanExecute() => true;
	}
}