using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public Scene Level1;
    public Scene Level2;
    public Scene Level3;
    [SerializeField] private Scene currentScene;
    [SerializeField] private bool Level1Passed = false;
    [SerializeField] private bool Level2Passed = false;
    [SerializeField] private bool Level3Passed = false;

    public GameObject LevelSelect;
    public GameObject Level1Button;
    public GameObject Level2Button;
    public GameObject Level3Button;

    // Start is called before the first frame update
    void Start()
    {
        Level1 = SceneManager.GetSceneByName("Level 1");
        Level2 = SceneManager.GetSceneByName("Level 2");
        Level3 = SceneManager.GetSceneByName("Level 3");
        currentScene = SceneManager.GetActiveScene();
        if(currentScene.Equals("Main Menu"))
        {

        }
        else if(currentScene.Equals("Level Select"))
        {
            
        }
        else if(currentScene.Equals("Level 1"))
        {
            Level1Passed = false;
            Level2Passed = false;
            Level3Passed = false;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
