﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizPlayButton : MonoBehaviour {
    public Button quizPlayBtn;
    public GameObject slot1, slot2, slot3, slot4, slot5;

    bool slotOne, slotTwo, slotThree, slotFour, slotFive;


    void Start() {
        Button qPBtn = quizPlayBtn.GetComponent<Button>();
        qPBtn.onClick.AddListener(OnClick);

    }

    void OnClick() {
        slotOne = slot1.GetComponent<QuizSlotCheck>().getIsCorrectAnswer();
        slotTwo = slot2.GetComponent<QuizSlotCheck>().getIsCorrectAnswer();
        slotThree = slot3.GetComponent<QuizSlotCheck>().getIsCorrectAnswer();
        slotFour = slot4.GetComponent<QuizSlotCheck>().getIsCorrectAnswer();
        slotFive = slot5.GetComponent<QuizSlotCheck>().getIsCorrectAnswer();
        if (slotOne && slotTwo && slotThree && slotFour && slotFive) {
            Debug.Log("Rätt");
        } else { Debug.Log("Fel"); }
    }

}