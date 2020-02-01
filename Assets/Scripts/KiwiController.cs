using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiwiController : BasicEnemyController
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
        }

        if(moving)
        {
            GetComponent<BasicEnemyBehavior>().Move(direction * Vector2.right * movespeed);
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
}
