using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragLimiter : MonoBehaviour, IPointerDownHandler, IDragHandler{


	public Vector3[] corners = new Vector3[4];
	public DragLimit other;
	private RectTransform panelRectTransform;
	private Vector2 pointerOffset;




	void Start () {
		panelRectTransform = transform as RectTransform;
	}
	

	public void OnPointerDown (PointerEventData data) {
		panelRectTransform.SetAsLastSibling ();
		RectTransformUtility.ScreenPointToLocalPointInRectangle (panelRectTransform, data.position, data.pressEventCamera, out pointerOffset);
	}

	public void OnDrag (PointerEventData data) {
		if (panelRectTransform == null)
			return;

		Vector2 pointerPosition = ClampToWindow (data);

		Vector2 localPointerPosition;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (
			panelRectTransform, pointerPosition, data.pressEventCamera, out localPointerPosition)) {
			panelRectTransform.localPosition = localPointerPosition + pointerOffset;
		}

	}


	Vector2 ClampToWindow (PointerEventData data) {
		Vector2 rawPointerPosition = data.position;

		corners = other.corners;

		float clampedX = Mathf.Clamp (rawPointerPosition.x, corners [0].x, corners [2].x);
		float clampedY = Mathf.Clamp (rawPointerPosition.y, corners [0].x, corners [2].y);

		Vector2 newPointerPosition = new Vector2 (clampedX, clampedY);
		return newPointerPosition;
	}
}
