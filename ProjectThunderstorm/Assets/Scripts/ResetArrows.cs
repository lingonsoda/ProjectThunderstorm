using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetArrows : MonoBehaviour {
    public Button resetButton;
    Transform grandParent;
    ArrowColorTrack ArrowColorTrackScript;

    void Start() {
        Button rBtn = resetButton.GetComponent<Button>();
        rBtn.onClick.AddListener(OnClick);
        grandParent = this.transform;
        ArrowColorTrackScript = GameObject.Find("TilePanel").GetComponent<ArrowColorTrack>();
    }

    void OnClick() {

        for (int i = 0; i < grandParent.childCount; i++) {
            Transform parent = grandParent.transform.GetChild(i);
            if(parent.transform.childCount > 0 && parent.transform.GetChild(0).gameObject.name.Contains("Arrow")) {
                Destroy(parent.transform.GetChild(0).gameObject);
                Debug.Log("Objekt borttaget vid" + "[child " + (i) + "]");
            }
        }
        ArrowColorTrackScript.RemoveAllColor();
    }
}
