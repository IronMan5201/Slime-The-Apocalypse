using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    // Start is called before the first frame update
    enum direction {UP, UPRIGHT,RIGHT,DOWNRIGHT,DOWN,DOWNLEFT,LEFT,UPLEFT }
    int currentWaypoint = 0;
    public Transform[] waypoints = new Transform[10];
    private Transform transform;
    private Rigidbody2D rb;
    void Start()
    {
        transform = gameObject.transform;
        rb = gameObject.GetComponent<Rigidbody2D>();

        if (waypoints[0] != null)
        {
            

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!CheckDestination())
        {
            //transform.Translate(waypoints[currentWaypoint].position, Space.Self);
            rb.AddRelativeForce(waypoints[currentWaypoint].position);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            currentWaypoint = (currentWaypoint + 1) != waypoints.Length ? currentWaypoint += 1 : currentWaypoint = 0;
        }
    }

    public bool CheckDestination()
    {
        if (transform.position.x >= waypoints[currentWaypoint].position.x -0.25f)
        {
            if (transform.position.x <= waypoints[currentWaypoint].position.x + 0.25f)
            {
                if (transform.position.y <= waypoints[currentWaypoint].position.y + 0.25f)
                {
                    if (transform.position.y <= waypoints[currentWaypoint].position.y + 0.25f)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
        

        
    }


}
