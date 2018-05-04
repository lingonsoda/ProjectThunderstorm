using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearController : MonoBehaviour {

	public PlayerController playerController;
	public ToggleBoxCollider toggleBoxCollider;
	public QuizPlayButton quizPlayButton;

	private AudioSource bearAudio;
	private Animator bearAnimation;
	private bool bearCompleted;

	void Start () 
	{
		bearAudio = GetComponent<AudioSource> ();
		bearAnimation = GetComponent<Animator> ();
		bearAnimation.enabled = false;
		bearCompleted = false;
	}

	void Update()
	{
		if (toggleBoxCollider.playerCollision) 
		{
			bearCollided ();
		}
	}

	private void bearCollided()
	{
		if (bearCompleted) {
			return;
		} else {
			quizPlayButton.AnswerCheck ();
			playerController.playerCrashed = true;
			toggleBoxCollider.playerCollision = false;
			playerController.pausePlayer();
			if (quizPlayButton.correctAnswer) 
			{
				bearAudio.Play ();
				StartCoroutine(waitForBearToSleep());
			}else
			{
				//play bear growl
				//open quiz panel
				//do new answercheck
			}
		}
	}

	IEnumerator waitForBearToSleep(){
		yield return new WaitForSeconds (10);
		bearAnimation.enabled = true;
		StartCoroutine (bearSleeping ());
	}

	IEnumerator bearSleeping(){
		yield return new WaitForSeconds (2);
		playerController.playerCrashed = false;
		playerController.startPlayer();
		bearCompleted = true;
	}
}
