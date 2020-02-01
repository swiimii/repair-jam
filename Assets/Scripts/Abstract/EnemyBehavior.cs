using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehavior : MonoBehaviour
{
    public abstract void Move(Vector2 dir);

    public abstract void Damage(int dmg);

    public abstract void Death();
}
