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
    }

    public virtual void Death()
    {

    }
}
