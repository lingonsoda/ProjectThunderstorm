using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public static GameObject itemBeingDragged;
    ArrowColorTrack ArrowColorTrackScript;//
    Vector3 startPosition;
    public static Transform startParent;//Transform startParent

    void Start() {
        ArrowColorTrackScript = GameObject.Find("TilePanel").GetComponent<ArrowColorTrack>();//
    }

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		itemBeingDragged = gameObject;
		startPosition = transform.position;
		startParent = transform.parent;
		GetComponent<CanvasGroup> ().blocksRaycasts = false;
        if (startParent.name.Contains("Panel")) {//
            transform.SetParent(startParent.parent);//
            ArrowColorTrackScript.ColorTrack();//
        }//
    }

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition; 
    }

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		itemBeingDragged = null;
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
        if (transform.parent == startParent.parent) {//
            transform.position = startPosition;//
            transform.SetParent(startParent);//
            ArrowColorTrackScript.ColorTrack();//
        }//
        if (transform.parent == startParent) {
			transform.position = startPosition;
		}
	}

	#endregion
}
