using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        var newPlayer = GameObject.Instantiate(player);
    }
}
