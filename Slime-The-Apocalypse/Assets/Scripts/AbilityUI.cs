using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    public GameObject player;

    private PowerUp powerUp;

    public Image powerImage;

    public Sprite jumpSprite;

    public Sprite shotSprite;

    public Sprite hoverSprite;

    public TextMeshProUGUI abilityGUI;
    // Start is called before the first frame update
    void Start()
    {
        powerUp = player.GetComponent<PlayerMovement>().currentPowerUp;
        abilityGUI.text = "Ability:\nNone";
    }

    // Update is called once per frame
    void Update()
    {
        powerUp = player.GetComponent<PlayerMovement>().currentPowerUp;
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
        changeImage(powerUp);
    }

    void changeImage(PowerUp myPower)
    {
        switch (myPower)
        {
            case PowerUp.NONE:
                powerImage.sprite = null;
                powerImage.color = new Color32(38, 152, 0, 0);
                break;
            case PowerUp.JUMP:
                powerImage.sprite = jumpSprite;
                powerImage.color = new Color32(38, 152, 0, 255);
                break;
            case PowerUp.SHOT:
                powerImage.sprite = shotSprite;
                powerImage.color = new Color32(38, 152, 0, 255);
                break;
            case PowerUp.HOVER:
                powerImage.sprite = hoverSprite;
                powerImage.color = new Color32(38, 152, 0, 255);
                break;
            default:
                break;
        }
    }
}
