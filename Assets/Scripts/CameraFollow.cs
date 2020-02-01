using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 0, -20);
    public float leftBound = -100;
    // Update is called once per frame
    void Update()
    {
        
        if ((player.transform.position + offset).x > leftBound)
        {
            //Used to follow player object
            gameObject.transform.position = player.transform.position + offset;
        }
        
    }
}
    