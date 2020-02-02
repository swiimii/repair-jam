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
        StartCoroutine("DeathRoutine");
    }

    public IEnumerator DeathRoutine()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Animator>().SetBool("isDead", true);
        GetComponent<BasicEnemyController>().enabled = false;
        var col = GetComponent<Collider2D>();
        col.offset = new Vector3(col.offset.x, col.offset.y - 100);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
