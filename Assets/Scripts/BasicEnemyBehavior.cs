using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyBehavior : EnemyBehavior
{

    public override void Move(Vector2 direction)
    {
        transform.position += (Vector3)direction;
    }

    public override void Damage(int dmg)
    {
        
    }

    public override void Death()
    {
        throw new System.NotImplementedException();
    }
}
