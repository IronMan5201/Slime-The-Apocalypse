using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PowerUp currentPowerUp = PowerUp.NONE;
    public int health = 3;
    public float speed = 7.5f;
    private bool invulnerable = false;
    public GameObject swallowedEnemy;
    public GameObject shotPoint;
    public GameObject jumpSound;
    private AudioSource jumpAudio;
    public GameObject TookDamageSound;
    private AudioSource tookDamageAudio;
    private Rigidbody2D rb;
    private float direction;
    [SerializeField]private bool doubleJump;
    public bool jumpOne;
    public float shotMultiplier;

    //Animtorcontroller of the player.
    public Animator playerMoveAction;


    // Start is called before the first frame update
    void Start()
    {
        if(jumpSound == null)
        {
            jumpSound = GameObject.Find("JumpSound");
        }
        if(TookDamageSound == null)
        {
            TookDamageSound = GameObject.Find("TookDamageSound");
        }
        rb = GetComponent<Rigidbody2D>();
        jumpAudio = jumpSound.GetComponent<AudioSource>();
        tookDamageAudio = TookDamageSound.GetComponent<AudioSource>();
        swallowedEnemy = null;
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
                SwallowShot();
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
            playerMoveAction.SetBool("Jump", false);
            playerMoveAction.SetBool("OnGround", true);
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

    public void SwallowShot()
    {
        if (swallowedEnemy != null && Input.GetButtonDown("Fire1"))
        {
            swallowedEnemy.transform.position = shotPoint.transform.position;
            swallowedEnemy.SetActive(true);
            //swallowedEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(shotPoint.transform.position.x*5f, 0);
            if (GetComponent<Transform>().localScale.x < 0) {
                swallowedEnemy.GetComponent<Rigidbody2D>().AddForce(shotPoint.transform.up * 15f , ForceMode2D.Impulse);
                swallowedEnemy.GetComponent<Rigidbody2D>().AddForce(shotPoint.transform.right * -10f , ForceMode2D.Impulse);
            }
            else
            {
                swallowedEnemy.GetComponent<Rigidbody2D>().AddForce(shotPoint.transform.up * 15f , ForceMode2D.Impulse);
                swallowedEnemy.GetComponent<Rigidbody2D>().AddForce(shotPoint.transform.right * 10f, ForceMode2D.Impulse);
            }
            swallowedEnemy = null;
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

    public void LoseHealth(int amount)
    {
        if (!invulnerable)
        {
            tookDamageAudio.Play();
            health -= amount;
            StartCoroutine(Invulnerablity());
        }
        
    }

    IEnumerator Invulnerablity()
    {
        invulnerable = true;
        yield return new WaitForSeconds(3f);
        invulnerable = false;
    }
}
