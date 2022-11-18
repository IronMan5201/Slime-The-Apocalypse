using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            if (player.transform.position.y - 1 >= gameObject.transform.position.y)
            {
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Player was hit, lost 1 hp");
                player.GetComponent<PlayerMovement>().LoseHealth(1);
            }
        }
    }
}
