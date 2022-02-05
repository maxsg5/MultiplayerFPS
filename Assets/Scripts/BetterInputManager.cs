using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterInputManager : MonoBehaviour
{
    private static BetterInputManager instance; //singelton
    public static BetterInputManager Instance
    {
        get
        {
            return instance;
        }
    }
   
   private InputMaster controls; // Inputs NEW INPUT SYSTEM

   private void Awake()
   {
       if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        controls = new InputMaster(); // you have to intialize the controls in awake because Unity doesn't allow you to just click and drag via the Inspector. IK it's some BS.

        Cursor.visible = false; // hide the cursor
        Cursor.lockState = CursorLockMode.Locked; //lock the cursor to the center of the screen
   }


    private void OnEnable()
    {
         controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return controls.Player.Move.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return controls.Player.Look.ReadValue<Vector2>();
    }

    public bool PlayerJumpedThisFrame()
    {
        return controls.Player.Jump.triggered;
    }

}
