using TMPro;
using UnityEngine;

namespace Core.Features.Characters.Enemy {
	public class IntentActivator : MonoBehaviour {
		[SerializeField] private GameObject attackIntent;
		[SerializeField] private GameObject defendIntent;
		[SerializeField] private TextMeshProUGUI damageLabel;
		[SerializeField] private TextMeshProUGUI blockLabel;

		public void ActivateAttackIntent(int value) {
			attackIntent.SetActive(true);
			damageLabel.text = value.ToString();
		}
		public void ActivateDefendIntent(int value) {
			defendIntent.SetActive(true);
			blockLabel.text = value.ToString();
		}
		public void DeactivateAll() {
			attackIntent.SetActive(false);
			defendIntent.SetActive(false);
		}
	}
}