using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerListen : MonoBehaviour {

    public GameObject slot1, slot2, slot3, slot4;
    AudioSource audio1, audio2, audio3, audio4;
    public Button listenBtn;
    public int loopSlot1, loopSlot2, loopSlot3, loopSlot4;
    private float waitTime = 0.70f;
	
    void Start() {
        listenBtn.onClick.AddListener(OnClick);
    }

    void OnClick() {
        loopSlot1 = slot1.GetComponent<QuizLoop>().loopTimes;
        loopSlot2 = slot2.GetComponent<QuizLoop>().loopTimes;
        loopSlot3 = slot3.GetComponent<QuizLoop>().loopTimes;
        loopSlot4 = slot4.GetComponent<QuizLoop>().loopTimes;
        try {
            slot1.transform.GetChild(0).GetComponent<Image>().raycastTarget = false;
        } catch(System.Exception) { }
        try {
            slot2.transform.GetChild(0).GetComponent<Image>().raycastTarget = false;
        } catch (System.Exception) { }
        try {
            slot3.transform.GetChild(0).GetComponent<Image>().raycastTarget = false;
        } catch (System.Exception) { }
        try {
            slot4.transform.GetChild(0).GetComponent<Image>().raycastTarget = false;
        } catch (System.Exception) { }
        slot1.GetComponent<Image>().raycastTarget = false;
        slot2.GetComponent<Image>().raycastTarget = false;
        slot3.GetComponent<Image>().raycastTarget = false;
        slot4.GetComponent<Image>().raycastTarget = false;
        StartCoroutine(FirstSlot());
        listenBtn.interactable = false;
    }

    IEnumerator FirstSlot() {
        yield return new WaitForSeconds(waitTime);
        try {
            if(slot1.transform.childCount > 0) {
                audio1 = slot1.transform.GetChild(0).GetComponent<AudioSource>();
                audio1.Play();
            }
            if (loopSlot1 > 0) {
                loopSlot1--;
                StartCoroutine(FirstSlot());
            } else { StartCoroutine(SecondSlot()); }

        } catch (System.Exception) {
            
        }
    }
    IEnumerator SecondSlot() {
        yield return new WaitForSeconds(waitTime);
        try {
            if (slot2.transform.childCount > 0) {
                audio2 = slot2.transform.GetChild(0).GetComponent<AudioSource>();
                audio2.Play();
            }
            if (loopSlot2 > 0) {
                loopSlot2--;
                StartCoroutine(SecondSlot());
            } else { StartCoroutine(ThirdSlot()); }

        } catch (System.Exception) {

        }
    }
    IEnumerator ThirdSlot() {
        yield return new WaitForSeconds(waitTime);
        try {
            if (slot3.transform.childCount > 0) {
                audio3 = slot3.transform.GetChild(0).GetComponent<AudioSource>();
                audio3.Play();
            }
            if (loopSlot3 > 0) {
                loopSlot3--;
                StartCoroutine(ThirdSlot());
            } else { StartCoroutine(FourthSlot()); }
        } catch (System.Exception) {

        }
    }
    IEnumerator FourthSlot() {
        yield return new WaitForSeconds(waitTime);
        try {
            if (slot4.transform.childCount > 0) {
                audio4 = slot4.transform.GetChild(0).GetComponent<AudioSource>();
                audio4.Play();
            }
            if (loopSlot4 > 0) {
                loopSlot4--;
                StartCoroutine(FourthSlot());
            } else { StartCoroutine(End()); }
        } catch (System.Exception) {

        }
    }
    IEnumerator End() {
        yield return new WaitForSeconds(0.1f);
        listenBtn.interactable = true;
        try {
            slot1.transform.GetChild(0).GetComponent<Image>().raycastTarget = true;
        } catch (System.Exception) { }
        try {
            slot2.transform.GetChild(0).GetComponent<Image>().raycastTarget = true;
        } catch (System.Exception) { }
        try {
            slot3.transform.GetChild(0).GetComponent<Image>().raycastTarget = true;
        } catch (System.Exception) { }
        try {
            slot4.transform.GetChild(0).GetComponent<Image>().raycastTarget = true;
        } catch (System.Exception) { }
        slot1.GetComponent<Image>().raycastTarget = true;
        slot2.GetComponent<Image>().raycastTarget = true;
        slot3.GetComponent<Image>().raycastTarget = true;
        slot4.GetComponent<Image>().raycastTarget = true;
    }
}
