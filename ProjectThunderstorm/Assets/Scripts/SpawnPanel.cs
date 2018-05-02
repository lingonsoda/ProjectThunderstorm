using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPanel : MonoBehaviour {

	public GameObject LoopPanel;
	Transform startParent;
	GameObject clone;

	void Start() {
		startParent = this.transform;
	}

	void Update() {
		int count = transform.childCount;
		if (transform.childCount > 6) {
		} else {
			if (transform.GetChild(count -1).childCount > 0) {
				clone = Instantiate (LoopPanel);
				clone.transform.SetParent (startParent, false);
				Debug.Log ("Ny Panel");
			}
		}
	}
}
