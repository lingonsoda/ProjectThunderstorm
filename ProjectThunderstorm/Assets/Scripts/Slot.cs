using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler {
    ArrowColorTrack ArrowColorTrackScript;
    AudioSource audio;

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
            try {
                Destroy(QuizDragHandler.itemBeingDragged.gameObject);
                return;
            } catch (System.Exception) {
                return;
            } 
        }
        audio = DragHandler.itemBeingDragged.GetComponent<AudioSource>();
        if (item && item.name.Contains("Arrow")) {
            if (DragHandler.itemBeingDragged.transform.parent.name.Contains("Arrow")) {
                Destroy(item);
                DragHandler.itemBeingDragged.transform.SetParent(transform);
                audio.pitch = Random.Range(0.95f, 1.05f);
                audio.Play();
                ArrowColorTrackScript.refresh = 1;
                ArrowColorTrackScript.ColorTrack();
                return;
            }
            if (DragHandler.itemBeingDragged.transform.parent.name.Contains("Tile") && item.transform.parent.name.Contains("Arrow")) {
                Destroy(DragHandler.itemBeingDragged.gameObject);
                return;
            }
            item.transform.SetParent(DragHandler.startParent);
            DragHandler.itemBeingDragged.transform.SetParent(transform);
        }
        if (!item) {
            DragHandler.itemBeingDragged.transform.SetParent(transform);
        }
        audio.pitch = Random.Range(0.95f, 1.05f);
        audio.Play();
        ArrowColorTrackScript.ColorTrack();

    }

	#endregion
}

