using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public MovementBehavior myBehavior;
    public float direction;
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
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetAxisRaw("Vertical") > 0)
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

    
}
