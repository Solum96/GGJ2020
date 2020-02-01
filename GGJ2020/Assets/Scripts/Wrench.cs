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
        collider = GetComponent<Collider2D>();
        collider.enabled = false;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(xForce * player.direction, yForce);

        StartCoroutine(SetColliderCo());
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < camera.transform.position.y - 10)
        {
            GameObject.Destroy(gameObject);
        }
    }

    IEnumerator SetColliderCo()
    {
        yield return new WaitForSeconds(.3f);
        this.collider.enabled = true;
    }

    void OnCollissionEnter2D(Collision collision)
    {
        GameObject.Destroy(this);
    }
}
