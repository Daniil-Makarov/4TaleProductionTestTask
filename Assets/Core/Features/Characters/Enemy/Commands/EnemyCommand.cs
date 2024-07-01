namespace Core.Features.Characters.Enemy.Commands {
	public abstract class EnemyCommand {
		public readonly int Probability;
		public readonly float Duration;
		protected readonly IntentActivator IntentActivator;

		protected EnemyCommand(int probability, float duration, IntentActivator intentActivator) {
			Probability = probability;
			Duration = duration;
			IntentActivator = intentActivator;
		}
		public abstract void Execute();
		public abstract void ActivateIntent();
	}
}