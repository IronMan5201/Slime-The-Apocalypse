using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public GameObject MeleeKilledSound;
    private AudioSource meleeKilledAudio;

    void Start()
    {
        if(MeleeKilledSound == null)
        {
            MeleeKilledSound = GameObject.Find("MeleeKilledSound");
        }
        meleeKilledAudio = MeleeKilledSound.GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            if (player.transform.position.y - 1 >= gameObject.transform.position.y)
            {
                player.GetComponent<PlayerMovement>().swallowedEnemy = gameObject;
                gameObject.SetActive(false);
                meleeKilledAudio.Play();
            }
            else
            {
                Debug.Log("Player was hit, lost 1 hp");
                player.GetComponent<PlayerMovement>().LoseHealth(1);
            }
        }
    }
}
