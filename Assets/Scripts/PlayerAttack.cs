using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer.Equals(LayerMask.NameToLayer("Enemy")))
        {
            collision.gameObject.GetComponent<BasicEnemyHealthController>().Damage(1);
            print("boi");
        }
    }
}
