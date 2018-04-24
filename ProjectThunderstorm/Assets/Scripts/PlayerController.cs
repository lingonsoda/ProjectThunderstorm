using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public int playSpeed;
	
	public Button playButton;
	public Button stopButton;
	public Transform startPosition;
	public GameObject winPanel;

	private BoxCollider2D bCollider;
	private int speed;

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
		speed = 0;
		winPanel.SetActive (false);
	}

	void Update () {
		transform.Translate (new Vector3 (1 ,0 ,0) * speed * Time.deltaTime);
	}

	void startPlay()
	{
		speed = playSpeed;
		bCollider.enabled = true;
		playButton.gameObject.SetActive (false);
		stopButton.gameObject.SetActive (true);
	}

	void stopPlay()
	{
		speed = 0;
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
		}else if(collision.gameObject.CompareTag("ArrowLeft")){
			resetRotation ();
			transform.Rotate (Vector3.forward * 180);
		}else if(collision.gameObject.CompareTag("ArrowUp")){
			resetRotation ();
			transform.Rotate (Vector3.forward * 90);
		}else if(collision.gameObject.CompareTag("ArrowDown")){
			resetRotation ();
			transform.Rotate (Vector3.forward * -90);
		}
		if (collision.gameObject.CompareTag ("Goal")) {
			winPanel.SetActive (true);
			playButton.gameObject.SetActive (false);
			stopButton.gameObject.SetActive (false);
			speed = 0;
			Debug.Log ("Goal");
		}
	}
	private void resetRotation()
	{
		Quaternion myRotation = transform.rotation;
		myRotation.z = 0;
		transform.rotation = myRotation;
	}
}