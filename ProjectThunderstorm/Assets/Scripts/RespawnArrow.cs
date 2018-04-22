using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnArrow : MonoBehaviour {
	public GameObject itemBeingDragged;
    GameObject clone;
    Transform startParent;

    void Start() {
        startParent = this.transform;
    }

    void Update() {
        if (transform.childCount > 0) {
        } else {
            clone = Instantiate(itemBeingDragged);
            clone.transform.SetParent(startParent, false);
            Debug.Log("Ny Pil");
        }
    }

}
