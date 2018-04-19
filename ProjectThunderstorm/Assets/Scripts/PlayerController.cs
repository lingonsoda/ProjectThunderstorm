using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	
	public Button playButton;
	public Button stopButton;
	public Transform startPosition;

	private BoxCollider2D bCollider;
	private float speed;

	void Start () {
		Button pBtn = playButton.GetComponent<Button> ();
		pBtn.onClick.AddListener (startPlay);	
		Button sBtn = stopButton.GetComponent<Button> ();
		sBtn.onClick.AddListener (stopPlay);
		stopButton.gameObject.SetActive (false);
		startPosition.gameObject.SetActive (false);
		bCollider = GetComponent<BoxCollider2D> ();
		bCollider.enabled = false;
		transform.position = startPosition.position;
		speed = 0.0f;
	}

	void Update () {
		transform.Translate (new Vector3 (1 ,0 , 0) * speed * Time.deltaTime);
	}

	void startPlay()
	{
		speed = 40.0f;
		bCollider.enabled = true;
		playButton.gameObject.SetActive (false);
		stopButton.gameObject.SetActive (true);
	}

	void stopPlay()
	{
		speed = 0.0f;
		bCollider.enabled = false;
		transform.position = startPosition.position;
		resetRotation ();
		stopButton.gameObject.SetActive (false);
		playButton.gameObject.SetActive (true);
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