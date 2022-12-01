using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyRB : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D original;
    public Rigidbody2D copyCat;

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        copyCat.velocity = original.velocity;
        //copyCat.position = original.position;
    }
}
