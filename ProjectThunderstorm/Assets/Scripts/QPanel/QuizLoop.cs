using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizLoop : MonoBehaviour {

    public int loopTimes;
    public Button plusBtn, minusBtn;
    public Text plusText, minusText;
    QuizSlotCheck quizSlotCheck;

    void Update() {
    }

    void Start() {
        quizSlotCheck = this.GetComponent<QuizSlotCheck>();
        plusBtn.onClick.AddListener(plusClick);
        minusBtn.onClick.AddListener(minusClick);
        plusText.text = (loopTimes+1) + ">";
        minusText.text = "<" + (loopTimes + 1);
    }

    public int getLoopTimes() {
        return loopTimes;
    }
    public void plusClick() {
        ++loopTimes;
        plusText.text = (loopTimes + 1) + ">";
        minusText.text = "<" + (loopTimes + 1);
        quizSlotCheck.SlotCheck();
    }
    public void minusClick() {
        --loopTimes;
        if (loopTimes < 0) {
            loopTimes = 0;
        }
        plusText.text = (loopTimes + 1) + ">";
        minusText.text = "<" + (loopTimes + 1);
        quizSlotCheck.SlotCheck();
    }
}
