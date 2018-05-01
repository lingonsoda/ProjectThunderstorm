﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject menuPanel;
	public GameObject winPanel;
	public GameObject arrowPanel;
	public Button playButton;
	public Button stopButton;
	public Button resetButton;
	public Button menuButton;
	public PlayerController playerController;

	void Start () {
		menuPanel.SetActive (false);
		winPanel.SetActive (false);
		stopButton.gameObject.SetActive (false);
	}

	void Update () {

	}

	public void activateMenuPanel()
	{
		menuPanel.SetActive (true);
		deactivateGameButtons ();
		deactivateArrowPanel ();
		playerController.pausePlayer ();
	}

	public void deactivateMenuPanel()
	{
		menuPanel.SetActive (false);
		activateGameButtons ();
		if (!playerController.play) 
		{
			activateArrowPanel ();
		}
		playerController.startPlayer ();
	}

	public void activateWinPanel()
	{
		winPanel.SetActive (true);
		deactivateGameButtons ();
		deactivateArrowPanel ();
		playerController.pausePlayer ();
	}

	public void swapPlayAndStop()
	{
		if (playButton.gameObject.activeSelf) {
			stopButton.gameObject.SetActive (true);
			playButton.gameObject.SetActive (false);
		} else if (stopButton.gameObject.activeSelf) {
			playButton.gameObject.SetActive (true);
			stopButton.gameObject.SetActive (false);
		}
	}

	public void activateArrowPanel()
	{
		arrowPanel.SetActive (true);
	}

	public void deactivateArrowPanel()
	{
		arrowPanel.SetActive (false);
	}

	private void activateGameButtons()
	{
		resetButton.gameObject.SetActive (true);
		menuButton.gameObject.SetActive (true);
		if (playerController.play) {
			stopButton.gameObject.SetActive (true);
			playButton.gameObject.SetActive (false);
		} else {
			stopButton.gameObject.SetActive (false);
			playButton.gameObject.SetActive (true);
		}
	}

	private void deactivateGameButtons()
	{
		playButton.gameObject.SetActive (false);
		stopButton.gameObject.SetActive (false);
		resetButton.gameObject.SetActive (false);
		menuButton.gameObject.SetActive (false);
	}
}
