using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBoxCollider : MonoBehaviour {

	public bool playerCollision;

	void Start () 
	{
		playerCollision = false;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag ("Player")) 
		{
			playerCollision = true;
		}
	}
}
