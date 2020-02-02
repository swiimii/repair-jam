using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadController : BasicEnemyController
{

    public bool moving = false;
    [SerializeField] float movementduration = 2f;
    [SerializeField] float idleduration = 1f;

    private void Start()
    {
        StartCoroutine("MovementSwitch");
    }

    public override void FixedUpdate()
    {
        if (HittingWall() || AtEdge())
        {
            direction *= -1;
            var sprite = GetComponent<SpriteRenderer>();
            sprite.flipX = sprite.flipX ? false : true;

            // keep velocity , mult by new vec3(keepx*-1, keepy, keepz)
        }

        if(moving)
        {
            GetComponent<BreadEnemyBehavior>().Move(direction * new Vector2(1.0f,3.0f) * movespeed);
        }        
    }

    public IEnumerator MovementSwitch()
    {
        while (true)
        {
            moving = false;
            GetComponent<Animator>().SetBool("isMoving", false);
            yield return new WaitForSeconds(idleduration);

            moving = true;
            GetComponent<Animator>().SetBool("isMoving", true);
            yield return new WaitForSeconds(movementduration);            
        }
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
