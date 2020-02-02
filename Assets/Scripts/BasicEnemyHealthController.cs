using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyHealthController : HealthController
{
    private void Start()
    {
        health = maxHealth;
    }

    public override void Damage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        Destroy(gameObject);
    }
}
