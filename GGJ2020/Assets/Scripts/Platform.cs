using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Sprite broken;
    public Sprite repaired;
    public SpriteRenderer spriteRenderer;
    public Collider2D hitBox;
    public Collider2D trigger;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = broken;
    }
    void OnTriggerEnter2D(Collider2D item)
    {
        if(item.gameObject.tag == "Wrench")
        {
            hitBox.enabled = true;
            spriteRenderer.sprite = repaired;
            GameObject.Destroy(item.gameObject);
            trigger.enabled = false;
        }
    }
}
