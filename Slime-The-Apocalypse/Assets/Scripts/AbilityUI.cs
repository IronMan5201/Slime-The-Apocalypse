using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AbilityUI : MonoBehaviour
{
    public GameObject player;

    private PowerUp powerUp;

    public TextMeshProUGUI abilityGUI;
    // Start is called before the first frame update
    void Start()
    {
        powerUp = player.GetComponent<PlayerMovment>().currentPowerUp;
        abilityGUI.text = "Ability:\nNone";
    }

    // Update is called once per frame
    void Update()
    {
        powerUp = player.GetComponent<PlayerMovment>().currentPowerUp;
        string text = "NONE";
        switch (powerUp)
        {
            case PowerUp.NONE:
                text = "NONE";
                break;
            case PowerUp.JUMP:
                text = "DOUBLE JUMP";
                break;
            case PowerUp.SHOT:
                text = "SWALLOW SHOT";
                break;
            case PowerUp.HOVER:
                text = "HOVER";
                break;
            default:
                break;
        }

        abilityGUI.text = "Ability:\n" + text;
    }
}
