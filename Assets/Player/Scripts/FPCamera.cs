using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCamera : MonoBehaviour
{
    public float sensX = 8f;
    public float sensY = 8f;

    [SerializeField] Transform playerCamera;
    [SerializeField] float xClamp = 85f;
    float xRotation = 0f;
    float yRotation = 0f;

    float mouseX, mouseY;

    Vector3 targetRotation;

    //Callback for Input Action
    public void rxInput(Vector2 mouseInput)
    {
        mouseX = mouseInput.x * sensX;
        mouseY = mouseInput.y * sensY;
    }

   
    private void Update()
    {
        //Rotation around X axis
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
        //Rotation around Y axis
        yRotation += mouseX;


        targetRotation = transform.eulerAngles;
        targetRotation.x = xRotation;
        targetRotation.y = yRotation;

        playerCamera.eulerAngles = targetRotation;
        
        
    }
}
