using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DropDownMenuOptions : MonoBehaviour {

	public Sprite forestMap;
	public Sprite cityMap;
//	public Sprite foresTile;
//	public Sprite cityTile;
	public Dropdown dropdownBox;
	public GameObject backgroundImage;
	public Transform grandParent;
	Transform gt;

	// Use this for initialization
	void Start () {
		gt = grandParent.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OptionChange(){

		int dv = dropdownBox.value;

		if (dv == 0) {
			backgroundImage.GetComponent<Image> ().sprite = forestMap;
		}

		if (dv == 1) {
			backgroundImage.GetComponent<Image>().sprite = cityMap;
		}
		
		Debug.Log(dv);

	}
}
