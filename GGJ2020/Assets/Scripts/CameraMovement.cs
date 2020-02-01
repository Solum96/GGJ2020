using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float yAxis;
    public Transform target;
    public float smoothing;
    // Start is called before the first frame update
    void Start()
    {
        yAxis = target.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target.position.y > transform.position.y)
        {
            Vector3 targetPosition = new Vector3(transform.position.x, target.position.y, -10);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
