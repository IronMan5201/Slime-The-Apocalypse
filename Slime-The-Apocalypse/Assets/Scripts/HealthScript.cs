using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    public PauseMenu Died;
    public GameObject Player;
    private PlayerMovement PlayerInfo;
    public Image Heart1;
    public Image Heart2;
    public Image Heart3;

    public Sprite HeartFull;
    public Sprite HeartEmpty;
    // Start is called before the first frame update
    void Start()
    {
        Heart1.sprite = HeartFull;
        Heart2.sprite = HeartFull;
        Heart3.sprite = HeartFull;
        PlayerInfo = Player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerInfo.health == 3)
        {
            //set all hearts full
            Heart1.sprite = HeartFull;
            Heart2.sprite = HeartFull;
            Heart3.sprite = HeartFull;
        }
        else if(PlayerInfo.health == 2)
        {
            //set last heart empty
            Heart1.sprite = HeartFull;
            Heart2.sprite = HeartFull;
            Heart3.sprite = HeartEmpty;
        }
        else if(PlayerInfo.health == 1)
        {
            //set last two hearts empty
            Heart1.sprite = HeartFull;
            Heart2.sprite = HeartEmpty;
            Heart3.sprite = HeartEmpty;
        }
        else if(PlayerInfo.health == 0)
        {
            //set all hearts empty, dead
            Heart1.sprite = HeartEmpty;
            Heart2.sprite = HeartEmpty;
            Heart3.sprite = HeartEmpty;
            PlayerDied();
        }

    }

    void PlayerDied()
    {
        Died.PlayerDied();
    }
}
