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
    public float Level1Time = 2000.0f;
    public float Level2Time = 2000.0f;
    public float Level3Time = 2000.0f;
    public float Level4Time = 2000.0f;
    public float Level5Time = 2000.0f;
    public float Level6Time = 2000.0f;
    public float Level7Time = 2000.0f;
    public float Level8Time = 2000.0f;
    public float[] BestTimes;

    public int[] Passed;

    // Start is called before the first frame update
    void Awake()
    {
        Passed = new int[8];
        BestTimes = new float[8];
        
        Passed[0] = Level1Passed;
        Passed[1] = Level2Passed;
        Passed[2] = Level3Passed;
        Passed[3] = Level4Passed;
        Passed[4] = Level5Passed;
        Passed[5] = Level6Passed;
        Passed[6] = Level7Passed;
        Passed[7] = Level8Passed;
        
        /*
        BestTimes[0] = Level1Time;
        BestTimes[1] = Level2Time;
        BestTimes[2] = Level3Time;
        BestTimes[3] = Level4Time;
        BestTimes[4] = Level5Time;
        BestTimes[5] = Level6Time;
        BestTimes[6] = Level7Time;
        BestTimes[7] = Level8Time;
        */
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

        /*
        PlayerPrefs.SetFloat("Level1Time", Level1Time);
        PlayerPrefs.SetFloat("Level2Time", Level2Time);
        PlayerPrefs.SetFloat("Level3Time", Level3Time);
        PlayerPrefs.SetFloat("Level4Time", Level4Time);
        PlayerPrefs.SetFloat("Level5Time", Level5Time);
        PlayerPrefs.SetFloat("Level6Time", Level6Time);
        PlayerPrefs.SetFloat("Level7Time", Level7Time);
        PlayerPrefs.SetFloat("Level8Time", Level8Time);
        */

        Level1Time = PlayerPrefs.GetFloat("Level1Time", Level1Time);
        Level2Time = PlayerPrefs.GetFloat("Level2Time", Level2Time);
        Level3Time = PlayerPrefs.GetFloat("Level3Time", Level3Time);
        Level4Time = PlayerPrefs.GetFloat("Level4Time", Level4Time);
        Level5Time = PlayerPrefs.GetFloat("Level5Time", Level5Time);
        Level6Time = PlayerPrefs.GetFloat("Level6Time", Level6Time);
        Level7Time = PlayerPrefs.GetFloat("Level7Time", Level7Time);
        Level8Time = PlayerPrefs.GetFloat("Level8Time", Level8Time);

        
        PlayerPrefs.SetFloat("Level1Time", Level1Time);
        PlayerPrefs.SetFloat("Level2Time", Level2Time);
        PlayerPrefs.SetFloat("Level3Time", Level3Time);
        PlayerPrefs.SetFloat("Level4Time", Level4Time);
        PlayerPrefs.SetFloat("Level5Time", Level5Time);
        PlayerPrefs.SetFloat("Level6Time", Level6Time);
        PlayerPrefs.SetFloat("Level7Time", Level7Time);
        PlayerPrefs.SetFloat("Level8Time", Level8Time);
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateOpenLevels();

        UpdateBestTimes();
    }

    public void UpdateOpenLevels()
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

    public void UpdateBestTimes()
    {
        if(Level1Time < PlayerPrefs.GetFloat("Level1Time", Level1Time))
        {
            PlayerPrefs.SetFloat("Level1Time", Level1Time);
            BestTimes[0] = Level1Time;
        }
        if(Level2Time < PlayerPrefs.GetFloat("Level2Time", Level2Time))
        {
            PlayerPrefs.SetFloat("Level2Time", Level2Time);
            BestTimes[1] = Level2Time;
        }
        if(Level3Time < PlayerPrefs.GetFloat("Level3Time", Level3Time))
        {
            PlayerPrefs.SetFloat("Level3Time", Level3Time);
            BestTimes[2] = Level3Time;
        }
        if(Level4Time < PlayerPrefs.GetFloat("Level1Time", Level1Time))
        {
            PlayerPrefs.SetFloat("Level4Time", Level4Time);
            BestTimes[3] = Level4Time;
        }
        if(Level5Time < PlayerPrefs.GetFloat("Level1Time", Level1Time))
        {
            PlayerPrefs.SetFloat("Level5Time", Level5Time);
            BestTimes[4] = Level5Time;
        }
        if(Level6Time < PlayerPrefs.GetFloat("Level1Time", Level1Time))
        {
            PlayerPrefs.SetFloat("Level6Time", Level6Time);
            BestTimes[5] = Level6Time;
        }
        if(Level7Time < PlayerPrefs.GetFloat("Level1Time", Level1Time))
        {
            PlayerPrefs.SetFloat("Level7Time", Level7Time);
            BestTimes[6] = Level7Time;
        }
        if(Level8Time < PlayerPrefs.GetFloat("Level1Time", Level1Time))
        {
            PlayerPrefs.SetFloat("Level8Time", Level8Time);
            BestTimes[7] = Level8Time;
        }
    }
}
