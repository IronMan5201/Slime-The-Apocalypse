using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float speed = 7.5f;
    private Rigidbody2D rb;
    private float direction;

    //Animtorcontroller of the player.
    public Animator playerMoveAction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
            playerMoveAction.SetBool("isWalk", true);
        else
            playerMoveAction.SetBool("isWalk", false);

        direction = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * direction, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && rb.velocity.y == 0)
        {
            rb.AddForce(new Vector2(rb.velocity.x, 500f));
            playerMoveAction.SetBool("Jump", true);
            playerMoveAction.SetBool("OnGround", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag.Equals("Ground"))
        {
            playerMoveAction.SetBool("OnGround", true);
            playerMoveAction.SetBool("Jump", false);
        }
    }



    /*private void OnCollisionStay(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag.Equals("Ground"))
            player_move_action.SetBool("OnGround", true);
    }*/
}
