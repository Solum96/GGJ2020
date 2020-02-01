using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Sprite broken;
    public Sprite repaired;
    public SpriteRenderer renderer;
    public Collider2D hitBox;
    public Collider2D trigger;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = broken;
    }
    void OnTriggerEnter2D(Collider2D item)
    {
        if(item.gameObject.tag == "Wrench")
        {
            hitBox.enabled = true;
            renderer.sprite = repaired;
            GameObject.Destroy(item.gameObject);
            trigger.enabled = false;
        }
    }
}
