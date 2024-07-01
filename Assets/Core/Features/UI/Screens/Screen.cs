using UnityEngine;

namespace Core.Features.UI.Screens {
	public abstract class Screen : MonoBehaviour {
		[SerializeField] private GameObject screen;
		
		public void Open() => screen.SetActive(true);
		public void Close() => screen.SetActive(false);
	}
}