using TMPro;
using UnityEngine;

namespace Core.Features.Player {
	public class EnergyHandler : MonoBehaviour {
		[SerializeField] private int maxEnergy = 3;
		[SerializeField] private TextMeshProUGUI energyLabel;
		private int currentEnergy;
		
		public void ResetEnergy() {
			currentEnergy = maxEnergy;
			UpdateEnergyLabel();
		}
		public void AddEnergy(int energyAmount) {
			currentEnergy += energyAmount;
			UpdateEnergyLabel();
		}
		public bool TryDecreaseEnergy(int energyAmount) {
			if (currentEnergy >= energyAmount) {
				currentEnergy -= energyAmount;
				UpdateEnergyLabel();

				return true;
			}

			return false;
		}
		private void UpdateEnergyLabel() => energyLabel.text = $"{currentEnergy}/{maxEnergy}";
	}
}