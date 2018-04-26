using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

	public int playSpeed;
	
	public Button playButton;
	public Button stopButton;
	public Button resetButton;
	public Button menuButton;
	public Transform startPosition;
	public GameObject winPanel;

	private BoxCollider2D arrowCollider;
	private int speed;
	private bool arrowCollision;
	private bool obstacleCollision;

	void Start ()
	{
		Button pBtn = playButton.GetComponent<Button> ();
		pBtn.onClick.AddListener (startPlay);	
		Button sBtn = stopButton.GetComponent<Button> ();
		sBtn.onClick.AddListener (stopPlay);
<<<<<<< HEAD
		stopButton.gameObject.SetActive (false);
		arrowCollider = GetComponent<BoxCollider2D> ();
		arrowCollider.enabled = false;
		speed = 0;
		winPanel.SetActive (false);
		StartCoroutine(setStartPosition ());
=======
        audio = GetComponent<AudioSource>();
        stopButton.gameObject.SetActive (false);
		bCollider = GetComponent<BoxCollider2D> ();
		bCollider.enabled = false;
		speed = 0;
		winPanel.SetActive (false);
		StartCoroutine (setStartPosition ());
>>>>>>> Patrik
	}

	void Update ()
	{
		transform.Translate (new Vector3 (1, 0, 0) * speed * Time.deltaTime);
	}

	void startPlay ()
	{
		speed = playSpeed;
		arrowCollider.enabled = true;
		playButton.gameObject.SetActive (false);
		resetButton.gameObject.SetActive (false);
		menuButton.gameObject.SetActive (false);
		stopButton.gameObject.SetActive (true);
	}

	void stopPlay ()
	{
		speed = 0;
		arrowCollider.enabled = false;
		transform.position = startPosition.position;
		resetRotation ();
		stopButton.gameObject.SetActive (false);
		playButton.gameObject.SetActive (true);
		resetButton.gameObject.SetActive (true);
		menuButton.gameObject.SetActive (true);
	}



	private void OnTriggerEnter2D (Collider2D collision)
	{
		Vector3 myScale = transform.localScale;

		if (collision.gameObject.CompareTag ("ArrowRight")) {
			resetRotation ();
			transform.Rotate (Vector3.forward * 0);	
		}
		if (collision.gameObject.CompareTag ("ArrowLeft")) {
			resetRotation ();
			transform.Rotate (Vector3.forward * 180);	
		}
		if (collision.gameObject.CompareTag ("ArrowUp")) {
			resetRotation ();
			transform.Rotate (Vector3.forward * 90);	
		}
		if (collision.gameObject.CompareTag ("ArrowDown")) {
			resetRotation ();
			transform.Rotate (Vector3.forward * -90);	
		}
		if (collision.gameObject.CompareTag ("Goal")) {
			winPanel.SetActive (true);
			playButton.gameObject.SetActive (false);
			stopButton.gameObject.SetActive (false);
			resetButton.gameObject.SetActive (false);
			menuButton.gameObject.SetActive (false);
			speed = 0;
			Debug.Log ("Goal");
		}
	}

	private void resetRotation ()
	{
		Quaternion myRotation = transform.rotation;
		myRotation.z = 0;
		transform.rotation = myRotation;
	}

<<<<<<< HEAD
	public void playerCrash ()
	{
		speed = 0;
	}

	IEnumerator setStartPosition ()
	{
		yield return new WaitForEndOfFrame();
		transform.position = startPosition.position;
	}

=======
	IEnumerator setStartPosition(){
		yield return new WaitForEndOfFrame ();
		transform.position = startPosition.position;
	}
>>>>>>> Patrik
}