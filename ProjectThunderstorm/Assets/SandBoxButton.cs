using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SandBoxButton : MonoBehaviour {

	public GameObject arrowPanel;
	public GameObject startgoalPanel;
	public GameObject obstaclePanel;
	public GameObject player;
	public GameObject startPlace;
	public Button sandboxButton;
	public Text sandboxText;

	private bool sandboxActive = true;


	// Use this for initialization
	void Start () {
		arrowPanel.SetActive (false);
		player.SetActive (false);
		startgoalPanel.SetActive (true);
		obstaclePanel.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SandboxMode(){
		if (sandboxActive) {
			sandboxButton.GetComponentInChildren<Text> ().text = "Sandbox Mode";
			arrowPanel.SetActive (true);
			player.SetActive (true);
			startgoalPanel.SetActive (false);
			obstaclePanel.SetActive (false);
			sandboxActive = false;
		}
		else if (!sandboxActive) {
			sandboxButton.GetComponentInChildren<Text> ().text = "Play Mode";
			player.transform.position = startPlace.transform.position;
			arrowPanel.SetActive (false);
			player.SetActive (false);
			startgoalPanel.SetActive (true);
			obstaclePanel.SetActive (true);
			sandboxActive = true;
		}
	}

}
