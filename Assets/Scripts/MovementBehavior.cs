using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    private Rigidbody2D myRigidbody;

    private GameObject hitbox;
    
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

    public void Chop()
    {
        StartCoroutine("ChopRoutine");
    }

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

    public IEnumerator ChopRoutine()
    {
        float attackDuration = .6f;
        Vector3 offset = new Vector3(1f * GetComponent<PlayerMovementController>().direction, 0);

        hitbox = Instantiate(GetComponent<PlayerMovementController>().attackHitbox);
        GetComponent<PlayerMovementController>().attacking = true;
        GetComponent<Animator>().SetBool("attacking", true);
        Lunge();

        float elapsed = 0f;
        while(elapsed < attackDuration)
        {
            elapsed += Time.deltaTime;
            hitbox.transform.position = transform.position + offset;
            yield return null;

        }

        Destroy(hitbox);
        GetComponent<PlayerMovementController>().attacking = false;
        GetComponent<Animator>().SetBool("attacking", false);

        
    }

    public void Lunge()
    {
        var direction = GetComponent<PlayerMovementController>().direction;
        var col = GetComponent<PlayerMovementController>().attackHitbox.GetComponent<BoxCollider2D>();
        var rb = GetComponent<Rigidbody2D>();

        col.offset = new Vector3(col.offset.x * direction, col.offset.y);
        var magnitude = 6f * direction;        
        rb.velocity = new Vector3(magnitude, rb.velocity.y);
    }

    public void CancelAttack()
    {
        GetComponent<PlayerMovementController>().attacking = false;
        Destroy(hitbox);
        GetComponent<MovementBehavior>().StopCoroutine("ChopRoutine");
        GetComponent<Animator>().SetBool("attacking", false);
    }
}

