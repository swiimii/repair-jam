using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : EnemyController
{

    public float movespeed = .1f;
    public int direction = 1;
    // Update is called once per frame
    void FixedUpdate()
    {
        if(HittingWall())
        {
            direction *= -1;
        }

        GetComponent<BasicEnemyBehavior>().Move(direction * Vector2.right * movespeed);
    }

    public override bool HittingWall()
    {
        var distance = .8f * direction;
        var layermask = 1 << LayerMask.NameToLayer("Ground");

        var hit = Physics2D.Raycast(transform.position, Vector3.right, distance, layermask, 0);
        Debug.DrawRay(transform.position, Vector3.right * distance, Color.green);

        // print(hit.collider ? hit.collider.gameObject : false);
        if (hit.collider)
        {
            return true;
        }
        return false;
    }

    public override bool Grounded()
    {
        var distance = .8f * direction;
        var layermask = 1 << LayerMask.NameToLayer("Ground");

        var hit = Physics2D.Raycast(transform.position, Vector3.down, distance, layermask, 0);
        Debug.DrawRay(transform.position, Vector3.down * distance, Color.blue);

        print(hit.collider ? hit.collider.gameObject : false);
        if (hit.collider)
        {
            return true;
        }
        return false;
    }
}
