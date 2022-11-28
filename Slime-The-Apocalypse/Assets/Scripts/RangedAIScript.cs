using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAIScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject ShotAudio;
    [SerializeField] private AudioSource shotSound;
    public Transform firePoint;
    private Collider2D player;
    public GameObject gun;
    private float timer;
    public float shootTime=2;
    void start()
    {
        player = null;
        if(shotSound == null)
            shotSound = ShotAudio.GetComponent<AudioSource>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other;
        }
        if (player != null)
        {
            if (Time.timeScale != 0)
            {
                timer += Time.deltaTime;
                Vector3 difference = player.transform.position - gun.transform.position;
                float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
                if (timer > shootTime)
                {
                    timer = 0;
                    shoot();
                    shotSound.Play();
                    
                }
            }
        }
        player = null;
    }
    void shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.right * 20f, ForceMode2D.Impulse);
    }
}
