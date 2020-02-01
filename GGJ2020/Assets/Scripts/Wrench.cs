using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrench : MonoBehaviour
{
    Rigidbody2D rb;
    new Collider2D collider;
    public Player player;
    public new Camera camera;

    float _direction;
    public float xForce;
    public float yForce;


    void Awake()
    {
        _direction = Input.GetAxisRaw("Horizontal");
        collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(xForce * _direction, yForce);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < camera.transform.position.y - 10)
        {
            GameObject.Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Destroy(this);
    }
}
