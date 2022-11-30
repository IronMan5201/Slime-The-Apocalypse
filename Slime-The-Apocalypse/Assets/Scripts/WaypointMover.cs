using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    // Start is called before the first frame update
    enum direction { UP, UPRIGHT, RIGHT, DOWNRIGHT, DOWN, DOWNLEFT, LEFT, UPLEFT }
    [SerializeField] int currentWaypoint = 0;
    public Transform[] waypoints = new Transform[10];
    public float multiply;
    private Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        if (waypoints[0] != null)
        {
            

        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentWaypoint);
        if (!CheckDestination())
        {
            Debug.Log(currentWaypoint+ "fcheck");
            //transform.Translate(waypoints[currentWaypoint].position, Space.Self);
            Vector2 force = new Vector2(0,0);

            if (transform.position.x < waypoints[currentWaypoint].position.x - 0.1)
                force.x = 100f;
            else if (transform.position.x > waypoints[currentWaypoint].position.x + 0.1)
                force.x = -100f;

            if (transform.position.y < waypoints[currentWaypoint].position.y - 0.1)
                force.y = 100f;
            else if (transform.position.y > waypoints[currentWaypoint].position.y + 0.1)
                force.y = -100f;

            force = new Vector2(force.x * Time.deltaTime , force.y * Time.deltaTime );
            rb.velocity = force.normalized * multiply;
        }
        else
        {
            Debug.Log(currentWaypoint + "tcheck");
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
                if (transform.position.y >= waypoints[currentWaypoint].position.y - 0.25f)
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
