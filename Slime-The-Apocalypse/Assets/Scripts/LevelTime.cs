using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTime : MonoBehaviour
{

    public float currentTime;

    public int currentTimeGUI;

    public TextMeshProUGUI timeGUI;

    public PauseMenu menu;

    public int DelayAmount = 1;
    // Start is called before the first frame update
    void Start()
    {
        if(menu == null)
        {
            menu = FindObjectOfType<PauseMenu>();
        }
        currentTime = 0.0f;
        currentTimeGUI = 0;
        timeGUI.text = "Time-" + currentTimeGUI.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(!menu.IsPaused())
        {
            currentTime += Time.deltaTime;
            timeGUI.text = "Time-" + System.TimeSpan.FromSeconds(currentTime).ToString("mm':'ss");
            /*if(currentTime >= DelayAmount)
            {
                currentTime = 0f;
                currentTimeGUI++;
                timeGUI.text = "Time-" + System.TimeSpan.FromSeconds(currentTime).ToString("mm':'ss");
            }*/
        }
    }
}
