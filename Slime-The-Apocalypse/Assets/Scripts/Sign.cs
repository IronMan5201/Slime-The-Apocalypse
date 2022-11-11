using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public PowerUp powerUp;

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("triggered");
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("hit");
            collision.gameObject.GetComponent<PlayerMovment>().SetPowerUp(powerUp);
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
            collision.gameObject.GetComponent<PlayerMovment>().SetPowerUp(powerUp);
            Destroy(gameObject);
        }
        //}
    }

}
