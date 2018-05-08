using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuizSlotCheck : MonoBehaviour, IDropHandler {
    public int correctAnswer;
    public int correctLoop;
    public bool isCorrectAnswer;

    private int itemNumber;
    AudioSource audio;
    QuizLoop quizLoop;

    void Start() {
        quizLoop = this.GetComponent<QuizLoop>();
    }

    void Update() {
        if (this.transform.childCount == 0) {
            isCorrectAnswer = false;
        }
    }

    public GameObject item {
        get {
            if (transform.childCount > 0) {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    #region IDropHandler implementation

    public void OnDrop(PointerEventData eventData) {
        if (QuizDragHandler.itemBeingDragged == null) {
            try {
                Destroy(DragHandler.itemBeingDragged.gameObject);
                return;

            } catch (System.Exception) {
                return;
            }
        }

        audio = QuizDragHandler.itemBeingDragged.GetComponent<AudioSource>();
        if (!item) {
            QuizDragHandler.itemBeingDragged.transform.SetParent(transform);
            audio.Play();
            itemNumber = QuizDragHandler.getNumber();
            SlotCheck();
        }
    }

    public void SlotCheck() {
            if (SlotIsCorrect(itemNumber) && LoopIsCorrect()) {
                isCorrectAnswer = true;
        } else {
                isCorrectAnswer = false;
        }
    }

    public bool SlotIsCorrect(int i) {
        if (i == correctAnswer) {
            return true;
        }
        return false;
    }
    public bool LoopIsCorrect() {
        if (quizLoop.getLoopTimes() == correctLoop) {
            return true;
        }
        return false;
    }

    public bool getIsCorrectAnswer() {
        return isCorrectAnswer;
    }

    #endregion
}

