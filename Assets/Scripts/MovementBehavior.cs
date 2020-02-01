using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    public void Move(Vector2 movementVector, Rigidbody2D myRigidbody)
    {
        myRigidbody.velocity = movementVector;
    }
}
