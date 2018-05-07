using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizRemoveArrowButton : MonoBehaviour {
    public Button removeButton;
    Button rBtn;
    Transform parent;

    void Start() {
        rBtn = removeButton.GetComponent<Button>();
        rBtn.onClick.AddListener(OnClick);
        parent = this.transform;
    }

    void Update() {
        if (parent.childCount > 0) {
            rBtn.interactable = true;
        } else { rBtn.interactable = false; }
    }

    void OnClick() {
            if (parent.childCount > 0) {
            try {
                Destroy(parent.GetChild(0).gameObject);
                Debug.Log("Objekt borttaget");
            } catch (System.Exception) { }
                
            }
    }
}
