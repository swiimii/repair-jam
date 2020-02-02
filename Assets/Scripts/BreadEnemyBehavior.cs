using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadEnemyBehavior : EnemyBehavior
{
    //public void Move(Vector3 direction)
    //{
    //    transform.position += direction;
    //}

    public override void Move(Vector2 direction)
    {
        transform.position += (Vector3)direction;
    }

    public virtual void Knockback(Vector2 direction)
    {
        return;
    }
}
       
