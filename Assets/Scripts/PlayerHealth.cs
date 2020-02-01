using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 3;
    [SerializeField] bool invulnerable = false;
    [SerializeField] float invulnerablilityTime = .3f;

    public void Damage(int dmg)
    {
        if(!invulnerable)
        {
            health -= dmg;
            GetComponent<MovementBehavior>().Knockback();
            StartCoroutine("Invulnerable");
        }
    }

    public bool IsInvulnerable()
    {
        return invulnerable;
    }

    public int GetHealth()
    {
        return health;
    }

    public void Heal (int amount)
    {
        health += amount;
    }

    public IEnumerator Invulnerable()
    {
        invulnerable = true;
        yield return new WaitForSeconds(invulnerablilityTime);
        invulnerable = false;
        yield return null;
    }
}
