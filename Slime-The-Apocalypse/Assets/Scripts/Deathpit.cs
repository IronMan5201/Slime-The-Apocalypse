using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathpit : MonoBehaviour
{
    public bool objectDied;

    void Start()
    {
        objectDied = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        objectDied = true;
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Debug.Log("Enemy was destroyed");
            objectDied = false;
        }
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player was Destroyed, restarting scene");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
