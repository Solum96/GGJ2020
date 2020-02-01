using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    enum PlayerState {Grounded, Charging, Airborne}

    PlayerState state;
    public float moveSpeed;
    public float movement;
    public float jumpLimit;
    public float constForce;
    public float jumpForce;
    public float direction;
    public Sprite chargingSprite;
    public Sprite idleSprite;

    public GameObject wrench;
    new Rigidbody2D rigidbody;
    private float _timer;
    public float fireRate;

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

        if(Input.GetAxisRaw("Horizontal") == -1)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(Input.GetAxisRaw("Horizontal") == 1)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }

        if(Input.GetButton("Jump") && state == PlayerState.Grounded)
        {
            state = PlayerState.Charging;
            StartCoroutine(ChargeJumpCo());
        }

        if(Input.GetKeyDown(KeyCode.P) && state != PlayerState.Charging)
        {
            var newWrench = GameObject.Instantiate(wrench, this.transform);
        }

        if (rigidbody.velocity.y != 0)
        {
            state = PlayerState.Airborne;
        }
        else if(state != PlayerState.Charging)
        {
            state = PlayerState.Grounded;
        }
    }

    private void ThrowWrench()
    {
        
    }

    IEnumerator ChargeJumpCo()
    {
        while(Input.GetButton("Jump") && state == PlayerState.Charging)
        {
            this.GetComponent<SpriteRenderer>().sprite = chargingSprite;

            rigidbody.velocity = new Vector2(0,0);
            if(jumpForce < jumpLimit)
            jumpForce++;

            yield return new WaitForSeconds(.13f);
        }

        this.GetComponent<SpriteRenderer>().sprite = idleSprite;

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
