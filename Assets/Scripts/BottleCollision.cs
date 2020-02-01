using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleCollision : MonoBehaviour
{
    public float myValue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<PlayerHealth>().Heal(1);
        Destroy(gameObject);
    }
    void OnCollisionEnter(Collision collision)
    {
        
    }
}
