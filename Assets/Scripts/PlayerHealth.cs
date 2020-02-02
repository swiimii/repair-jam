using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : HealthController
{
    [SerializeField] bool invulnerable = false;
    [SerializeField] float invulnerablilityTime = .3f;

    public Sprite pic1;
    public Sprite pic2;
    public Sprite pic3;
    public Sprite pic4;

    public GameObject healthImage;

    public void Start()
    {
        health = maxHealth;
    }
    public override void Damage(int dmg)
    {
        if (!invulnerable)
        {
            health -= dmg;
            GetComponent<MovementBehavior>().Knockback();
            StartCoroutine("Invulnerable");
            UpdatePicture();
        }
    }

    public bool IsInvulnerable()
    {
        return invulnerable;
    }

    public void Heal(int amount)
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

    public void UpdatePicture()
    {
        if (health == 1)
        {
            healthImage.GetComponent<Image>().sprite = pic1;
        }
        else if (health == 2)
        {
            healthImage.GetComponent<Image>().sprite = pic2;
        }
        else if (health == 3)
        {
            healthImage.GetComponent<Image>().sprite = pic3;
        }
        else if (health == 4)
        {
            healthImage.GetComponent<Image>().sprite = pic4;
        }
    }
}
