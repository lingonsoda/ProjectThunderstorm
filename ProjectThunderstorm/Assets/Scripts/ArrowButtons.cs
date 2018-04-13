using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class ArrowButtons : MonoBehaviour 
,IPointerEnterHandler
{

	public GameObject arrow;

	public void OnPointerEnter(PointerEventData eventData)
	{
		Instantiate (arrow);
		Vector3 pos = Input.mousePosition;
		pos.z = transform.position.z - Camera.main.transform.position.z;
		arrow.transform.position = Camera.main.ScreenToWorldPoint (pos);
	}
}
