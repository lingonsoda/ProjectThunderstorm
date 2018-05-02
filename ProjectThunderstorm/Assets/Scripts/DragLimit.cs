using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragLimit : MonoBehaviour {

	public Vector3[] corners = new Vector3[4];

	void Start(){


		GetComponent<RectTransform>().GetWorldCorners(corners);
		foreach (Vector3 corner in corners) {
		Debug.Log(corner); 
		}
	}

	void Update(){
		
	}

}

