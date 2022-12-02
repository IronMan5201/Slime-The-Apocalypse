using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject hitEffect;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMovement>().LoseHealth(1);
            Debug.Log("Player was hit!");
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
