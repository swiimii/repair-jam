using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour
{
    public float myValue    ;
    void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<CoinCollector>().currentAmount += myValue;
    }
}
