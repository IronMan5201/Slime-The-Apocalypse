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
    public GameObject Level1BestTime;
    public GameObject Level2BestTime;
    public GameObject Level3BestTime;
    public GameObject Level4BestTime;
    public GameObject Level5BestTime;
    public GameObject Level6BestTime;
    public GameObject Level7BestTime;
    public GameObject Level8BestTime;
    private GameObject[] Buttons;
    private GameObject[] Times;
    // Start is called before the first frame update
    void Start()
    { 
        Buttons = new GameObject[8];
        Times = new GameObject[8];
        Buttons[0] = Level1Button;
        Buttons[1] = Level2Button;
        Buttons[2] = Level3Button;
        Buttons[3] = Level4Button;
        Buttons[4] = Level5Button;
        Buttons[5] = Level6Button;
        Buttons[6] = Level7Button;
        Buttons[7] = Level8Button;

        Times[0] = Level1BestTime;
        Times[1] = Level2BestTime;
        Times[2] = Level3BestTime;
        Times[3] = Level4BestTime;
        Times[4] = Level5BestTime;
        Times[5] = Level6BestTime;
        Times[6] = Level7BestTime;
        Times[7] = Level8BestTime;
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
                    Times[i].SetActive(false);
                    break;
            }
        }
        
        for(i = 1; i < Buttons.Length; i++)
        {
            if(manager.Passed[i-1] == 1)
            {
                Buttons[i].SetActive(true);
            }
        }

        //update best time gui
        Times[0].GetComponent<TextMeshProUGUI>().text = "Best Time- " + System.TimeSpan.FromSeconds(manager.Level1Time).ToString("mm':'ss");
        Times[1].GetComponent<TextMeshProUGUI>().text = "Best Time- " + System.TimeSpan.FromSeconds(manager.Level2Time).ToString("mm':'ss");
        Times[2].GetComponent<TextMeshProUGUI>().text = "Best Time- " + System.TimeSpan.FromSeconds(manager.Level3Time).ToString("mm':'ss");
        Times[3].GetComponent<TextMeshProUGUI>().text = "Best Time- " + System.TimeSpan.FromSeconds(manager.Level4Time).ToString("mm':'ss");
        Times[4].GetComponent<TextMeshProUGUI>().text = "Best Time- " + System.TimeSpan.FromSeconds(manager.Level5Time).ToString("mm':'ss");
        Times[5].GetComponent<TextMeshProUGUI>().text = "Best Time- " + System.TimeSpan.FromSeconds(manager.Level6Time).ToString("mm':'ss");
        Times[6].GetComponent<TextMeshProUGUI>().text = "Best Time- " + System.TimeSpan.FromSeconds(manager.Level7Time).ToString("mm':'ss");
        Times[7].GetComponent<TextMeshProUGUI>().text = "Best Time- " + System.TimeSpan.FromSeconds(manager.Level8Time).ToString("mm':'ss");
    }
}
