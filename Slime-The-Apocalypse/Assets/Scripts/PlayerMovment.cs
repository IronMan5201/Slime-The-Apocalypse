using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float speed = 7.5f;
    private Rigidbody2D rb;
    private float direction;

    //Animtorcontroller of the player.
    public Animator player_move_action;
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
        if (Input.GetButtonDown("Jump") && rb.velocity.y==0)
        {
            rb.AddForce(new Vector2(rb.velocity.x, 500f));
            player_move_action.SetBool("Jump",true);
            player_move_action.SetBool("OnGround", true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
            player_move_action.SetBool("OnGround", true);
    }

 
}
