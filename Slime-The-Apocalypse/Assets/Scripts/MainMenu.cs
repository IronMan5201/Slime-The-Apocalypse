using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //When play button is clicked on main menu, it loads scene of first level
        SceneManager.LoadScene(/* Load Scene of first level*/"");
    }

    public void LevelSelect()
    {
        //when a button calls this on click, go to level select scene
        SceneManager.LoadScene(/* Load Scene of level select*/"");
    }

    public void Quit()
    {
        //When quit button is clicked, quit the game
        Application.Quit();
    }
}
