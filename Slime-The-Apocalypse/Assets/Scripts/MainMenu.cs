using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public LevelManager manager;
    public void PlayGame(string sceneName)
    {
        //When play button is clicked on main menu, it loads scene of first level
        SceneManager.LoadScene(sceneName);
    }

    public void LevelSelect(string sceneName)
    {
        //when a button calls this on click, go to level select scene
        SceneManager.LoadScene(sceneName);
    }

    public void GoToMenu(string sceneName)
    {
        //when a button calls this on click, go to Main menu
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        //When quit button is clicked, quit the game

        //clears all player prefs for testing, if needed
        //Needed if want to start over after quit
        //****
        PlayerPrefs.DeleteAll();
        manager.Level1Passed = 0;
        manager.Level2Passed = 0;
        manager.Level3Passed = 0;
        manager.Level4Passed = 0;
        manager.Level5Passed = 0;
        manager.Level6Passed = 0;
        manager.Level7Passed = 0;
        manager.Level8Passed = 0;

        manager.Level1Time = 2000.0f;
        manager.Level2Time = 2000.0f;
        manager.Level3Time = 2000.0f;
        manager.Level4Time = 2000.0f;
        manager.Level5Time = 2000.0f;
        manager.Level6Time = 2000.0f;
        manager.Level7Time = 2000.0f;
        manager.Level8Time = 2000.0f;
        //****
        Application.Quit();
        Debug.Log("GOOD BYE!");
    }
}
