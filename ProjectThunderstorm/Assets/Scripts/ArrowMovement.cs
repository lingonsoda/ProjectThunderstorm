using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour {

	//public GameObject arrow;

	private bool arrowMarked;

	void Awake()
	{
		arrowMarked = false;
	}

	void Update()
	{
		moveWithMouse ();
	}

	void OnMouseOver()
	{
		arrowMarked = true;
	}

	void OnMouseExit()
	{
		if (!Input.GetMouseButton (0)) 
		{
			arrowMarked = false;
		}
	}

	public void moveWithMouse()
	{
		if (arrowMarked && Input.GetMouseButton (0)) 
		{
			Vector3 pos = Input.mousePosition;
			pos.z = transform.position.z - Camera.main.transform.position.z;
			transform.position = Camera.main.ScreenToWorldPoint (pos);
		}
	}
}
