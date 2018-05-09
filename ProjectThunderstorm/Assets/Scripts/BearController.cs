using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BearController : MonoBehaviour
{

	public PlayerController playerController;
	public ToggleBoxCollider toggleBoxCollider;
	public QuizPlayButton quizPlayButton;
	public GameObject quizPanel;
	public Button quizXButton;

	private AudioSource bearAudio;
	private Animator bearAnimation;
	private bool bearCompleted;
	private bool playerAtBear;

	void Start ()
	{
		quizXButton.onClick.AddListener (bearAnswerCheck);
		bearAudio = GetComponent<AudioSource> ();
		bearAnimation = GetComponent<Animator> ();
		bearAnimation.enabled = false;
		bearCompleted = false;
		playerAtBear = false;
	}

	void Update ()
	{
		if (toggleBoxCollider.playerCollision) {
			toggleBoxCollider.playerCollision = false;
			playerAtBear = true;
			bearCollided ();
		}
	}

	private void bearCollided()
	{
		if (bearCompleted) {
			return;
		} else {
			playerController.playerCrashed = true;
			playerController.pausePlayer ();
			bearAnswerCheck ();
		}
	}

	public void bearAnswerCheck()
	{
		if (playerAtBear) {
			quizPlayButton.AnswerCheck ();
			if (quizPlayButton.correctAnswer) {
				bearAudio.Play ();
				StartCoroutine (waitForBearToSleep ());
			} else {
				//play bear growl
				StartCoroutine (waitForBearGrowl ());
			}
		}
	}

	IEnumerator waitForBearToSleep ()
	{
		yield return new WaitForSeconds (10);
		bearAnimation.enabled = true;
		StartCoroutine (bearSleeping ());
	}

	IEnumerator bearSleeping ()
	{
		yield return new WaitForSeconds (2);
		playerController.playerCrashed = false;
		playerController.startPlayer ();
		bearCompleted = true;
		playerAtBear = false;
	}

	IEnumerator waitForBearGrowl ()
	{
		yield return new WaitForSeconds (2);
		quizPanel.SetActive (true);
	}
}
