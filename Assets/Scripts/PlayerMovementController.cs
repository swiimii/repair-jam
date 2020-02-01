using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public MovementBehavior myBehavior;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        //Check for touching floor
        //If input = jump and touchingfloor = false 
        //then vertical = 0
        
        myBehavior.Move(new Vector2(horizontal, myRigidBody.velocity.y + vertical));
    }
}
