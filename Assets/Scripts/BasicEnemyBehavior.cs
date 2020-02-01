using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyBehavior : EnemyBehavior
{
    public override void Move(Vector2 direction)
    {
        transform.position += (Vector3)direction;
    }

    public virtual void Knockback(Vector2 direction)
    {
        return;
    }
}
       
