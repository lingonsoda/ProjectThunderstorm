using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoopPanel : MonoBehaviour {

	public int LoopCount;
	public Text countText;

	void Start(){
		LoopCount = 1;
	}


	void CountAdd() {
		LoopCount++;
		countText.text = LoopCount.ToString();
	}

	void CountSubtract(){
		LoopCount--;
		countText.text = LoopCount.ToString();
	}

	public void OnClickAdd(){
		CountAdd ();
	}

	public void OnClickSubtract(){
		CountSubtract ();
	}
}
