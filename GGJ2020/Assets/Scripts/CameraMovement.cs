using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    private bool playerAlive = true;
    private float yAxis;
    public Transform target;
    public float smoothing;
    public Text gameOverText;
    public Text replayText;
    public float riseSpeed;

    // Start is called before the first frame update
    void Start()
    {
        yAxis = target.position.y;
    }

    void Update()
    {
        if(playerAlive == true)
        transform.position += new Vector3(0, riseSpeed / 100, 0);

        if(target != null && target.gameObject.transform.position.y < this.transform.position.y - Screen.height / 50)
        {
            GameObject.Destroy(target.gameObject);
            //gameObject.GetComponent<CameraMovement>().enabled = false;
            gameOverText.enabled = true;
            replayText.enabled = true;

            playerAlive = false;
        }
        if(playerAlive == false && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(0);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // if (target != null && target.position.y > transform.position.y)
        // {
        //     Vector3 targetPosition = new Vector3(transform.position.x, target.position.y, -10);
        //     transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        // }
    }
}
