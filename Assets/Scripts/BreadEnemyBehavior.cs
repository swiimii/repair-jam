using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadEnemyBehavior : EnemyBehavior
{
    //public void Move(Vector3 direction)
    //{
    //    transform.position += direction;
    //}

    [SerializeField] float jumpMagnitude = .2f;

    public override void Move(Vector2 direction)
    {
        transform.position += (Vector3)direction;
    }

    public void FlipMovementDirection()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(rb.velocity.x * -1, rb.velocity.y);
    }
    public void Jump(Vector2 jumpAngle)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(jumpAngle.x * GetComponent<BreadController>().direction, jumpAngle.y).normalized * jumpMagnitude;
    }


    public virtual void Knockback(Vector2 direction)
    {
        return;
    }
}
       
