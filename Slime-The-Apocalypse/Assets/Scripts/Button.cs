using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject buttonSound;
    public GameObject doorSound;
    private AudioSource doorAudio;
    private AudioSource buttonAudio;
    public Animator button_Animation;
    public Animator Door_Animtion;
    // Start is called before the first frame update
    void Start()
    {
        button_Animation.SetBool("Press_Button", false);
        Door_Animtion.SetBool("Is_Open", false);
        buttonAudio = buttonSound.GetComponent<AudioSource>();
        doorAudio = doorSound.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {        
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            buttonAudio.Play();
            button_Animation.SetBool("Press_Button", true);
            StartCoroutine(Waiter());
            Door_Animtion.SetBool("Is_Open", true);
            doorAudio.Play();
        }
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(10);
    }
}
