using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetArrows : MonoBehaviour {

    public Button resetButton;
    Transform grandParent;

    void Start() {
        Button rBtn = resetButton.GetComponent<Button>();
        rBtn.onClick.AddListener(OnClick);
        grandParent = this.transform;
    }

    void OnClick() {
<<<<<<< HEAD
        for(int i = 0; i < grandParent.childCount; i++) {
            Transform parent = grandParent.transform.GetChild(i);
            if(parent.transform.childCount > 0) {
=======
        for (int i = 0; i < grandParent.childCount; i++) {
            Transform parent = grandParent.transform.GetChild(i);
            if (parent.transform.childCount > 0 && parent.transform.GetChild(0).gameObject.name.Contains("Arrow")) {
>>>>>>> master
                Destroy(parent.transform.GetChild(0).gameObject);
                Debug.Log("Objekt borttaget vid" + "[child " + (i) + "]");
            }
<<<<<<< HEAD
            Debug.Log((i+1) + " child");
        }
        
=======
        }
        ArrowColorTrackScript.RemoveAllColor();
        ArrowColorTrackScript.StartPositionColorTrack();
>>>>>>> master
    }
}
