using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizLoop : MonoBehaviour {

    public int loopTimes;
    public Button plusBtn, minusBtn;
    public Text loopTimesText;
    QuizSlotCheck quizSlotCheck;

    void Update() {
    }

    void Start() {
        quizSlotCheck = this.GetComponent<QuizSlotCheck>();
        plusBtn.onClick.AddListener(plusClick);
        minusBtn.onClick.AddListener(minusClick);
        loopTimesText.text = "|";
    }

    public int getLoopTimes() {
        return loopTimes;
    }
    public void loopDash(int i) {
        loopTimesText.text = "|";
        for (int i2 = i; i2 > 0; i2--) {
            loopTimesText.text += "|";
        }
    }
    public void plusClick() {
        if(loopTimes < 4) {
            ++loopTimes;
            loopDash(loopTimes);
            quizSlotCheck.SlotCheck();
        } else {

        }

    }
    public void minusClick() {
        if (loopTimes == 0) {

        } else {
            --loopTimes;
            loopDash(loopTimes);
            quizSlotCheck.SlotCheck();
        }

    }
}
