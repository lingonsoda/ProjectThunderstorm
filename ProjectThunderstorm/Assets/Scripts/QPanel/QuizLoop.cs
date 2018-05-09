using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizLoop : MonoBehaviour {

    public int loopTimes;
    public Button plusBtn, minusBtn;
    QuizSlotCheck quizSlotCheck;

    void Start() {
        quizSlotCheck = this.GetComponent<QuizSlotCheck>();
        plusBtn.onClick.AddListener(plusClick);
        minusBtn.onClick.AddListener(minusClick);
    }

    public int getLoopTimes() {
        return loopTimes;
    }
    public void plusClick() {
        ++loopTimes;
        quizSlotCheck.SlotCheck();
    }
    public void minusClick() {
        --loopTimes;
        quizSlotCheck.SlotCheck();
    }
}
