using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float Platform_Speed = 0.01f;
    public bool Platform_Moved = true;
    public Transform loc1_position;
    public Transform loc2_position;
    public Transform Platforms_position;
    public float y_goal;
    public Collider2D platform_moved2;
    // Start is called before the first frame update
    void Start()
    {
        if (Platforms_position.position.y < loc2_position.position.y)
        {
            y_goal = loc2_position.position.y;
        }
        else if(Platforms_position.position.y >= loc2_position.position.y)
        {
            y_goal = loc1_position.position.y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Platform_Moved)
        {
            Vector2 i, j;
            if (y_goal > Platforms_position.position.y)
            {
                i = Platforms_position.position;
                //j = platform_moved2.offset;
                i.y += Platform_Speed;
                //j.y += Platform_Speed;
                Platforms_position.position = i;
                //platform_moved2.offset = j;
            }
            else
            {
                i = Platforms_position.position;
                //j = platform_moved2.offset;
                i.y -= Platform_Speed;
                //j.y -= Platform_Speed;
                Platforms_position.position = i;
                //platform_moved2.offset = j;
            }
            y_goal = goal_location();
        } 
    }
    public float goal_location()
    {
        float j;
        if (Platforms_position.position.y <= loc1_position.position.y)
        {
            j = loc2_position.position.y;
            return j;
        }
        else if(Platforms_position.position.y >= loc2_position.position.y)
        {
            j = loc1_position.position.y;
            return j;
        }
        else
        {
            return y_goal;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.GetComponent<PlayerMovement>().jumpOne)
        {
            collision.transform.position= new Vector2(collision.transform.position.x, transform.position.y+1.45f);
        }
    }
    /*private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }*/
}
