using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float speed = 7.5f;
    private Rigidbody2D rb;
    private float direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * direction, rb.velocity.y);
        if (Input.GetButtonDown("Jump")&&rb.velocity.y==0)
        {
            rb.AddForce(new Vector2(rb.velocity.x, 500f));
        }
    }
}
