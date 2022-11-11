using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public PowerUp powerUp;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("triggered");
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.GetComponent<PlayerMovment>().SetPowerUp(powerUp);
                Destroy(this);
            }
        }
    }

}
