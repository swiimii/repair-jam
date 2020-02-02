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
        if (!HittingWall())
        {
            //Update velocity to new velocity
            myRigidbody.velocity = movementVector;
        }
    }

    //public void Knockback()
    //{
    //    //Move up and in the reverse direction
    //    Move(new Vector2(-myRigidbody.velocity.x, 0.5f));

    //}

    public void Jump()
    {
        //Move up
        GetComponent<Animator>().SetTrigger("jump");
        GetComponent<Animator>().SetBool("isAirborne", true);
        var jumpVelocity = 6f;
        myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpVelocity);               
    }

    //To check if on the ground

    public bool HittingWall()
    {
        //Set positive or negative direction
        float distance = .7f * GetComponent<PlayerMovementController>().direction;

        //Only compare to Ground layer
        int layermask = 1 << LayerMask.NameToLayer("Ground");

        //Height of object divided by 2
        float height = GetComponent<CapsuleCollider2D>().bounds.size.x / 2;
        
        //Vector form of above
        Vector3 heightVector = new Vector3(0, height, 0);

        //Checks middle, high, and low casts
        RaycastHit2D hit1 = Physics2D.Raycast(transform.position, Vector3.right, distance, layermask);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position +  heightVector, Vector3.right, distance, layermask);
        RaycastHit2D hit3 = Physics2D.Raycast(transform.position - heightVector , Vector3.right, distance, layermask);
        
        //Draws the rays
        Debug.DrawRay(transform.position, Vector3.right * distance, Color.green);
        Debug.DrawRay(transform.position + heightVector, Vector3.right * distance, Color.green);
        Debug.DrawRay(transform.position - heightVector, Vector3.right * distance, Color.green);
        
        
        //if it hit return true for hitting wall
        if (hit1.collider || hit2.collider || hit3.collider)
        {
            return true;
        }
        return false;
    }
}
