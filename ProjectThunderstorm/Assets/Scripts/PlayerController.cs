using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	
	public Button playButton;

	private BoxCollider2D bCollider;
	private float speed;
	private float horizontalDirection;

	void Start () {
		Button pBtn = playButton.GetComponent<Button>();
		bCollider = GetComponent<BoxCollider2D> ();
		bCollider.enabled = false;
		pBtn.onClick.AddListener (startMove);	
		speed = 0.0f;
		horizontalDirection = 1.0f;
	}

	void Update () {
		transform.Translate (new Vector3 (horizontalDirection,0 , 0) * speed * Time.deltaTime);
	}

	void startMove()
	{
		speed = 30.0f;
		bCollider.enabled = true;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Vector3 myScale = transform.localScale;
		if(collision.gameObject.CompareTag("ArrowRight"))
		{
			resetRotation ();
			transform.Rotate (Vector3.forward * 0);
			Debug.Log ("hit right trigger");
		}else if(collision.gameObject.CompareTag("ArrowLeft")){
			resetRotation ();
			transform.Rotate (Vector3.forward * 180);
			Debug.Log ("hit left trigger");
		}else if(collision.gameObject.CompareTag("ArrowUp")){
			resetRotation ();
			transform.Rotate (Vector3.forward * 90);
			Debug.Log ("hit up trigger");
		}else if(collision.gameObject.CompareTag("ArrowDown")){
			resetRotation ();
			transform.Rotate (Vector3.forward * -90);
			Debug.Log ("hit down trigger");
		}
	}
	private void resetRotation()
	{
		Quaternion myRotation = transform.rotation;
		myRotation.z = 0;
		transform.rotation = myRotation;
	}
}