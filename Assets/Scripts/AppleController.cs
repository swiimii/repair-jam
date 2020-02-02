using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : BasicEnemyController
{
    public float idleDuration;
    public bool moving = false;
    public bool attacking = false;
    public bool shooting = false;
    public GameObject bullet;
    private void Start()
    {
        direction = -1;
        StartCoroutine("MovementSwitch");
    }

    public override void FixedUpdate()
    {
        if (HittingWall() || AtEdge())
        {
            direction *= -1;
            var sprite = GetComponent<SpriteRenderer>();
            sprite.flipX = sprite.flipX ? false : true;
            GetComponent<AppleBehavior>().FlipMovementDirection();
        }
        if (moving)
        {
            GetComponent<AppleBehavior>().Move(direction * Vector2.right * movespeed);
        }
    }
    public IEnumerator MovementSwitch()
    {
        while (true)
        {
            moving = false;
            GetComponent<Animator>().SetBool("walk", false);
            GetComponent<Animator>().SetBool("attack", true);
            yield return new WaitForSeconds(2f);
            GetComponent<Animator>().SetBool("attack",false);
            GetComponent<Animator>().SetBool("shoot", true);
            yield return new WaitForSeconds(.4f);
            Fire();
            GetComponent<Animator>().SetBool("shoot", false);

            moving = true;
            GetComponent<Animator>().SetBool("walk", true);
            yield return new WaitForSeconds(.2f);
        }
    }

    public void Fire()
    {
        var obj = Instantiate(bullet, transform.position + Vector3.down * .2f, Quaternion.identity);
        obj.GetComponent<BulletController>().direction = direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("collided");
        if (collision.gameObject.layer == 9)
        {
            print("meme");
            collision.gameObject.GetComponent<PlayerHealth>().Damage(1);
        }
    }
}
