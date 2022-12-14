using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class MeleeBT : BehaviorTree.Tree
{
    public static float speed = 3f;
    public LayerMask mask;
    public LayerMask enemy;
    public LayerMask blocker;
    public LayerMask button;
    protected override BTNode SetUpTree()
    {
        Collider2D WallCollider = null;
        Collider2D PlatformTracker = null;
        Collider2D temp2DC = null;
        Rigidbody2D rig2D = null;

        if (gameObject.transform.Find("Wall Tracker").GetComponent<Collider2D>() != null)
            WallCollider = gameObject.transform.Find("Wall Tracker").GetComponent<Collider2D>();

        if (gameObject.transform.Find("Tracker").GetComponent<Collider2D>() != null)
            PlatformTracker = gameObject.transform.Find("Tracker").GetComponent<Collider2D>();

        if (gameObject.transform.GetChild(0).GetComponent<Collider2D>() != null)
            temp2DC = transform.GetComponent<Collider2D>();

        if (gameObject.GetComponent<Rigidbody2D>() != null)
            rig2D = gameObject.GetComponent<Rigidbody2D>();
        else
            rig2D = transform.GetChild(0).GetComponent<Rigidbody2D>();

        BTNode root = new PatrolTask(temp2DC, rig2D, gameObject.GetComponent<Transform>(), mask, button, blocker, enemy, WallCollider, PlatformTracker);

        return root;

    }
}
