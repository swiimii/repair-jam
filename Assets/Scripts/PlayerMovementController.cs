using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public MovementBehavior myBehavior;

    private float horizontal;
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetAxisRaw("Jump") > 0)
        {
            myBehavior.Jump();
        }
    }

    void FixedUpdate()
    {
        //fixed rate movement
        myBehavior.Move(new Vector2(horizontal * 5, myRigidBody.velocity.y));
    }

    
}
