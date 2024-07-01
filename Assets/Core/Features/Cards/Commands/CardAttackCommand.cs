using System;
using Core.Features.Characters.Common;

namespace Core.Features.Cards.Commands {
	public class CardAttackCommand : CardCommand {
		private readonly EnemySelector enemySelector;
		private readonly int damage;

		public CardAttackCommand(int damage, bool nextTurn, EnemySelector enemySelector) : base(nextTurn) {
			this.damage = damage;
			this.enemySelector = enemySelector;
		}
		public override void Execute() {
			if (!enemySelector.SelectedEnemy) throw new NullReferenceException("Cannot execute attack command without a selected enemy");
			
			Health selectedEnemyHealth = enemySelector.SelectedEnemy.GetComponent<Health>();
			selectedEnemyHealth.TakeDamage(damage);
		}
		public override bool CanExecute() => enemySelector.SelectedEnemy;
	}
}