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

	private bool pointerOnButton;
	private Image img;

	void Awake()
	{
		img = GetComponent<Image> ();
	}

	void Update()
	{
		if(Input.GetMouseButtonDown(0) && pointerOnButton)
		{
			img.raycastTarget = false;
			Instantiate (arrow);
			Vector3 pos = Input.mousePosition;
			pos.z = transform.position.z - Camera.main.transform.position.z;
			arrow.transform.position = Camera.main.ScreenToWorldPoint (pos);
		}
		if (Input.GetMouseButtonUp (0)) 
		{
			img.raycastTarget = true;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log ("mouse on " + gameObject.name);
		pointerOnButton = true;

	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log ("mouse exit " + gameObject.name);
		pointerOnButton = false;
	}
}
