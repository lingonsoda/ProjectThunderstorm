using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowColorTrack : MonoBehaviour {
    public bool startLeft;
    public bool startRight;
    public bool startDown;
    public bool startUp;

    Transform grandParent;
    Transform gt;
    Color blue;
    Color white;

	void Start() {
        grandParent = this.transform;
        gt = grandParent.transform;
        blue = new Color32(0, 50, 240, 100);
        white = new Color32(255, 255, 255, 45);
        StartPositionColorTrack();
    }

    public void RemoveAllColor() {
        for (int i = 0; i < grandParent.childCount; i++) {
            Transform parent = gt.GetChild(i);
            if (parent.name.Contains("Panel")) {
                parent.GetComponent<Image>().color = white;
            }
            
        }
    }

    public void StartPositionColorTrack() {
        string str = "Exception";
        for (int i = 0; i < grandParent.childCount; i++) {
            Transform parent = gt.GetChild(i);
            if (parent.transform.childCount > 0) {
                if (parent.transform.GetChild(0).gameObject.name.Contains("StartPosition")) {
                    int temp = i;
                    Debug.Log("Start Hittad! Färgar till höger");
                    for (int rs = 0; rs < 15; rs++) {
                        try {
                            gt.GetChild(temp + rs).GetComponent<Image>().color = blue;
                            if (gt.GetChild(temp + rs + 1).childCount > 0 || (temp + rs + 1) % 15 == 0) {
                                gt.GetChild(temp + rs).GetComponent<Image>().color = blue;
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

    public void ColorTrack() {
        string str = "Exception";
        for (int i = 0; i < grandParent.childCount; i++) {
            Transform parent = gt.GetChild(i);
            if (parent.transform.childCount == 0) {
                if (parent.name.Contains("Panel")) {
                    parent.GetComponent<Image>().color = white;
                }
            }
        }
        StartPositionColorTrack();
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
                        } catch (System.Exception) {
                            Debug.Log(str);
                            break;
                        }
                    }
                }
                if (parent.transform.GetChild(0).gameObject.name.Contains("ArrowDown")) {
                    int temp = i;
                    Debug.Log("NerPil hittad! Färgar neråt");
                    for (int ad = 0; ad < 105; ad += 15) {
                        try {
                            gt.GetChild(temp + ad).GetComponent<Image>().color = blue;
                            if (gt.GetChild(temp + ad + 15).childCount > 0) {
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
                            gt.GetChild(temp + (al - 15)).GetComponent<Image>().color = blue;
                            if (gt.GetChild(temp + (al - 15) - 1).childCount > 0 || (temp + (al - 15)) % 15 == 0) {
                                gt.GetChild(temp + (al - 15)).GetComponent<Image>().color = blue;
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
                    for (int au = 105; au > 0; au -= 15) {
                        try {
                            gt.GetChild(temp + (au - 105)).GetComponent<Image>().color = blue;
                            if (gt.GetChild(temp + (au - 105) - 15).childCount > 0) {
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
