using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class ArrowButtons : MonoBehaviour 
,IPointerEnterHandler
,IPointerExitHandler
{

	public GameObject arrow;

	private bool buttonMarked;
	private float x, y;

	void Awake()
	{
		buttonMarked = false;
	}

	void Update()
	{
		Vector3 pos = Input.mousePosition;
		pos.z = transform.position.z - Camera.main.transform.position.z;
		if (buttonMarked && Input.GetMouseButtonDown(0)) 
		{
			Instantiate (arrow);
			arrow.transform.position = Camera.main.ScreenToWorldPoint (pos);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		buttonMarked = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		buttonMarked = false;
	}
}
