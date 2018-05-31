using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public int playSpeed;
	public bool play;
	public bool playerCrashed;

	public Button playButton;
	public Button stopButton;
	public Transform startPosition;
	public GameObject winPanel;
	public GameController gameController;
<<<<<<< HEAD
	public AudioClip crash;
//	public Sprite crashSprite;
//	public SpriteRenderer spriteRenderer;
=======
	public ArrowColorTrack arrowColorTrack;
	public ParticleSystem carSmoke;
	public AudioClip crash;
>>>>>>> master

	private IEnumerator fadeAudio;
	private AudioSource crashAudio;
	private AudioSource audio;
	private AudioSource crashAudio;
	private BoxCollider2D bCollider;
	private int speed;
	private Animator anim;



	void Start () {
		audio = GetComponent<AudioSource>();
		crashAudio = GetComponent<AudioSource> ();
<<<<<<< HEAD
=======

		anim = GetComponent<Animator>();

>>>>>>> master
		bCollider = GetComponent<BoxCollider2D> ();
		bCollider.enabled = false;
		speed = 0;
		resetStartRotation ();
		StartCoroutine (setStartPosition ());
		play = false;
		playerCrashed = false;
		carSmoke.Stop ();

		anim.SetBool ("Player_crash", false);
		anim.SetBool ("Player_driving", false);
		anim.SetBool ("Player_Idle", true);
	}

	void Update () {
		transform.Translate (new Vector3 (1 ,0 ,0) * speed * Time.deltaTime);
		fadeAudio = AudioFade.FadeOut(audio, 0.2f);
	}


	public void startPlay()
	{
		audio.Play ();
		speed = playSpeed;
		bCollider.enabled = true;
		gameController.swapPlayAndStop ();
		carSmoke.Play ();
		play = true;
		anim.SetBool ("Player_crash", false);
		anim.SetBool ("Player_driving", true);
		anim.SetBool ("Player_Idle", false);
	}

	public void stopPlay()
	{
		StartCoroutine (fadeAudio);
		speed = 0;
		bCollider.enabled = false;
		resetStartRotation ();
		transform.position = startPosition.position;
		carSmoke.Stop ();
		carSmoke.Clear ();
		if (play) {
			gameController.swapPlayAndStop ();
		}
		play = false;
		playerCrashed = false;
		anim.SetBool ("Player_crash", false);
		anim.SetBool ("Player_driving", false);
		anim.SetBool ("Player_Idle", true);
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
			carSmoke.Stop ();
			carSmoke.Clear ();
			Debug.Log ("Goal");
		}
		if (collision.gameObject.CompareTag ("Obstacle")) {
<<<<<<< HEAD
//			StartCoroutine(fadeAudio);
//			spriteRenderer.sprite = crashSprite;
			audio.Stop();
			crashAudio.PlayOneShot (crash);
=======
			audio.Stop ();
			crashAudio.PlayOneShot (crash, 0.5f);
			anim.SetBool ("Player_crash", true);
			anim.SetBool ("Player_driving", false);
			anim.SetBool ("Player_Idle", false);
>>>>>>> master
			speed = 0;
			carSmoke.Stop ();
			playerCrashed = true;
		}
	}

	private void resetRotation()
	{
		Quaternion myRotation = transform.rotation;
		myRotation.z = 0;
		transform.rotation = myRotation;
	}

	private void resetStartRotation()
	{
		if (arrowColorTrack.startRight) {
			resetRotation ();
			transform.Rotate (Vector3.forward * 0);
		} else if (arrowColorTrack.startUp) {
			resetRotation ();
			transform.Rotate (Vector3.forward * 90);
		} else if (arrowColorTrack.startLeft) {
			resetRotation ();
			transform.Rotate (Vector3.forward * 180);
		} else if (arrowColorTrack.startDown) {
			resetRotation ();
			transform.Rotate (Vector3.forward * -90);
		} else {
			resetRotation ();
			transform.Rotate (Vector3.forward * 0);
		}
	}

	IEnumerator setStartPosition(){
		yield return new WaitForEndOfFrame ();
		transform.position = startPosition.position;
	}

	public void pausePlayer()
	{
		speed = 0;
		carSmoke.Stop ();
		carSmoke.Clear ();
        try {
            StartCoroutine(fadeAudio);
        } catch (System.Exception) {

        }
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