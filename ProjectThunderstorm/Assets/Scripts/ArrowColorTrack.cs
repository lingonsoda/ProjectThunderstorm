using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowColorTrack : MonoBehaviour {

    Transform grandParent;
    Color blue;
    Color white;

	void Start() {
        grandParent = this.transform;
        blue = new Color32(0, 50, 255, 100);
        white = new Color32(255, 255, 255, 100);
    }

    public void RemoveAllColor() {
        for (int i = 0; i < grandParent.childCount; i++) {
            Transform parent = grandParent.transform.GetChild(i);
                parent.GetComponent<Image>().color = white;
        }
    }

    public void ColorTrack() {
        Transform gt = grandParent.transform;
        string str = "Exception";

        for (int i = 0; i < grandParent.childCount; i++) {
            Transform parent = gt.GetChild(i);
            if (parent.transform.childCount == 0) {
                parent.GetComponent<Image>().color = white;
            }
        }
        for (int i = 0; i < grandParent.childCount; i++) {
            Transform parent = gt.GetChild(i);
            if (parent.transform.childCount > 0) {
                if (parent.transform.GetChild(0).gameObject.name.Contains("ArrowRight")) {
                    int temp = i;
                    Debug.Log("HögerPil hittad! Färgar till höger");
                    for (int ar = 0; ar < 15; ar++) {
                        try {
                            gt.GetChild(temp + ar).GetComponent<Image>().color = blue;
                            if (gt.GetChild(temp + ar + 1).childCount > 0 || (temp + ar + 1) % 15 == 0) {
                                gt.GetChild(temp + ar).GetComponent<Image>().color = blue;
                                break;
                            }
                        }catch (System.Exception) {
                            Debug.Log(str);
                            break;
                        }
                    }
                }
                if (parent.transform.GetChild(0).gameObject.name.Contains("ArrowDown")) {
                    int temp = i;
                    Debug.Log("NerPil hittad! Färgar neråt");
                    for (int ad = 0; ad < 105; ad+=15) {
                        try {
                            gt.GetChild(temp + ad).GetComponent<Image>().color = blue;
                            if(gt.GetChild(temp + ad + 15).childCount > 0) {
                                gt.GetChild(temp + ad + 15).GetComponent<Image>().color = blue;
                                break;
                            }
                        } catch (System.Exception) {
                            Debug.Log(str);
                            break;  
                        }
                    }
                }
                if (parent.transform.GetChild(0).gameObject.name.Contains("ArrowLeft")) {
                    int temp = i;
                    Debug.Log("VänsterPil hittad! Färgar till vänster");
                    for (int al = 15; al > 0; al--) {
                        try {
                            gt.GetChild(temp + (al-15)).GetComponent<Image>().color = blue;
                            if (gt.GetChild(temp + (al-15) - 1).childCount > 0 || (temp + (al-15)) % 15 == 0) {
                                gt.GetChild(temp + (al-15)).GetComponent<Image>().color = blue;
                                break;
                            }
                        } catch (System.Exception) {
                            Debug.Log(str);
                            break;
                        }
                    }
                }
                if (parent.transform.GetChild(0).gameObject.name.Contains("ArrowUp")) {
                    int temp = i;
                    Debug.Log("UppPil hittad! Färgar upp");
                    for (int au = 105; au > 0; au-=15) {
                        try {
                            gt.GetChild(temp + (au-105)).GetComponent<Image>().color = blue;
                            if(gt.GetChild(temp + (au - 105) - 15).childCount > 0) {
                                gt.GetChild(temp + (au - 105) - 15).GetComponent<Image>().color = blue;
                                break;
                            }
                        } catch (System.Exception) {
                            Debug.Log(str);
                            break;
                        }
                    }
                }
            }
        }
    }
}
