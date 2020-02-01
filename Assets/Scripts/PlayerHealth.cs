using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthController
{
    [SerializeField] bool invulnerable = false;
    [SerializeField] float invulnerablilityTime = .3f;

    public void Start()
    {
        health = maxHealth;
    }
    public override void Damage(int dmg)
    {
        if(!invulnerable)
        {
            health -= dmg;
            // GetComponent<MovementBehavior>().knockBack();
            StartCoroutine("Invulnerable");
        }
    }

    public bool IsInvulnerable()
    {
        return invulnerable;
    }

    public IEnumerator Invulnerable()
    {
        invulnerable = true;
        yield return new WaitForSeconds(invulnerablilityTime);
        invulnerable = false;
        yield return null;
    }
}
