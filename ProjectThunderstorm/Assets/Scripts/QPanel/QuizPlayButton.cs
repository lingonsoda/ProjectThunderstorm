using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizPlayButton : MonoBehaviour {
    public GameObject slot1, slot2, slot3, slot4;
	public bool correctAnswer;

    bool slotOne, slotTwo, slotThree, slotFour;
    bool slotOneLoop, slotTwoLoop, slotThreeLoop, slotFourLoop;


    void Start() {

		correctAnswer = false;
    }

    public void AnswerCheck() {
        slotOne = slot1.GetComponent<QuizSlotCheck>().getIsCorrectAnswer();
        slotTwo = slot2.GetComponent<QuizSlotCheck>().getIsCorrectAnswer();
        slotThree = slot3.GetComponent<QuizSlotCheck>().getIsCorrectAnswer();
        slotFour = slot4.GetComponent<QuizSlotCheck>().getIsCorrectAnswer();
        slotOneLoop = slot1.GetComponent<QuizSlotCheck>().LoopIsCorrect();
        slotTwoLoop = slot2.GetComponent<QuizSlotCheck>().LoopIsCorrect();
        slotThreeLoop = slot3.GetComponent<QuizSlotCheck>().LoopIsCorrect();
        slotFourLoop = slot4.GetComponent<QuizSlotCheck>().LoopIsCorrect();
        if (slotOne && slotTwo && slotThree && slotFour &&
            slotOneLoop && slotTwoLoop && slotThreeLoop && slotFourLoop) {
            Debug.Log("Rätt");
			correctAnswer = true;
        } else {
			Debug.Log("Fel");
			correctAnswer = false;
		}
    }

}
