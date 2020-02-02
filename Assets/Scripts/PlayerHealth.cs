using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : HealthController
{
    [SerializeField] bool invulnerable = false;
    [SerializeField] float invulnerablilityTime = 1f;

    public Sprite pic0;
    public Sprite pic1;
    public Sprite pic2;
    public Sprite pic3;

    public GameObject healthImage;
    private Sprite[] sprites;
    public GameObject deathMenu;

    public void Start()
    {
        sprites = new Sprite[4] { pic0, pic1, pic2, pic3 };
        maxHealth = 3;
        health = maxHealth;
        healthImage.GetComponent<Image>().sprite = sprites[health];
        
    }
    public override void Damage(int dmg)
    {
        if (!invulnerable)
        {
            health -= dmg;
            UpdatePicture();
            // GetComponent<MovementBehavior>().Knockback();
            if(health > 0)
            {
                StartCoroutine("Invulnerable");                
            }
            else
            {
                StartCoroutine("Death");
            }
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
        //yield return new WaitForSeconds(invulnerablilityTime);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), true);
        float timeElapsed = 0f;
        float timeElapsedSinceBlink = 0f;
        float interval = .3f;
        while (timeElapsed < invulnerablilityTime)
        {
            if(timeElapsedSinceBlink < interval / 2)
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .5f);
            }
            else
            {
                GetComponent<SpriteRenderer>().color = Color.white;
            }
            timeElapsed += Time.deltaTime;
            timeElapsedSinceBlink += Time.deltaTime;
            timeElapsedSinceBlink %= interval;
            yield return null;
        }
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), false);
        GetComponent<SpriteRenderer>().color = Color.white;
        invulnerable = false;
    }

    public void UpdatePicture()
    {

        if( health < 0 )
        {
            health = 0;
        }
        healthImage.GetComponent<Image>().sprite = sprites[health]; ;
        
    }

    public IEnumerator Death()
    {
        GetComponent<PlayerMovementController>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GetComponent<Rigidbody2D>().isKinematic = true;
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), true);

        float timeElapsed = 0f;
        float timeElapsedSinceBlink = 0f;
        float interval = .3f;
        while (timeElapsed < invulnerablilityTime)
        {
            if (timeElapsedSinceBlink < interval / 2)
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .5f);
            }
            else
            {
                GetComponent<SpriteRenderer>().color = Color.white;
            }
            timeElapsed += Time.deltaTime;
            timeElapsedSinceBlink += Time.deltaTime;
            timeElapsedSinceBlink %= interval;
            yield return null;
        }

        GetComponent<SpriteRenderer>().enabled = false;
        deathMenu.SetActive(true);
        // Show death screen
    }
}
