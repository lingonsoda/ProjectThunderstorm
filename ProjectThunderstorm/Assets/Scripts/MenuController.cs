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
		SceneManager.LoadScene("Level 1-1");
    }
    public void ChooseChallengeLevel()
    {
        SceneManager.LoadScene("ChallengeModeMenu");
    }

	public void Level1dash1()
	{
		SceneManager.LoadScene("Level 1-1");
	}

	public void RestartCurrentLevel()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex, LoadSceneMode.Single);
	}

	public void LoadNextScene()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1, LoadSceneMode.Single);
	}
    
}
