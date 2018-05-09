using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrashCan : MonoBehaviour, IDropHandler {

    void Update() {

        if (this.transform.childCount > 0) {
        Destroy(this.transform.GetChild(0).gameObject);
        }
    }

    public void OnDrop(PointerEventData eventData) {
        if (DragHandler.itemBeingDragged == null) {
            try {
                QuizDragHandler.itemBeingDragged.transform.SetParent(transform);
                return;
            } catch (System.Exception) {
                return;
            }
        }
        if (QuizDragHandler.itemBeingDragged == null) {
            try {
                DragHandler.itemBeingDragged.transform.SetParent(transform);
                return;
            } catch (System.Exception) {
                return;
            }
        }
    }
}
