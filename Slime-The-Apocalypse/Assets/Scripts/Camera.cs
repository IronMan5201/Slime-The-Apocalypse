using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    //attach to camera object
    public GameManager gm;

    void Start()
    {
        if (gm == null)
        {
            GameObject.Find("Manager").GetComponent<GameManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = gm.player.transform.position;
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }
}
