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
    private Collider2D wallTracker;
    public LayerMask mask;
    public LayerMask enemy;
    public LayerMask blocker;
    public LayerMask button;
    private bool flip = false;
    private bool jumped = false;

    private Vector2 lastPos;

    // Start is called before the first frame update
    public PatrolTask(Collider2D entitiyCollider, Rigidbody2D rigidbody, Transform transform, LayerMask mask, LayerMask button, LayerMask blocker, LayerMask enemy, Collider2D wallTracker, Collider2D platformTracker)
    {
        spottedPlayer = false;
        rb = rigidbody;
        this.collider = entitiyCollider;
        this.transform = transform;
        this.platformTracker = platformTracker;
        this.mask = mask;
        this.button = button;
        this.blocker = blocker;
        this.wallTracker = wallTracker;
        this.enemy = enemy;
    }

    public override NodeState Evaluate()
    {
        Debug.Log(" Colliders touching tiles \n platformTracker: " + platformTracker.IsTouchingLayers(mask) 
            + "\n collider: " + collider.IsTouchingLayers(mask) 
            + "\n WallTracker: " + wallTracker.IsTouchingLayers(mask) 
            +/*"\n Time:" + Time.time +*/"\n WallEnemy"+ wallTracker.IsTouchingLayers(enemy) 
            + "\n ColidEnemy" + collider.IsTouchingLayers(enemy)
            + "\n ColidEnt" + collider.IsTouchingLayers(button)
            + "\n ColidBlocker" + collider.IsTouchingLayers(blocker));

        if (Time.time >= 1f && collider.IsTouchingLayers(mask))
        {
            if (!spottedPlayer)
            {
                Debug.Log("Patrol Not Spotted");
                rb.velocity = new Vector2((flip ? -1 : 1) * /*speed*/ 500f * Time.deltaTime, rb.velocity.y);
                
                if (collider.IsTouchingLayers(button))
                    rb.velocity = new Vector2(rb.velocity.x, 250f * Time.deltaTime);

                if ( (!platformTracker.IsTouchingLayers(mask) && collider.IsTouchingLayers(mask)) || platformTracker.IsTouchingLayers(blocker))
                {
                    flip = !flip;
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                    Debug.Log("Edge");
                }

                if (wallTracker.IsTouchingLayers(mask) || wallTracker.IsTouchingLayers(enemy) || wallTracker.IsTouchingLayers(blocker))
                {
                    flip = !flip;
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                    Debug.Log("Hit Wall");
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



