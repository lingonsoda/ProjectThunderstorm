using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnClick : MonoBehaviour {

	private AudioSource audio;

	void Start(){
		audio = GetComponent<AudioSource>();
		Debug.Log("laddar audio");


	}

	public void OnClick() {
		audio.Play();
		Debug.Log("Playing");

	}

}
