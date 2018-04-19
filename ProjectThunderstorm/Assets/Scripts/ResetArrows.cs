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
        for(int i = 0; i < grandParent.childCount; i++) {
            Transform parent = grandParent.transform.GetChild(i);
            if(parent.transform.GetChild(0) != null) {
                Destroy(parent.transform.GetChild(0));
            }
            Debug.Log((i+1) + " child");
        }
        
    }
}
