using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    enum PlayerState {Grounded, Charging, Airborne}

    PlayerState state;
    public float moveSpeed;
    public float jumpLimit;
    public float constForce;
    public float jumpForce;
    public float direction;
    public GameObject wrench;
    new Rigidbody2D rigidbody;
    public float movement;



    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        state = PlayerState.Grounded;
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * moveSpeed;
        if(movement != 0){ direction = Input.GetAxisRaw("Horizontal"); }

        if(Input.GetKey(KeyCode.Space) && state == PlayerState.Grounded)
        {
            state = PlayerState.Charging;
            StartCoroutine(ChargeJumpCo());
        }

        if(Input.GetKeyDown(KeyCode.P) && state != PlayerState.Charging)
        {
            var newWrench = GameObject.Instantiate(wrench, this.transform);
        }

        if(rigidbody.velocity.y != 0)
        {
            state = PlayerState.Airborne;
        }
        else if(state != PlayerState.Charging)
        {
            state = PlayerState.Grounded;
        }
    }

    IEnumerator ChargeJumpCo()
    {
        while(Input.GetKey(KeyCode.Space) && state == PlayerState.Charging)
        {
            if(jumpForce < jumpLimit)
            jumpForce++;

            yield return new WaitForSeconds(.15f);
        }

        Vector2 velocity = rigidbody.velocity;
        velocity.y = jumpForce;
        rigidbody.velocity = velocity;
        jumpForce = constForce;
    }

    void FixedUpdate()
    {
        if(state != PlayerState.Charging)
        {
            Vector2 velocity = rigidbody.velocity;
            velocity.x = movement;
            rigidbody.velocity = velocity;
        }
    }
}
