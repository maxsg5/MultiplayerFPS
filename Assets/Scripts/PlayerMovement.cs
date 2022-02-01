using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public InputMaster controls; // Inputs NEW INPUT SYSTEM
    public CharacterController controller; //reference to the CharacterController component
    public Transform groundCheck; // a position marking where to check if the player is grounded
    public float groundDistance = 0.4f; // distance for the groundCheck ray
    public LayerMask groundMask; // mask for the ground layer
    public bool isGrounded; // is the player grounded?
    public float jumpHeight = 3f; // the height of the jump
    public float speed = 12f; // movement speed
    public Vector3 velocity; // the velocity of the player
    public float gravity = -9.81f; // the gravity of the player


    // Here we are initializing the InputSystem.
    void Awake()
    {
        controls = new InputMaster(); // you have to intialize the controls in awake because Unity doesn't allow you to just click and drag via the Inspector. IK it's some BS.        
    }

    private void OnEnable()
    {
        controls.Enable(); 
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // check if the player is grounded

        if (isGrounded && velocity.y < 0) // if the player is grounded and is falling
            velocity.y = -2f; // set the velocity to -2f
        
        
        float x = controls.Player.Move.ReadValue<Vector3>().x; // get the x value of the movement
        float z = controls.Player.Move.ReadValue<Vector3>().z; // get the z value of the movement

        Vector3 move = transform.right * x + transform.forward * z; // create a vector3 for the movement

        controller.Move(move * speed * Time.deltaTime); // move the player

        // if the jump button is pressed and the player is grounded
        if(controls.Player.Jump.ReadValue<float>() > 0 && isGrounded) 
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // calculate the velocity of the jump
        
        velocity.y += gravity * Time.deltaTime; // add the gravity to the velocity

        controller.Move(velocity * Time.deltaTime); // Jump the player


        //OLD INPUT SYSTEM STUFF UNCOMMENT IF YOU WANT TO USE OLD INPUT SYSTEM

        // isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // check if the player is grounded
        // if (isGrounded && velocity.y < 0) // if the player is grounded and is falling
        // {
        //     velocity.y = -2f; // set the velocity to -2f
        // }

        // float x = Input.GetAxis("Horizontal");
        // float z = Input.GetAxis("Vertical");

        // Vector3 move = transform.right * x + transform.forward * z;

        // controller.Move(move * speed * Time.deltaTime);

        // if(Input.GetButtonDown("Jump") && isGrounded){
        //     velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        // }

        // velocity.y += gravity * Time.deltaTime;

        // controller.Move(velocity * Time.deltaTime);

    }
}
