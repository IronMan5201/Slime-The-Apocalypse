using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public PowerUp currentPowerUp = PowerUp.NONE;
    public int health = 3;
    public float speed = 7.5f;

    public GameObject jumpSound;
    private AudioSource jumpAudio;
    private Rigidbody2D rb;
    private float direction;
    [SerializeField]private bool doubleJump;
    [SerializeField] private bool jumpOne;
    //Animtorcontroller of the player.
    public Animator playerMoveAction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpAudio = jumpSound.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
            playerMoveAction.SetBool("isWalk", true);
        else
            playerMoveAction.SetBool("isWalk", false);
        if (Input.GetAxis("Horizontal") < 0)
            GetComponent<Transform>().localScale = new Vector3(-5, 5, 1);
        else if (Input.GetAxis("Horizontal") > 0)
            GetComponent<Transform>().localScale = new Vector3(5, 5, 1);
        direction = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * direction, rb.velocity.y);

        switch (currentPowerUp)
        {
            case PowerUp.JUMP:
                DoubleJump();
                break;
            case PowerUp.HOVER:
                Hover();
                break;
        }

        if (Input.GetButtonDown("Jump") && playerMoveAction.GetBool("OnGround"))
        {
            jumpAudio.Play();
            rb.AddForce(new Vector2(rb.velocity.x, 750f));
            playerMoveAction.SetBool("Jump", true);
            playerMoveAction.SetBool("OnGround", false);
            jumpOne = true;
            
        }

        switch (currentPowerUp)
        {
            case PowerUp.SHOT:
                break;
            case PowerUp.NONE:
                break;
            default:
                break;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag.Equals("Ground"))
        {
            playerMoveAction.SetBool("OnGround", true);
            playerMoveAction.SetBool("Jump", false);
            doubleJump = true;
            jumpOne = false;
        }
    }

    public void DoubleJump()
    {
        if (Input.GetButtonDown("Jump") && doubleJump && jumpOne == true)
        {
            jumpAudio.Play();
            rb.AddForce(new Vector2(rb.velocity.x, 500f));
            playerMoveAction.SetBool("OnGround", false);
            playerMoveAction.SetBool("Jump", true);
            Debug.Log("jumped");
            doubleJump = false;
        }
    }

    public void Hover()
    {
        if (Input.GetButton("Jump") && rb.velocity.y < 0)
        {
            rb.AddForce(new Vector2(rb.velocity.x, 1.25f));
        }
    }

    /*private void OnCollisionStay(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag.Equals("Ground"))
            player_move_action.SetBool("OnGround", true);
    }*/

    public void SetPowerUp(PowerUp pu)
    {
        currentPowerUp = pu;
    }
}
