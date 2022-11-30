using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public int Level1Passed;
    public int Level2Passed;
    public int Level3Passed;
    public int Level4Passed;
    public int Level5Passed;
    public int Level6Passed;
    public int Level7Passed;
    public int Level8Passed;

    public int[] Passed;

    // Start is called before the first frame update
    void Awake()
    {
        Passed = new int[8];
        
        Passed[0] = Level1Passed;
        Passed[1] = Level2Passed;
        Passed[2] = Level3Passed;
        Passed[3] = Level4Passed;
        Passed[4] = Level5Passed;
        Passed[5] = Level6Passed;
        Passed[6] = Level7Passed;
        Passed[7] = Level8Passed;
        //check to see what levels are passed.
        //All passed levels have a value of 1, current level is 2, locked levels are 0
        //The win menu will change these values
        Level1Passed = PlayerPrefs.GetInt("Level1Passed", Level1Passed);
        Level2Passed = PlayerPrefs.GetInt("Level2Passed", Level2Passed);
        Level3Passed = PlayerPrefs.GetInt("Level3Passed", Level3Passed);
        Level4Passed = PlayerPrefs.GetInt("Level4Passed", Level4Passed);
        Level5Passed = PlayerPrefs.GetInt("Level5Passed", Level5Passed);
        Level6Passed = PlayerPrefs.GetInt("Level6Passed", Level6Passed);
        Level7Passed = PlayerPrefs.GetInt("Level7Passed", Level7Passed);
        Level8Passed = PlayerPrefs.GetInt("Level8Passed", Level8Passed);
        //Passed = 1
        //Current = 2
        //Locked = 0
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Level1Passed", Level1Passed);
        PlayerPrefs.SetInt("Level2Passed", Level2Passed);
        PlayerPrefs.SetInt("Level3Passed", Level3Passed);
        PlayerPrefs.SetInt("Level4Passed", Level4Passed);
        PlayerPrefs.SetInt("Level5Passed", Level5Passed);
        PlayerPrefs.SetInt("Level6Passed", Level6Passed);
        PlayerPrefs.SetInt("Level7Passed", Level7Passed);
        PlayerPrefs.SetInt("Level8Passed", Level8Passed);

        Passed[0] = Level1Passed;
        Passed[1] = Level2Passed;
        Passed[2] = Level3Passed;
        Passed[3] = Level4Passed;
        Passed[4] = Level5Passed;
        Passed[5] = Level6Passed;
        Passed[6] = Level7Passed;
        Passed[7] = Level8Passed;
    }
}
