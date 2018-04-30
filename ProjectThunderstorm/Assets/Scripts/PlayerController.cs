using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public int playSpeed;
	public bool play;
	
	public Button playButton;
	public Button stopButton;
	public Transform startPosition;
	public GameObject winPanel;
	public GameController gameController;

    private IEnumerator fadeAudio;
    private AudioSource audio;
	private BoxCollider2D bCollider;
	private int speed;
	private bool playerCrashed;

	void Start () {
        audio = GetComponent<AudioSource>();
		bCollider = GetComponent<BoxCollider2D> ();
		bCollider.enabled = false;
		speed = 0;
		StartCoroutine (setStartPosition ());
		transform.position = startPosition.position;
		play = false;
		playerCrashed = false;
	}

	void Update () {
		transform.Translate (new Vector3 (1 ,0 ,0) * speed * Time.deltaTime);
        fadeAudio = AudioFade.FadeOut(audio, 0.2f);
    }

	public void startPlay()
	{
        audio.Play();
        speed = playSpeed;
		bCollider.enabled = true;
		gameController.swapPlayAndStop ();
		play = true;
	}

	public void stopPlay()
	{
        StartCoroutine(fadeAudio);
        speed = 0;
		bCollider.enabled = false;
		transform.position = startPosition.position;
		resetRotation ();
		if (play) {
			gameController.swapPlayAndStop ();
		}
		play = false;
		playerCrashed = false;
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
            StartCoroutine(fadeAudio);
			gameController.activateWinPanel ();
			speed = 0;
			Debug.Log ("Goal");
		}
		if (collision.gameObject.CompareTag ("Obstacle")) {
            StartCoroutine(fadeAudio);
            speed = 0;
			playerCrashed = true;
		}
	}
	private void resetRotation()
	{
		Quaternion myRotation = transform.rotation;
		myRotation.z = 0;
		transform.rotation = myRotation;
	}

	IEnumerator setStartPosition(){
		yield return new WaitForEndOfFrame ();
		transform.position = startPosition.position;
	}

	public void pausePlayer()
	{
		speed = 0;
		StartCoroutine(fadeAudio);
	}

	public void startPlayer()
	{
		if (playerCrashed) {
			speed = 0;
		} else if(play) {
			speed = playSpeed;
			audio.Play();
		}
	}
}