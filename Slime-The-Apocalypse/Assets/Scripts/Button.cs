using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool isPressed;
    public float TimeLength=10f; //Set to <= 0 if you want the timer to be unlimited
    public GameObject buttonSound;
    public GameObject doorSound;
    private AudioSource doorAudio;
    private AudioSource buttonAudio;
    public Animator button_Animation;
    public Animator Door_Animtion;

    public LayerMask enemy;
    public LayerMask player;

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
        if (isPressed == false)
        {
            buttonAudio.volume = 1.0f;
            doorAudio.volume = 0.2f;
        }
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
            Door_Animtion.SetBool("IsOpen", true);
            doorAudio.Play();
            isPressed = true;
            if (TimeLength>0)
            {
                Debug.Log("start");
                StartCoroutine(Waiter());
            }
        }
    }

    

    IEnumerator Waiter()
    {
        Debug.Log(gameObject.GetComponent<Collider2D>().IsTouchingLayers(enemy) +" "+ !gameObject.GetComponent<Collider2D>().IsTouchingLayers(player));
        yield return new WaitForSeconds(TimeLength);
        if (gameObject.GetComponent<Collider2D>().IsTouchingLayers(enemy) || gameObject.GetComponent<Collider2D>().IsTouchingLayers(player))
        {
            Debug.Log("recurse");
            StartCoroutine(Waiter());
        }
        else
        {
            Debug.Log("else");
            button_Animation.SetBool("PressButton", false);
            Door_Animtion.SetBool("IsOpen", false);
            isPressed = false;
        }
        Debug.Log("hit");
    }
}
