using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler {
    ArrowColorTrack ArrowColorTrackScript;

    void Start() {
        ArrowColorTrackScript = GameObject.Find("TilePanel").GetComponent<ArrowColorTrack>();
    }

    public GameObject item {
		get {
		if (transform.childCount>0){
				return transform.GetChild (0).gameObject;
			}
			return null;
		}
		
	}

    #region IDropHandler implementation

    public void OnDrop (PointerEventData eventData)
	{
        if (DragHandler.itemBeingDragged == null) {
            Destroy(QuizDragHandler.itemBeingDragged.gameObject);
            return;
        }
        if (item && item.name.Contains("Arrow")) {//
            if (DragHandler.itemBeingDragged.transform.parent.name.Contains("Arrow")) {
                Destroy(item);
                DragHandler.itemBeingDragged.transform.SetParent(transform);
                ArrowColorTrackScript.refresh = 1;
                ArrowColorTrackScript.ColorTrack();
                return;
            }
            item.transform.SetParent(DragHandler.startParent);//
            DragHandler.itemBeingDragged.transform.SetParent(transform);//
        }//
        if (!item) {
            DragHandler.itemBeingDragged.transform.SetParent(transform);
        }
        ArrowColorTrackScript.ColorTrack();

    }

	#endregion
}

