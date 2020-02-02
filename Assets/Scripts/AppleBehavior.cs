using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleBehavior : BasicEnemyBehavior
{

    public void FlipMovementDirection()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(rb.velocity.x * -1, rb.velocity.y);
    }
}
