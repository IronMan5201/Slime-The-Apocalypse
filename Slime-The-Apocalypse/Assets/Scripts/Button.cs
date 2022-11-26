using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool isPressed;
    public GameObject buttonSound;
    public GameObject doorSound;
    private AudioSource doorAudio;
    private AudioSource buttonAudio;
    public Animator button_Animation;
    public Animator Door_Animtion;
    // Start is called before the first frame update
    void Start()
    {
        button_Animation.SetBool("PressButton", false);
        Door_Animtion.SetBool("IsOpen", false);
        buttonAudio = buttonSound.GetComponent<AudioSource>();
        doorAudio = doorSound.GetComponent<AudioSource>();
        isPressed = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(isPressed == true)
        {
            buttonAudio.volume = 0.0f;
            doorAudio.volume = 0.0f;
        }
        else if(isPressed == false)
        {
            buttonAudio.volume = 1.0f;
            doorAudio.volume = 0.2f;
        }

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            buttonAudio.Play();
            button_Animation.SetBool("PressButton", true);
            StartCoroutine(Waiter());
            Door_Animtion.SetBool("IsOpen", true);
            doorAudio.Play();
            isPressed = true;
        }
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(10);
    }
}
