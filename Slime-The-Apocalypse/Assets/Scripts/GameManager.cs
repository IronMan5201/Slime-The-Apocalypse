using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool win = false;
    public bool lose = false;
    public bool winLoseSwitch = false;

    public GameObject player;
    public GameObject toilet;
    public GameObject canvasObject;

    public float bufferTime = 1f;

    private void Awake()
    {
       win = false;
       lose = false;
       winLoseSwitch = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        SanityCheck();
    }

    // Update is called once per frame
    void Update()
    {
        if ((win || lose) && !winLoseSwitch)
        {
            WinLose();
        }
            
    }

    public void WinLose()
    {
        winLoseSwitch = true;

        if (win)
            StartCoroutine(Win());
        if (lose)
            StartCoroutine(Lose());
    }

    public IEnumerator Win()
    {
        
        yield return new WaitForSeconds(bufferTime);
        //Activate Reward Screen
    }

    public IEnumerator Lose()
    {
        yield return new WaitForSeconds(bufferTime);
        // Activate Lose Screen
    }

    public void SanityCheck()
    {
        if (player == null)
            if (GameObject.Find(/*"Player Object Name"*/"") != null)
                player = GameObject.Find(/*"Player Object Name"*/"");

        if (toilet == null)
            if (GameObject.Find(/*"toilet Object Name"*/"") != null)
                toilet = GameObject.Find(/*"toilet Object Name"*/"");

        if (canvasObject == null)
            if (GameObject.Find(/*"canvasObject Object Name"*/"") != null)
                canvasObject = GameObject.Find(/*"canvasObject Object Name"*/"");
    }
}
