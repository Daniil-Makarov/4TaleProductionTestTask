using Core.Features.Player;

namespace Core.Features.Cards.Commands {
	public class CardIncreaseEnergyCommand : CardCommand {
		private readonly int energyAmount;
		private readonly EnergyHandler energyHandler;
		
		public CardIncreaseEnergyCommand(int energyAmount, bool nextTurn, EnergyHandler energyHandler) : base(nextTurn) {
			this.energyAmount = energyAmount;
			this.energyHandler = energyHandler;
		}
		public override void Execute() => energyHandler.AddEnergy(energyAmount);
		public override bool CanExecute() => true;
	}
}