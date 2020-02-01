using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScript : MonoBehaviour
{
    public Text winText;
    public Player player;

    void OnTriggerEnter2D(Collider2D collider)
    {
        winText.enabled = true;
        GameObject.Destroy(player);
    }
}
