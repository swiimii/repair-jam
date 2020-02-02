using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public MovementBehavior myBehavior;
    public float direction;
    public bool grounded;
    private void Start()
    {
        direction = 0;
        myRigidBody = GetComponent<Rigidbody2D>();
        myBehavior = GetComponent<MovementBehavior>();
    }

    private float horizontal;
    // Update is called once per frame
    void Update()
    {
        grounded = Grounded();
        horizontal = Input.GetAxisRaw("Horizontal");

        if (grounded && Input.GetAxisRaw("Vertical") > 0)
        {
            myBehavior.Jump();
        }
    }

    void FixedUpdate()
    {
        //Left
        if (horizontal < 0)
        {
            direction = -1;
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            GetComponent<Animator>().SetBool("isMoving", true);
            sprite.flipX = true;
        }
        //Right
        else if (horizontal > 0)
        {
            direction = 1;
            GetComponent<Animator>().SetBool("isMoving", true);
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            sprite.flipX = false;
        }
        //Not moving
        else
        {
            GetComponent<Animator>().SetBool("isMoving", false);
        }

        //fixed rate movement
        myBehavior.Move(new Vector2(horizontal * 5, myRigidBody.velocity.y));
    }

    private bool Grounded()
    {
        float distance = .8f;

        //Only compare to Ground layer
        int layermask = 1 << LayerMask.NameToLayer("Ground");

        //Get if it hit
        var hit = Physics2D.Raycast(transform.position, Vector3.down, distance, layermask, 0);

        //Draws ray
        Debug.DrawRay(transform.position, Vector3.down * distance, Color.blue);

        //Return true or false based on if it hit ground
        if (hit.collider)
        {
            GetComponent<Animator>().SetBool("isAirborne", false);
            return true;
        }
        return false;
    }


}
