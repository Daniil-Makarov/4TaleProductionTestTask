namespace Core.Features.Cards.Commands {
	public abstract class CardCommand {
		public readonly bool NextTurn;

		protected CardCommand(bool nextTurn) => NextTurn = nextTurn;
		public abstract void Execute();
		public abstract bool CanExecute();
	}
}