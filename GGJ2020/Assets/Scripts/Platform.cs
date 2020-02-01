using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Collider2D hitBox;
    public Collider2D trigger;

    void OnTriggerEnter2D(Collider2D item)
    {
        if(item.gameObject.tag == "Wrench")
        {
            hitBox.enabled = true;
            GameObject.Destroy(item.gameObject);
            trigger.enabled = false;
        }
    }
}
