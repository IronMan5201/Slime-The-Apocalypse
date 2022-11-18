using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class MeleeBT : BehaviorTree.Tree
{
    public static float speed = 3f;
    public LayerMask mask;
    protected override BTNode SetUpTree()
    {
        BTNode root = new PatrolTask(gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Rigidbody2D>(), gameObject.GetComponent<Transform>(), mask);

        return root;
    }
}
