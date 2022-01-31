using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller; //reference to the CharacterController component
    
    public Transform groundCheck; // a position marking where to check if the player is grounded
    public float groundDistance = 0.4f; // distance for the groundCheck ray
    public LayerMask groundMask; // mask for the ground layer
    public bool isGrounded; // is the player grounded?

    public float jumpHeight = 3f; // the height of the jump
    public float speed = 12f; // movement speed

    Vector3 velocity; // the velocity of the player

    public float gravity = -9.81f; // the gravity of the player


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // check if the player is grounded

        if (isGrounded && velocity.y < 0) // if the player is grounded and is falling
        {
            velocity.y = -2f; // set the velocity to -2f
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded){
            
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}
