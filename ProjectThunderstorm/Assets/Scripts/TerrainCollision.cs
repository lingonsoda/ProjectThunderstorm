using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainCollision : MonoBehaviour {

	private PlayerController playerController;

	void Start ()
	{
		playerController = GetComponentInParent<PlayerController> ();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag ("Obstacle")) 
		{
			playerController.playerCrash ();
		}
	}

}
