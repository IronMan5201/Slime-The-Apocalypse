using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToiletScript : MonoBehaviour
{
    public GameObject winMenu;
    public GameObject UI;
    public string nextLevel;
    void Start()
    {
        winMenu.SetActive(false);
        UI.SetActive(true);
        Time.timeScale = 1f;
    }
    void OnCollisionEnter2D(Collision2D collsion)
    {
        UI.SetActive(false);
        winMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void nextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
    public void goToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
