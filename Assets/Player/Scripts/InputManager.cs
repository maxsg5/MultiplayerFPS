using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] Movement movement;
    [SerializeField] FPCamera mouseLook;

    PlayerControls controls;
    PlayerControls.GroundMovementActions groundMovement;

    Vector2 HorizontalInput;
    Vector2 MouseInput;

    private void Awake()
    {
        controls = new PlayerControls();
        groundMovement = controls.GroundMovement;

        groundMovement.Horizontal.performed += ctx => HorizontalInput = ctx.ReadValue<Vector2>();
        groundMovement.Jump.performed += ctx => movement.OnJumpPressed();

        groundMovement.MouseX.performed += ctx => MouseInput.x = ctx.ReadValue<float>() * Time.deltaTime;
        groundMovement.MouseY.performed += ctx => MouseInput.y = ctx.ReadValue<float>() * Time.deltaTime;

    }

    private void OnEnable()
    {
        controls.Enable();

    }
    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        movement.rxInput(HorizontalInput);
        mouseLook.rxInput(MouseInput);
    }
}
