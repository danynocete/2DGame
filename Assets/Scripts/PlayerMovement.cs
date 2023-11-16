using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Animator animator;
    private SpriteRenderer sprite;

    private float directionX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling }
    

    // Start is called before the first frame update
    private void Start()
    {
        //initialise fields
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(directionX * moveSpeed,rigidBody.velocity.y); //moving left or right

        if (Input.GetButtonDown("Jump")) //jump movement, only when space key is down
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce); //changing the velocity
        }
        UpdateAnimation();
    }
    /**
     * Updates Player's animation accoring to their movement
     */
    private void UpdateAnimation()
    {
        MovementState state;

        if (directionX > 0f) //player is running right
        {
            state = MovementState.running;
            sprite.flipX = false; //flip the sprite to the right
        }
        else if (directionX < 0f) //player is running left
        {
            state = MovementState.running;
            sprite.flipX = true; //flip the sprite to the left
        }
        else
        {
            state = MovementState.idle; //player is idle
        }

        if(rigidBody.velocity.y > .1f) //player is jumping
        {
            state = MovementState.jumping;
        }
        else if (rigidBody.velocity.y < -.1f) //player is falling
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state", (int)state);
    }
}
