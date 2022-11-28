using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class PatrolTask : BTNode
{
    private bool spottedPlayer;
    private Rigidbody2D rb;
    private Collider2D collider;
    private Transform transform;
    private Collider2D platformTracker;
    public LayerMask mask;
    public LayerMask blocker;
    public LayerMask button;
    private bool flip = false;
    private bool jumped = false;

    private Vector2 lastPos;

    // Start is called before the first frame update
    public PatrolTask(Collider2D collider, Rigidbody2D rigidbody, Transform transform, LayerMask mask, LayerMask button, LayerMask blocker)
    {
        spottedPlayer = false;
        rb = rigidbody;
        this.collider = collider;
        this.transform = transform;
        platformTracker = transform.Find("Tracker").GetComponent<Collider2D>();
        this.mask = mask;
        this.button = button;
        this.blocker = blocker;
    }

    public override NodeState Evaluate()
    {
        if (Time.time >= 1f && platformTracker.IsTouchingLayers(mask))
        {
            if (!spottedPlayer)
            {
                Debug.Log("Patrol Not Spotted");
                rb.velocity = new Vector2((flip ? -1 : 1) * /*speed*/ 500f * Time.deltaTime, rb.velocity.y);
                Debug.Log("TEST");
                Debug.Log("plat: " + platformTracker.IsTouchingLayers(mask));

                if (collider.IsTouchingLayers(button))
                    rb.velocity = new Vector2(rb.velocity.x, 250f * Time.deltaTime);

                if ((!platformTracker.IsTouchingLayers(mask) && collider.IsTouchingLayers(mask)) || platformTracker.IsTouchingLayers(blocker))
                {
                    flip = !flip;
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                    Debug.Log("Hit");
                }
            }
            else
            {
                Debug.Log("Patrol Spotted");
                rb.velocity = new Vector2(/*speed*/ 5f * Time.deltaTime, rb.velocity.y);
            }
        }
        state = NodeState.RUNNING;
        return state;
        
    }
    IEnumerator Jump()
    {
        jumped = true;
        rb.velocity = new Vector2(rb.velocity.x, 250f * Time.deltaTime);
        yield return new WaitForSeconds(0.5f);
        jumped = false;
    }


}



