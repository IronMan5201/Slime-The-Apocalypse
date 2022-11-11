using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToiletScript : MonoBehaviour
{
    public GameObject winMenu;
    public GameObject UI;
    public GameObject backgroundMusic;
    public PauseMenu menu;
    public string nextLevel;
    void Start()
    {
        winMenu.SetActive(false);
        UI.SetActive(true);
        Time.timeScale = 1f;
        menu.SetPause(false);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UI.SetActive(false);
            winMenu.SetActive(true);
            Time.timeScale = 0f;
            menu.SetPause(true);
            backgroundMusic.GetComponent<AudioSource>().volume -= 0.9f;
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
}
