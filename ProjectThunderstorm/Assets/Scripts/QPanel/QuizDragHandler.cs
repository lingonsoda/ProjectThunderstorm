using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuizDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    Transform startParent;
    public static int number;

    void Start() {

    }

    public static int getNumber() {
        if (itemBeingDragged.name.Contains("One")) {
            int number = 1;
            return number;
        }
        if (itemBeingDragged.name.Contains("Two")) {
            int number = 2;
            return number;
        }
        if (itemBeingDragged.name.Contains("Three")) {
            int number = 3;
            return number;
        }
        if (itemBeingDragged.name.Contains("Four")) {
            int number = 4;
            return number;
        }
        return number;
    }

    #region IBeginDragHandler implementation

    public void OnBeginDrag(PointerEventData eventData) {
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    #endregion

    #region IDragHandler implementation

    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
    }

    #endregion

    #region IEndDragHandler implementation

    public void OnEndDrag(PointerEventData eventData) {
        itemBeingDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent == startParent) {
            transform.position = startPosition;
        }
    }

    #endregion
}
