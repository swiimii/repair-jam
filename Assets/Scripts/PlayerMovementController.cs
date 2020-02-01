using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public MovementBehavior myBehavior;

    private void Start()
    {
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
        
        if (horizontal < 0)
        {
            var sprite = GetComponent<SpriteRenderer>();
            GetComponent<Animator>().SetBool("isMoving", true);
            sprite.flipX = true;
        }
        else if (horizontal > 0)
        {
            GetComponent<Animator>().SetBool("isMoving", true);
            var sprite = GetComponent<SpriteRenderer>();
            sprite.flipX = false;
        }
        else
        {
            GetComponent<Animator>().SetBool("isMoving", false);
        }
        //fixed rate movement
        myBehavior.Move(new Vector2(horizontal * 5, myRigidBody.velocity.y));
    }

    
}
