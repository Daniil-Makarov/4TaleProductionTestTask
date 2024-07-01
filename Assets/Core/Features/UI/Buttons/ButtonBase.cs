using UnityEngine;
using UnityEngine.UI;

namespace Core.Features.UI.Buttons {
	public abstract class ButtonBase : MonoBehaviour {
		[SerializeField] protected Button Button;
		
		private void OnEnable() => Button.onClick.AddListener(Action);
		private void OnDisable() => Button.onClick.RemoveListener(Action);
		protected abstract void Action();
	}
}