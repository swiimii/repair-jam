using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadController : BasicEnemyController
{

    public bool moving = false;
    public Vector2 jumpAngle;
    [SerializeField] float idleduration = .4f;

    private void Start()
    {
        StartCoroutine("MovementSwitch");
    }

    public override void FixedUpdate()
    {
        if (HittingWall())
        {
            direction *= -1;
            var sprite = GetComponent<SpriteRenderer>();
            sprite.flipX = sprite.flipX ? false : true;

            // keep velocity , mult by new vec3(keepx*-1, keepy, keepz)
            GetComponent<BreadEnemyBehavior>().FlipMovementDirection();
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
            GetComponent<BreadEnemyBehavior>().Jump(jumpAngle);
            yield return new WaitForSeconds(.2f);
            while(!Grounded())
            {
                yield return null;
            }
        }
    }   
}
