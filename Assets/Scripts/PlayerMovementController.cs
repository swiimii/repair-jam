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
        Grounded();
        if (vertical != 0 && !Grounded())
        {
            vertical = 0;
        }
        
        myBehavior.Move(new Vector2(horizontal * 5, myRigidBody.velocity.y + vertical));
    }

    public bool Grounded()
    {
        var distance = .8f * 1;
        var layermask = 1 << LayerMask.NameToLayer("Ground");

        var hit = Physics2D.Raycast(transform.position, Vector3.down, distance, layermask, 0);
        Debug.DrawRay(transform.position, Vector3.down * distance, Color.blue);

        print(hit.collider ? hit.collider.gameObject : false);
        if (hit.collider)
        {
            return true;
        }
        return false;
    }
}
