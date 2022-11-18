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
    private bool flip = false;


    // Start is called before the first frame update
    public PatrolTask(Collider2D collider, Rigidbody2D rigidbody, Transform transform, LayerMask mask)
    {
        spottedPlayer = false;
        rb = rigidbody;
        this.collider = collider;
        this.transform = transform;
        platformTracker = transform.Find("Tracker").GetComponent<Collider2D>();
        this.mask = mask;
    }

    public override NodeState Evaluate()
    {
        if (!spottedPlayer)
        {
            Debug.Log("Patrol Not Spotted");
            rb.velocity = new Vector2( (flip ? -1 : 1) * /*speed*/ 500f * Time.deltaTime, rb.velocity.y);
            Debug.Log("TEST");
            Debug.Log("plat: " + platformTracker.IsTouchingLayers(mask));

            if (!platformTracker.IsTouchingLayers(mask) && collider.IsTouchingLayers(mask))
            {
                flip = !flip ;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                Debug.Log("Hit");
            }
        }
        else
        {
            Debug.Log("Patrol Spotted");
            rb.velocity = new Vector2(/*speed*/ 5f * Time.deltaTime, rb.velocity.y);
        }

        state = NodeState.RUNNING;
        return state;
    }

    
}
