using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    public void Move(Vector2 movementVector)
    {
        if (!GetComponent<PlayerHealth>().IsInvulnerable())
        {
            Rigidbody2D myRigidbody = GetComponent<PlayerMovementController>().myRigidBody;
            myRigidbody.velocity = movementVector;
        }
    }
    public void KnockBack()
    {
        PlayerMovementController player = GetComponent<PlayerMovementController>();
        Move(new Vector2(-player.myRigidBody.velocity.x, 0.5f));

    }

}
