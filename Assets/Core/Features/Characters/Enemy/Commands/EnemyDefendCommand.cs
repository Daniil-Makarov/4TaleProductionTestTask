namespace Core.Features.Characters.Enemy.Commands {
	public class EnemyDefendCommand : EnemyCommand {
		private readonly int block;
		private readonly EnemyHealth enemyHealth;
		
		public EnemyDefendCommand(int block, int probability, float duration, IntentActivator intentActivator, 
			EnemyHealth enemyHealth) : base(probability, duration, intentActivator) {
			this.block = block;
			this.enemyHealth = enemyHealth;
		}
		public override void Execute() => enemyHealth.AddBlock(block);
		public override void ActivateIntent() => IntentActivator.ActivateDefendIntent(block);
	}
}