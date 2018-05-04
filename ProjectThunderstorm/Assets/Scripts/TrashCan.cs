using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour {


    void Update() {
        if(this.transform.childCount > 0) {
            Destroy(this.transform.GetChild(0).gameObject);
            Debug.Log("Slängde en pil");
        }
    }
}
