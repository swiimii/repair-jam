using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float direction = 0;
    public float movespeed = .5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("EndMe");
    }

    public void FixedUpdate()
    {
        GetComponent<BasicEnemyBehavior>().Move(direction * Vector2.right * movespeed);
    }
    public IEnumerator EndMe()
    {
        yield return new WaitForSeconds(7f);
        Destroy(gameObject);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        print("collided");
        if (collision.gameObject.layer == 9)
        {
            print("meme");
            collision.gameObject.GetComponent<PlayerHealth>().Damage(1);
        }
    }
}