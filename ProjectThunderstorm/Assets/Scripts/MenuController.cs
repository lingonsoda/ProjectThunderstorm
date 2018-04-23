using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public void StartModeSelection()
    {
        SceneManager.LoadScene("ModeSelection");
    }
    public void FromSelectionModeBack()
    {
        SceneManager.LoadScene("Menu");
    }
    public void StartStory()
    {
        SceneManager.LoadScene("Main");
    }
    public void ChooseChallengeLevel()
    {
        SceneManager.LoadScene("ChallengeModeMenu");
    }
    
}
