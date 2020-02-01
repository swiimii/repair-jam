using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    private Rigidbody2D myRigidbody;

    public void Start()
    {
        //Grab rigidbody for later use
        myRigidbody = GetComponent<Rigidbody2D>();
    }
    
    //Updates Velocity to new Velocity
    public void Move(Vector2 movementVector)
    {
        //Check if you are able to move (not invulnerable)
        if (!GetComponent<PlayerHealth>().IsInvulnerable())
        {
            //Update velocity to new velocity
            myRigidbody.velocity = movementVector;
        }
    }

    public void Knockback()
    {
        //Move up and in the reverse direction
        Move(new Vector2(-myRigidbody.velocity.x, 0.5f));

    }

    public void Jump()
    {
        //Check if grounded
        if (Grounded())
        {
            //Move up
            var jumpVelocity = 5f;
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpVelocity);
        }
        
    }

    //To check if on the ground
    public bool Grounded()
    {
        var distance = .8f;

        //Only compare to Ground layer
        var layermask = 1 << LayerMask.NameToLayer("Ground");

        //Get if it hit
        var hit = Physics2D.Raycast(transform.position, Vector3.down, distance, layermask, 0);

        //Used to see ray
        Debug.DrawRay(transform.position, Vector3.down * distance, Color.blue);

        //Print object if hit, false if false
        print(hit.collider ? hit.collider.gameObject : false);

        //Return true or false based on if it hit ground
        if (hit.collider)
        {
            return true;
        }
        return false;
    }
}
