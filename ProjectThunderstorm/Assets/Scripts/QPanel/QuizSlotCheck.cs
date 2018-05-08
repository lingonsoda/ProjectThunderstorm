﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuizSlotCheck : MonoBehaviour, IDropHandler {
    public int correctAnswer;
    public int correctLoop;
    public bool isCorrectAnswer;
    public bool isCorrectLoop;
    AudioSource audio;

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

        int number = QuizDragHandler.getNumber();
        int loopTimes = QuizDragHandler.getLoopTimes();
        audio = QuizDragHandler.itemBeingDragged.GetComponent<AudioSource>();
        if (!item) {
            QuizDragHandler.itemBeingDragged.transform.SetParent(transform);
            audio.Play();
            if (SlotIsCorrect(number)) {
                isCorrectAnswer = true;
            } else { isCorrectAnswer = false; }
            if (LoopIsCorrect(loopTimes)) {
                isCorrectLoop = true;
            } else { isCorrectLoop = false; }
        }
    }
    public bool SlotIsCorrect(int i) {
        if (i == correctAnswer) {
            return true;
        }
        return false;
    }

    public bool LoopIsCorrect(int i) {
        if (i == correctLoop) {
            return true;
        }
        return false;
    }

    public bool getIsCorrectAnswer() {
        return isCorrectAnswer;
    }

    #endregion
}

