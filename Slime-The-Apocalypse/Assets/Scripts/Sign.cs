using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public PowerUp powerUp;

    public GameObject powerUpSound;

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("triggered");
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("hit");
            collision.gameObject.GetComponent<PlayerMovement>().SetPowerUp(powerUp);
            Destroy(gameObject);
        }
        //}
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("triggered");
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("hit");
            powerUpSound.GetComponent<AudioSource>().Play();
            collision.gameObject.GetComponent<PlayerMovement>().SetPowerUp(powerUp);
            Destroy(gameObject);
        }
        //}
    }

}
