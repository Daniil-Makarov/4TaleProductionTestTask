using Core.Features.Player;

namespace Core.Features.Cards.Commands {
	public class CardDrawCardsCommand : CardCommand {
		private readonly Hand hand;
		private readonly int cardsAmount;
		
		public CardDrawCardsCommand(int cardsAmount, bool nextTurn, Hand hand) : base(nextTurn) {
			this.cardsAmount = cardsAmount;
			this.hand = hand;
		}
		public override void Execute() => hand.StartDrawCards(cardsAmount);
		public override bool CanExecute() => true;
	}
}