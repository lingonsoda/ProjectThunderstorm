using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnClick : MonoBehaviour {

	private AudioSource audio;

	void Start () {
		audio = GetComponent<AudioSource>();
	}
	

	public void OnClick(){

		audio.Play();

	}
}
