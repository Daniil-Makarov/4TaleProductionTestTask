using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Features.Characters.Common {
	public abstract class Health : MonoBehaviour {
		[SerializeField] private Slider healthSlider;
		[SerializeField] private TextMeshProUGUI healthLabel;
		[SerializeField] private GameObject blockBackground;
		[SerializeField] private TextMeshProUGUI blockLabel;
		private int maxHealth;
		private int currentHealth;
		private int block;

		private void Start() {
			maxHealth = GetMaxHealth();
			currentHealth = maxHealth;
			healthSlider.maxValue = maxHealth;
			healthSlider.value = currentHealth;
			UpdateHealth();
		}
		public void TakeDamage(int damage) {
			currentHealth -= Mathf.Max(0, damage - block);
			block = Mathf.Max(0, block - damage);

			if (currentHealth <= 0) {
				currentHealth = 0;
				Die();
			}

			UpdateUI();
		}
		public void AddBlock(int block) {
			this.block += block;
			UpdateBlock();
		}
		public void ResetBlock() {
			block = 0;
			UpdateBlock();
		}
		public void Heal(int heal) {
			currentHealth = Mathf.Min(maxHealth, currentHealth + heal);
			UpdateHealth();
		}
		protected abstract int GetMaxHealth();
		protected abstract void Die();
		private void UpdateUI() {
			UpdateHealth();
			UpdateBlock();
		}
		private void UpdateHealth() {
			healthSlider.value = currentHealth;
			healthLabel.text = $"{currentHealth}/{maxHealth}";
		}
		private void UpdateBlock() {
			blockLabel.text = block.ToString();
			blockBackground.SetActive(block > 0);
		}
	}
}