using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Animator button_Animation;
    public Animator Door_Animtion;
    // Start is called before the first frame update
    void Start()
    {
        button_Animation.SetBool("Press_Button", false);
        Door_Animtion.SetBool("Is_Open", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {        
        if (collision.gameObject.tag == "Player")
        {
            button_Animation.SetBool("Press_Button", true);
            Door_Animtion.SetBool("Is_Open", true);
        }
    }
}
