using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBG : MonoBehaviour
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
}
