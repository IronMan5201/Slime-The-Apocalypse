using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToiletScript : MonoBehaviour
{
    public GameObject winMenu;
    public GameObject UI;
    public GameObject backgroundMusic;
    public GameObject winSound;
    public PauseMenu menu;
    public string nextLevel;
    //private string currentScene;
    public LevelManager manager;
    public LevelTime time;
    void Start()
    {
        if(winSound == null)
        {
            winSound = GameObject.Find("WinSound");
        }
        if(winMenu == null)
        {
            winMenu = GameObject.Find("WinCanvas");
        }
        if(UI == null)
        {
            UI = GameObject.Find("Info");
        }
        if(menu == null)
        {
            GameObject temp = GameObject.Find("PauseCanvas");
            menu = temp.GetComponent<PauseMenu>();
        }
        if(manager == null)
        {
            GameObject temp = GameObject.Find("LevelManager");
            manager = temp.GetComponent<LevelManager>();
        }
        if(time == null)
        {
            GameObject temp = GameObject.Find("PlayCanvas");
            time = temp.GetComponent<LevelTime>();
        }

        //currentScene = SceneManager.GetActiveScene();
        winMenu.SetActive(false);
        UI.SetActive(true);
        Time.timeScale = 1f;
        menu.SetPause(false);
        Debug.Log("****"+SceneManager.GetActiveScene().name);
        if(SceneManager.GetActiveScene().name.Equals("Level 1"))
        {
            Debug.Log("shit");
            manager.Level1Passed = 2;
        }
        else if(SceneManager.GetActiveScene().name.Equals("Level 2"))
        {
            manager.Level2Passed = 2;
        }
        else if(SceneManager.GetActiveScene().name.Equals("Level 3"))
        {
            manager.Level3Passed = 2;
        }
        else if(SceneManager.GetActiveScene().name.Equals("Level 4"))
        {
            manager.Level4Passed = 2;
        }
        else if(SceneManager.GetActiveScene().name.Equals("Level 5"))
        {
            manager.Level5Passed = 2;
        }
        else if(SceneManager.GetActiveScene().name.Equals("Level 6"))
        {
            manager.Level6Passed = 2;
        }
        else if(SceneManager.GetActiveScene().name.Equals("Level 7"))
        {
            manager.Level7Passed = 2;
        }
        else if(SceneManager.GetActiveScene().name.Equals("Level 8"))
        {
            manager.Level8Passed = 2;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UI.SetActive(false);
            winMenu.SetActive(true);
            Time.timeScale = 0f;
            menu.SetPause(true);
            winSound.GetComponent<AudioSource>().Play();
            backgroundMusic.GetComponent<AudioSource>().volume -= 0.9f;
            LevelComplete(SceneManager.GetActiveScene().name);
        }
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
    public void goToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LevelComplete(string scene)
    {
        if(scene.Equals("Level 1"))
        {
            manager.Level1Passed = 1;
            if(manager.Level1Time > time.currentTime)
                manager.Level1Time = time.currentTime;
        }
        else if(scene.Equals("Level 2"))
        {
            manager.Level2Passed = 1;
            if(manager.Level2Time > time.currentTime)
                manager.Level2Time = time.currentTime;
        }
        else if(scene.Equals("Level 3"))
        {
            manager.Level3Passed = 1;
            if(manager.Level3Time > time.currentTime)
                manager.Level3Time = time.currentTime;
        }
        else if(scene.Equals("Level 4"))
        {
            manager.Level4Passed = 1;
            if(manager.Level4Time > time.currentTime)
                manager.Level4Time = time.currentTime;
        }
        else if(scene.Equals("Level 5"))
        {
            manager.Level5Passed = 1;
            if(manager.Level5Time > time.currentTime)
                manager.Level5Time = time.currentTime;
        }
        else if(scene.Equals("Level 6"))
        {
            manager.Level6Passed = 1;
            if(manager.Level6Time > time.currentTime)
                manager.Level6Time = time.currentTime;
        }
        else if(scene.Equals("Level 7"))
        {
            manager.Level7Passed = 1;
            if(manager.Level7Time > time.currentTime)
                manager.Level7Time = time.currentTime;
        }
        else if(scene.Equals("Level 8"))
        {
            manager.Level8Passed = 1;
            if(manager.Level8Time > time.currentTime)
                manager.Level8Time = time.currentTime;
        }
    }
}
