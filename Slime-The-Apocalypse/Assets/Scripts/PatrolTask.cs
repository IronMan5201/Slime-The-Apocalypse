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

    // Start is called before the first frame update
    public PatrolTask(Collider2D collider, Rigidbody2D rigidbody, Transform transform)
    {
        spottedPlayer = false;
        rb = rigidbody;
        this.collider = collider;
        this.transform = transform;
    }

    public override NodeState Evaluate()
    {
        if (!spottedPlayer)
        {
            Debug.Log("Patrol Not Spotted");
            rb.velocity = new Vector2(/*speed*/ 500f * Time.deltaTime, rb.velocity.y);
            collider.IsTouchingLayers(/*Obstacles*/);
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
