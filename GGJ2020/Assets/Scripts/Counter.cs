using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    Canvas canvas;
    public Text text;
    public Transform target;
    public Rigidbody2D rb;

    float start;
    float currentDistance;


    // Start is called before the first frame update
    void Start()
    {
        start = target.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null && currentDistance < target.position.y && rb.velocity.y > 0.1)
        {
            currentDistance = target.position.y - start;
        }

        text.text = System.Math.Round(currentDistance * 100,0).ToString();
    }
}
