using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehavior : MonoBehaviour
{
    public abstract void Move(Vector2 dir);

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        print("collided");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            print("meme");
            collision.gameObject.GetComponent<PlayerHealth>().Damage(1);
        }
    }
}
