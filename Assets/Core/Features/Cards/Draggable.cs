using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Core.Features.Cards {
	public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler {
		[SerializeField] private Image image;
		private Transform handTransform;
		private HorizontalLayoutGroup horizontalLayoutGroup;
		private bool isActive;
		private bool isDragging;
		private int indexInLayoutGroup;

		public event Action Dragged;
		public event Action DragEnded;

		private void Start() {
			horizontalLayoutGroup = GetComponentInParent<HorizontalLayoutGroup>();
			handTransform = transform.parent;
		}
		public void OnBeginDrag(PointerEventData eventData) => StartDrag();
		public void OnDrag(PointerEventData eventData) {
			Drag();
			Dragged?.Invoke();
		}
		public void OnEndDrag(PointerEventData eventData) {
			DragEnded?.Invoke();
			if (enabled) StopDrag();
		}
		public void OnPointerEnter(PointerEventData eventData) {
			if (!isDragging) ScaleUp();
		}
		public void OnPointerExit(PointerEventData eventData) => ResetScale();
		public void Freeze() {
			enabled = false;
			isDragging = false;
			image.raycastTarget = true;
			horizontalLayoutGroup.enabled = true;
		}
		public void Unfreeze() => enabled = true;
		private void StartDrag() {
			isDragging = true;
			image.raycastTarget = false;
			horizontalLayoutGroup.enabled = false;
			ResetScale();
			indexInLayoutGroup = transform.GetSiblingIndex();
			transform.SetParent(transform.root);
			transform.SetAsLastSibling();
		}
		private void Drag() => transform.position = Input.mousePosition;
		private void StopDrag() {
			isDragging = false;
			image.raycastTarget = true;
			horizontalLayoutGroup.enabled = true;
			transform.SetParent(handTransform);
			transform.SetSiblingIndex(indexInLayoutGroup);
		}
		private void ScaleUp() => transform.localScale = Vector3.one * 1.2f;
		private void ResetScale() => transform.localScale = Vector3.one;
	}
}