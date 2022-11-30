using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
        //PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
