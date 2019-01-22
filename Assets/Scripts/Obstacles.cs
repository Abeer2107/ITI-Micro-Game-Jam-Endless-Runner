using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigBody;

    void Awake()
    {
        this.rigBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigBody.velocity = new Vector2(-1 * speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            FindObjectOfType<AudioManager>().playHitSFX();
            FindObjectOfType<GameManager>().gameOver();
            //Debug.Break();
            //return;
        }
    }
}
