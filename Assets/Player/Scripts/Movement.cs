using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] LayerMask groundMask;
    [SerializeField] CharacterController controller;
    [SerializeField] float movementSpeed = 11f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float jumpHeight = 1f;


    Vector2 HorizontalInput;
    Vector3 horizontalVelocity = new Vector3();
    Vector3 verticalVelocity = new Vector3();
    bool isGrounded;
    bool jump;

    public void rxInput(Vector2 _horizontalInput)
    {
        HorizontalInput = _horizontalInput;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundMask);

        horizontalVelocity = (transform.right * HorizontalInput.x + transform.forward * HorizontalInput.y) * movementSpeed; //Velocity Along the X and Z axis - horizontal is a bit ambigous
        controller.Move(horizontalVelocity * Time.deltaTime);

        if (isGrounded)
        {
            verticalVelocity.y = 0;

            if (jump)
            {
                jump = false;
                verticalVelocity.y = Mathf.Sqrt(-2 * jumpHeight * gravity);
                controller.Move(verticalVelocity * Time.deltaTime);
                print("JUMP!");
            }
        }
        else verticalVelocity.y += gravity * Time.deltaTime;
        
        controller.Move(verticalVelocity * Time.deltaTime);
    }

    public void OnJumpPressed()
    {
        jump = true;
    }
}
