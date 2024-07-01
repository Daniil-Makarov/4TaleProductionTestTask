using Core.Features.Characters.Player;
using DG.Tweening;
using UnityEngine;

namespace Core.Features.Characters.Enemy.Commands {
	public class EnemyAttackCommand : EnemyCommand {
		private const float TargetOffsetX = 55;
		
		private readonly int damage;
		private readonly Transform transform;
		private readonly PlayerHealth playerHealth;

		public EnemyAttackCommand(int damage, int probability, float duration, IntentActivator intentActivator, 
			Transform transform, PlayerHealth playerHealth) : base(probability, duration, intentActivator) {
			this.damage = damage;
			this.transform = transform;
			this.playerHealth = playerHealth;
		}
		public override void Execute() {
			float startPositionX = transform.position.x;
			transform
				.DOMoveX(transform.position.x - TargetOffsetX, Duration / 2)
				.SetEase(Ease.OutCubic)
				.OnComplete(() => {
					playerHealth.TakeDamage(damage);
					transform.DOMoveX(startPositionX, Duration / 2).SetEase(Ease.Linear);
				});
		}
		public override void ActivateIntent() => IntentActivator.ActivateAttackIntent(damage);
	}
}