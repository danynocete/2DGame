using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
   
    // Start is called before the first frame update
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(directionX * 7f,rigidBody.velocity.y); //moving left or right

        if (Input.GetButtonDown("Jump")) //jump movement, only when space key is down
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 14f); //changing the velocity
        }
    }
}
