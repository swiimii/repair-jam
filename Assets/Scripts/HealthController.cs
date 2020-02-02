using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthController : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int maxHealth;
    public abstract void Damage(int dmg);

    public virtual int GetHealth()
    {
        return health;
    }


}
