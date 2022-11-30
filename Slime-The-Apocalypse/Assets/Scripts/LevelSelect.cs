using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSelect : MonoBehaviour
{
    private int i;
    public LevelManager manager;
    public GameObject Level1Button;
    public GameObject Level2Button;
    public GameObject Level3Button;
    public GameObject Level4Button;
    public GameObject Level5Button;
    public GameObject Level6Button;
    public GameObject Level7Button;
    public GameObject Level8Button;
    private GameObject[] Buttons;
    // Start is called before the first frame update
    void Start()
    { 
        Buttons = new GameObject[8];
        Buttons[0] = Level1Button;
        Buttons[1] = Level2Button;
        Buttons[2] = Level3Button;
        Buttons[3] = Level4Button;
        Buttons[4] = Level5Button;
        Buttons[5] = Level6Button;
        Buttons[6] = Level7Button;
        Buttons[7] = Level8Button;
    }

    // Update is called once per frame
    void Update()
    {

        for(i = 0; i < Buttons.Length; i++)
        {
            switch(manager.Passed[i])
            {
                case 0:
                    Buttons[i].SetActive(false);
                    break;
                case 1:
                    Buttons[i].SetActive(true);
                    break;
                case 2:
                    Buttons[i].SetActive(true);
                    break;
            }
        }
    }
}
