using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("game has started");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) //jump movement, only when space key is down
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 14, 0); //changing the velocity
        }
    }
}
