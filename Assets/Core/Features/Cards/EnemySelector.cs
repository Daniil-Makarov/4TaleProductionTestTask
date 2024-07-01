using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Core.Features.Cards {
	public class EnemySelector : MonoBehaviour {
		[CanBeNull, HideInInspector] public GameObject SelectedEnemy;

		[SerializeField] private Draggable draggable;
		private GraphicRaycaster raycaster;
		private PointerEventData pointerEventData;
		private readonly List<RaycastResult> results = new ();

		[Inject]
		private void Construct(GraphicRaycaster raycaster, EventSystem eventSystem) {
			this.raycaster = raycaster;
			pointerEventData = new PointerEventData(eventSystem);
		}
		private void OnEnable() => draggable.Dragged += CheckEnemy;
		private void OnDisable() => draggable.Dragged -= CheckEnemy;
		private void CheckEnemy() {
			pointerEventData.position = Input.mousePosition;
			raycaster.Raycast(pointerEventData, results);

			SelectedEnemy = results
				.Select(x => x.gameObject)
				.FirstOrDefault(x => x.CompareTag("Enemy"));
			
			results.Clear();
		}
	}
}