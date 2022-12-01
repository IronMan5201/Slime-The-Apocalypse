using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject diedMenuUI;

    public GameObject backgroundMusic;

    public GameObject infoDisplay;
    public GameObject LevelNum;
    private TextMeshProUGUI LevelNumGUI;

    void Awake()
    {
        if(LevelNum == null)
        {
            LevelNum = GameObject.Find("LevelInfo");
            LevelNumGUI = LevelNum.GetComponent<TextMeshProUGUI>();
        }
        LevelNumGUI.text = ""+ SceneManager.GetActiveScene().name + ":\nPaused";
    }
    //Resume the game from the pause menu
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        infoDisplay.SetActive(true);
        Time.timeScale = 1f;  //set the scale at which time passes to 1, normal rate
        GameIsPaused = false;
        backgroundMusic.GetComponent<AudioSource>().volume = 0.2f;
    }

    //pause the game when the pause button is clicked
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        infoDisplay.SetActive(false);
        Time.timeScale = 0f;  //set the scale at which time passes to 0, frozen, paused
        GameIsPaused = true;
        backgroundMusic.GetComponent<AudioSource>().volume = 0.0f;
    }

    public void LoadMenu(string sceneName)
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(sceneName);  //loads scene from build settings at index 0, which is our main menu
    }

    public void PlayerDied()
    {
        diedMenuUI.SetActive(true);
        infoDisplay.SetActive(false);
        Time.timeScale = 0f;  //set the scale at which time passes to 0, frozen, paused
        GameIsPaused = true;
        backgroundMusic.GetComponent<AudioSource>().volume = 0.0f;
    }

    public bool IsPaused()
    {
        return GameIsPaused;
    }

    public void SetPause(bool value)
    {
        GameIsPaused = value;
    }
}
